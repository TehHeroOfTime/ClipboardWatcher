using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardWatcher
{
    public partial class Form1 : Form
    {
        bool allowCopy = true;
        int linkText = 0;
        int restartSeconds;
        BLFile bLayerFile;
        
        public Form1()
        {
            Clipboard.Clear();

            InitializeComponent();
            bLayerFile = new BLFile();
            
            _clipboardViewerNext = SetClipboardViewer(this.Handle);      // Adds our form to the chain of c
        }

        private void Form1_Load(object sender, EventArgs e)
        {            

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            btnText.Visible = false;
            btnImages.Visible = true;

            this.Size = new Size(1305, 788);

            bLayerFile.CreateSettingsFile();
            bLayerFile.ReadSettings();
            tbPathText.Text = Variables.textPath;
            tbPathImages.Text = Variables.imagePath;

            bLayerFile.WriteSettings();            
            Variables.type = "Text";

            if (Variables.stretchImage)
                cbStretch.Checked = true;
            else
                cbStretch.Checked = false;
                        

            //scrollbars on picturebox
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            

            

            DisableControls();

            
            this.WindowState = FormWindowState.Minimized;

            tmrHide.Start();
            this.Hide();       
        }

        private void CopySelectedValuesToClipboard()
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in listView1.SelectedItems)
                builder.AppendLine(item.SubItems[0].Text);

            Clipboard.SetText(builder.ToString());
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != listView1) return;

            if (e.Control && e.KeyCode == Keys.C)
            {
                allowCopy = false;
                CopySelectedValuesToClipboard();                
            }
            if(e.KeyCode == Keys.Delete)
            {
                Variables.clipboardTextList.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);                    
            }

            lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
            lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
            lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count);
        }


        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308;        // WM_DRAWCLIPBOARD message
        private IntPtr _clipboardViewerNext;                // Our variable that will hold the value to identify the next window in the clipboard viewer chain


        int tt = 0;
        protected override void WndProc(ref Message m)
        {
            tt++;

            string date = DateTime.Now.ToLongDateString();
            string Time = DateTime.Now.ToLongTimeString();
            string completedate = date + " " + Time;
            base.WndProc(ref m);    // Process the message 

            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                

                try
                {
                    IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data

                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        string text = (string)iData.GetData(DataFormats.Text);      // Clipboard text

                        if (text.Contains("http")) 
                            linkText++; 

                        if (linkText <= 1)
                        {
                            ListViewItem itm = new ListViewItem();
                            itm.Text = text;
                            if (allowCopy)
                            {
                                itm.SubItems.Add(completedate);
                                listView1.Items.Add(itm);
                                Variables.clipboardTextList.Add("[" + completedate + "]" + text);
                            }
                            else
                                allowCopy = true;
                        }


                        // do something with it
                    }
                    else if (iData.GetDataPresent(DataFormats.Bitmap))
                    {
                        
                        Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);   // Clipboard image 
                        Plaatje plaatje = new Plaatje(image,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
                        Variables.plaatjeList.Add(plaatje);
                        Variables.clipboardImageList.Add(image);
                        Variables.clipboardImageDate.Add(completedate);

                        lvImages.Items.Clear();
                        foreach (string t in Variables.clipboardImageDate)
                        {
                            lvImages.Items.Add(t);
                        }

                        // do something with it
                    }

                    

                    lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
                    lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
                    lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count);

                    if (linkText >= 2)
                        linkText = 0;
                    
                }
                catch (System.Runtime.InteropServices.ExternalException ex) { }
                catch (Exception ex) { }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Variables.type == "Text")
                bLayerFile.SaveTextFile(listView1);     
       
            if(Variables.type == "Images")            
                bLayerFile.SaveImageFile(lvImages,pictureBox1);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This option will delete the entire list. Are you sure?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Variables.type == "Text")
                {
                    Variables.clipboardTextList.Clear();
                    listView1.Items.Clear();
                }
                if (Variables.type == "Images")
                {
                    Variables.clipboardImageList.Clear();
                    Variables.clipboardImageDate.Clear();
                    lvImages.Items.Clear();
                    pictureBox1.BackgroundImage = null;
                }
            }



            lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
            lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
            lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnImages.Visible = false;
            btnText.Visible = true;

            //switcheroo the panels
            panel1.Location = new Point(1312,12);
            panel2.Location = new Point(12,12);

            lvImages.Items.Clear();
            foreach (string t in Variables.clipboardImageDate)
            {
                lvImages.Items.Add(t);
            }
            Variables.type = "Images";
            
            
            
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            btnText.Visible = false;
            btnImages.Visible = true;

            panel1.Location = new Point(12,12);
            panel2.Location = new Point(1312, 12);

            Variables.type = "Text";
        }

        private void lvImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvImages.SelectedItems.Count > 0)
            {
                //panel2.BackgroundImage = Variables.clipboardImageList[lvImages.Items.IndexOf(lvImages.SelectedItems[0])]; 
                
                //assign plaatjes
                /*Plaatje plat;
                foreach(Plaatje p in Variables.plaatjeList)
                {
                    plat = new Plaatje(Variables.clipboardImageList[1], 1, 1, 1);
                }*/
                pictureBox1.BackgroundImage = Variables.clipboardImageList[lvImages.Items.IndexOf(lvImages.SelectedItems[0])];


                if (!cbStretch.Checked)
                    pictureBox1.Size = Variables.clipboardImageList[lvImages.Items.IndexOf(lvImages.SelectedItems[0])].Size;
                else
                { //Stretching the image
                    pictureBox1.Size = new Size(994, 614);
                }
            }

        }




        public void updateListViews()
        {
            //images
            lvImages.Items.Clear();
            foreach (string t in Variables.clipboardImageDate)
            {
                lvImages.Items.Add(t);
            }


            //text

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (btnCreateShortcut.Text == "Stop ClipboardWatcher from starting up automatically")
            {
                bLayerFile.DeleteShortcut();
                DisableControls();
            }
            else
            {
                bLayerFile.CreateShortcut();
                DisableControls();
            }
        }

        public void DisableControls()
        {
            if (System.IO.File.Exists(Variables.StartupFolderPath + "ClipboardWatcher.lnk"))
                btnCreateShortcut.Text = "Stop ClipboardWatcher from starting up automatically";
            else
                btnCreateShortcut.Text = "Start ClipboardWatcher automatically on windows startup!";

            if (Variables.saveText)                            
                cbText.Checked = true;
            
            else                            
                cbText.Checked = false;
            

            if (Variables.saveImages)            
                cbImages.Checked = true;            
            else
                cbImages.Checked = false;            

            if (cbText.Checked)
            {                
                button3.Enabled = true;
            }
            else
            {                
                button3.Enabled = false;
            }

            if (cbImages.Checked)
            {                
                button4.Enabled = true;
            }
            else
            {                
                button4.Enabled = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.Show();
        }

        private void ClipboardIcon_BalloonTipShown(object sender, EventArgs e)
        {
            
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            createFolder();            
            
            //Save the files if the user selected to do so
            if(Variables.saveImages)
            {
                //there already exists a text file called copies text.txt , hmm.. gotta rename it then! 
                string[] filez = Directory.GetFiles(Variables.finalImagePath);//Get all the files in the text folder
                int length = (filez.Length) + 1;//amount of files in the text folder

                List<int> seconds = new List<int>();
                List<int> minutes = new List<int>();
                List<int> hours = new List<int>();

                foreach(Plaatje p in Variables.plaatjeList)
                {
                    //fill the 3 lists with the time the screenshot got taken
                    //when a image is saved to the clipboard a new Plaatje will be made and added to the plaatjeList with the image, the second,the minute, and the hour
                    //this foreach loops loops through those Plaatjes
                    seconds.Add(p.second);
                    minutes.Add(p.minute);
                    hours.Add(p.hour);
                }

                int count = 0;
                foreach(Image img in Variables.clipboardImageList)
                {
                    if (!System.IO.File.Exists(Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count]) + "-" + bLayerFile.FixMinutes(minutes[count]) + "-" + bLayerFile.FixSeconds(seconds[count]) + ").png"))
                    {
                        img.Save((Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count]) + "-" + bLayerFile.FixMinutes(minutes[count]) + "-" + bLayerFile.FixSeconds(seconds[count]) + ").png"));
                        length++;
                    }
                    else
                    {//This shouldn't happen, but oh well.                        
                        length++;
                        if (!System.IO.File.Exists(Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count]) + "-" + bLayerFile.FixMinutes(minutes[count]) + "-" + bLayerFile.FixSeconds(seconds[count]) + ").png"))
                            img.Save((Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count]) + "-" + bLayerFile.FixMinutes(minutes[count]) + "-" + bLayerFile.FixSeconds(seconds[count]) + ").png"));
                    }

                    count++;
                    
                }
                count = 0;
            }
            if(Variables.saveText)
            {
                if(listView1.Items.Count > 0)
                    bLayerFile.SaveTextFile(listView1, Variables.finalTextPath);
            }
        }

        public void createFolder()
        {                    
            string month = "";
            switch (DateTime.Now.Month)
            {
                case 1: month = "January";
                    break;
                case 2: month = "February";
                    break;
                case 3: month = "March";
                    break;
                case 4: month = "April";
                    break;
                case 5: month = "May";
                    break;
                case 6: month = "June";
                    break;
                case 7: month = "July";
                    break;
                case 8: month = "August";
                    break;
                case 9: month = "September";
                    break;
                case 10: month = "October";
                    break;
                case 11: month = "November";
                    break;
                case 12: month = "December";
                    break;
            }
            
            Variables.finalTextPath = Variables.textPath + "\\Text\\" + DateTime.Now.Year.ToString() + "\\" + month + "\\" + DateTime.Now.Day.ToString() + " " + month;
            Variables.finalImagePath = Variables.imagePath + "\\Images\\" + DateTime.Now.Year.ToString() + "\\" + month + "\\" + DateTime.Now.Day.ToString() + " " + month;

            if (Variables.saveText)
                if (!Directory.Exists(Variables.finalTextPath))
                    Directory.CreateDirectory(Variables.finalTextPath);

            if(Variables.saveImages)
                if (!Directory.Exists(Variables.finalImagePath))
                    Directory.CreateDirectory(Variables.finalImagePath);
        }

        private void ClipboardIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();

            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;                 
            ClipboardIcon.BalloonTipText = "Watches your clipboard.";
            this.BringToFront();

           


            
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
           
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (tbPathText.Text != "")
                Variables.textPath = tbPathText.Text;
            if (tbPathImages.Text != "")
                Variables.imagePath = tbPathImages.Text;

            if (this.WindowState == FormWindowState.Minimized)
            {                
                ClipboardIcon.Visible = true;
                ClipboardIcon.Text = "Watches your clipboard.";                 
                this.Hide();
            }

            
        }

        private void tmrHide_Tick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Hide();
            tmrHide.Stop();
        }

        private void cbText_CheckedChanged(object sender, EventArgs e)
        {

            if (cbText.Checked)
            {                
                button3.Enabled = true;
                Variables.saveText = true;
            }
            else
            {                
                button3.Enabled = false;
                Variables.saveText = false;                
            }

            bLayerFile.WriteSettings();
        }

        private void cbImages_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImages.Checked)
            {                
                button4.Enabled = true;
                Variables.saveImages = true;
            }
            else
            {                
                button4.Enabled = false;
                Variables.saveImages = false;
            }

            bLayerFile.WriteSettings();
        }

        private void tbPathText_Leave(object sender, EventArgs e)
        {                        
        }

        private void button3_Click_2(object sender, EventArgs e)
        {            
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            tbPathText.Text = bLayerFile.getUserSelectedPath();
            Variables.textPath = tbPathText.Text;

            bLayerFile.WriteSettings();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbPathImages.Text = bLayerFile.getUserSelectedPath();
            Variables.imagePath = tbPathImages.Text;

            bLayerFile.WriteSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbStretch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStretch.Checked)
                Variables.stretchImage = true;
            else
                Variables.stretchImage = false;


            pictureBox1.BackgroundImage = null;
            pictureBox1.Size = new Size(994, 614);

            if (lvImages.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lvImages.SelectedIndices.Count; i++)
                {
                    lvImages.Items[lvImages.SelectedIndices[i]].Selected = false;
                }
            }

            bLayerFile.WriteSettings();

            
        }

        private void lvImages_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Variables.clipboardImageList.RemoveAt(lvImages.SelectedItems[0].Index);
                lvImages.Items.RemoveAt(lvImages.SelectedItems[0].Index);

                lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
                lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
                lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count);
            }
        }


        





      
    }
}

