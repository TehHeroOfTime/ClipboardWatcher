﻿using ClipboardWatcher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        BLFile bLayerFile;
        Form2 f;
        Resolution frmResolution;
        ResolutionManager manager;
        public Form1()
        {
            Clipboard.Clear();
            f = new Form2();            
            InitializeComponent();
            bLayerFile = new BLFile();
            manager = new ResolutionManager(this);
            _clipboardViewerNext = SetClipboardViewer(this.Handle);      // Adds our form to the chain of c
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                Hide();
            }));

            this.KeyPreview = true;
            lblDelRecord.Visible = false;
            Variables.resolutionFormUp = false;
            

            //Remove hover over backcolors on the buttons
            btnFiles.BackColorChanged += (s, g) =>
            {
                button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            };

            btnText.BackColorChanged += (s, g) =>
            {
                button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            };
            btnImages.BackColorChanged += (s, g) =>
            {
                button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            };

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            

            bLayerFile.CreateSettingsFile();
            bLayerFile.ReadSettings();

            if (Variables.resolution != "")
            {
                List<string> resolution = Variables.resolution.Split(',').ToList<string>();
                this.Size = new Size(Convert.ToInt32(resolution[0]), Convert.ToInt32(resolution[1]));
            }
            else
                Variables.resolution = "1305,805";

            manager.ChangeResolution(Variables.resolution);

            bLayerFile.WriteSettings();    
            this.lblVersion.Location = new Point((this.Size.Width - (this.lblVersion.Size.Width + 20)), 0);


            tbPathText.Text = Variables.textPath + "\\ClipboardWatcher output\\Text";
            tbPathImages.Text = Variables.imagePath + "\\ClipboardWatcher output\\Images";
            tbPathFileNames.Text = Variables.fileNamePath + "\\ClipboardWatcher output\\Filenames";

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
            
            this.Hide();    


            foreach (Control c in this.Controls)
            {//Make buttons borderless
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.TabStop = false;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;                   
                }
            }            
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
            if(e.KeyCode == Keys.Delete && listView1.SelectedItems.Count > 0)
            {
                Variables.clipboardTextList.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);                    
            }

            

            lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
            lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
            lblFilecopies.Text = "Total file copies: " + (Variables.copiedFileNames.Count);
            lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count + Variables.copiedFileNames.Count); 
            
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
            if (!Variables.pause)
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
                            Plaatje plaatje = new Plaatje(image, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
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
                        else if (iData.GetDataPresent(DataFormats.FileDrop))
                        {
                            string[] copiedFile = (string[])iData.GetData(DataFormats.FileDrop);
                            foreach (string t in copiedFile)
                            {
                                if (Variables.enableUniqueFiles)
                                {
                                    int length = Variables.copiedFileNames.Count;
                                    if (length > 0 && Variables.copiedFileNames.Contains(t))
                                    {

                                    }
                                    else
                                    {
                                        Variables.copiedFileNames.Add(t);

                                        ListViewItem itm = new ListViewItem();
                                        itm.Text = t;
                                        itm.SubItems.Add(completedate);
                                        lvFiles.Items.Add(itm);
                                        Variables.clipboardFileNameList.Add("[" + completedate + "]" + t);
                                    }
                                }
                                else//not unique
                                {
                                    Variables.copiedFileNames.Add(t);

                                    ListViewItem itm = new ListViewItem();
                                    itm.Text = t;
                                    itm.SubItems.Add(completedate);
                                    lvFiles.Items.Add(itm);
                                    Variables.clipboardFileNameList.Add("[" + completedate + "]" + t);
                                }

                            }



                        }



                        lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
                        lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
                        lblFilecopies.Text = "Total file copies: " + (Variables.copiedFileNames.Count);
                        lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count + Variables.copiedFileNames.Count);

                        if (linkText >= 2)
                            linkText = 0;

                    }
                    catch (System.Runtime.InteropServices.ExternalException ex) { }
                    catch (Exception ex) { }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Variables.type == "Text")
                bLayerFile.SaveTextFile(listView1);

            if (Variables.type == "Filenames")
                bLayerFile.SaveTextFile(lvFiles);   
       
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
                if (Variables.type == "Filenames")
                {
                    Variables.clipboardFileNameList.Clear();
                    Variables.copiedFileNames.Clear();
                    lvFiles.Items.Clear();                    
                }
            }



            lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
            lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
            lblFilecopies.Text = "Total file copies: " + (Variables.copiedFileNames.Count);
            lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count + Variables.copiedFileNames.Count); 
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnImages.Enabled = false;
            btnText.Enabled = true;
            btnFiles.Enabled = true;

            //switcheroo the panels
            panel1.Location = new Point(1312,12);
            panel2.Location = new Point(12,12);
            pnlfiles.Location = new Point(2603, 12);

            lvImages.Items.Clear();
            foreach (string t in Variables.clipboardImageDate)
            {
                lvImages.Items.Add(t);
            }
            Variables.type = "Images";
            
            
            
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            btnImages.Enabled = true;
            btnText.Enabled = false;
            btnFiles.Enabled = true;

            panel1.Location = new Point(12,12);
            panel2.Location = new Point(1312, 12);
            pnlfiles.Location = new Point(2603, 12);
            
           

            Variables.type = "Text";
        }

        private void lvImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvImages.SelectedItems.Count > 0)
            {               
                pictureBox1.BackgroundImage = Variables.clipboardImageList[lvImages.Items.IndexOf(lvImages.SelectedItems[0])]; //put the image from the imagelist into the picturebox

                if (!cbStretch.Checked)
                    pictureBox1.Size = Variables.clipboardImageList[lvImages.Items.IndexOf(lvImages.SelectedItems[0])].Size; //Resize the picturebox to the size of the image
                else
                { //Stretching the image to the size of the current resolution
                    switch(Variables.resolution)
                    {
                        case "1000,600": pictureBox1.Size = new Size(619, 414);   
                            break;
                        case "1280,720": pictureBox1.Size = new Size(960, 488);
                            break;
                        case "1305,805": pictureBox1.Size = new Size(994, 614);   
                            break;
                    }
                                    
                }
            }

            if (lvImages.SelectedItems.Count > 0)
                lblDelRecord.Visible = true;
            else
            {
                lblDelRecord.Visible = false;
                pictureBox1.BackgroundImage = null;
                switch (Variables.resolution)
                {
                    case "1000,600": pictureBox1.Size = new Size(619, 414);
                        break;
                    case "1280,720": pictureBox1.Size = new Size(960, 488);
                        break;
                    case "1305,805": pictureBox1.Size = new Size(994, 614);
                        break;
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
        }

        public void DisableControls()
        {
            if (System.IO.File.Exists(Variables.StartupFolderPath + "ClipboardWatcher.lnk"))
                cbStartup.Checked = true;
            else
                cbStartup.Checked = false;

            if (Variables.enableUniqueFiles)
                cbUnique.Checked = true;
            else
                cbUnique.Checked = false;

            if (Variables.saveText)                            
                cbText.Checked = true;            
            else                            
                cbText.Checked = false;

            if (Variables.saveFileNames)
                cbFiles.Checked = true;
            else
                cbFiles.Checked = false;
            

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
            string t = Variables.finalImagePath;
            //Save text/filenames. Images will be saved in another form with a progress bar
            if (Variables.saveText)
            {
                if (listView1.Items.Count > 0)
                    bLayerFile.SaveTextFile(listView1, Variables.finalTextPath);
            }
            if (Variables.saveFileNames)
            {
                if (lvFiles.Items.Count > 0)
                    bLayerFile.SaveFileNamesFile(lvFiles, Variables.finalFileNamePath);
            }


            if (e.CloseReason != CloseReason.WindowsShutDown && e.CloseReason != CloseReason.TaskManagerClosing)
            {
                if (Variables.clipboardImageList.Count > 0 && Variables.saveImages)
                {
                    this.Hide();
                    f.Show();
                }
            }
            else
            {
                //Saving images without progressbar (Form2)
                if (Variables.saveImages && lvImages.Items.Count > 0)
                {

                    //there already exists a text file called copies text.txt , hmm.. gotta rename it then! 
                    string[] filez = Directory.GetFiles(Variables.finalImagePath);//Get all the files in the text folder
                    int length = (filez.Length) + 1;//amount of files in the text folder

                    List<int> seconds = new List<int>();
                    List<int> minutes = new List<int>();
                    List<int> hours = new List<int>();

                    foreach (Plaatje p in Variables.plaatjeList)
                    {
                        //fill the 3 lists with the time the screenshot got taken
                        //when a image is saved to the clipboard a new Plaatje will be made and added to the plaatjeList with the image, the second,the minute, and the hour
                        //this foreach loops loops through those Plaatjes
                        seconds.Add(p.second);
                        minutes.Add(p.minute);
                        hours.Add(p.hour);
                    }

                    int count = 0;
                    foreach (Image img in Variables.clipboardImageList)
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
                                img.Save((Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count]) + "-" + bLayerFile.FixMinutes(minutes[count]) + "-" + bLayerFile.FixSeconds(seconds[count]) + ") .png"));
                        }

                        count++;

                    }
                    count = 0;

                }
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
            Variables.finalTextPath = Variables.textPath + "\\ClipboardWatcher output\\Text\\" + DateTime.Now.Year.ToString() + "\\" + month + "\\" + DateTime.Now.Day.ToString() + " " + month;
            Variables.finalImagePath = Variables.imagePath + "\\ClipboardWatcher output\\Images\\" + DateTime.Now.Year.ToString() + "\\" + month + "\\" + DateTime.Now.Day.ToString() + " " + month;
            Variables.finalFileNamePath = Variables.fileNamePath + "\\ClipboardWatcher output\\Filenames\\" + DateTime.Now.Year.ToString() + "\\" + month + "\\" + DateTime.Now.Day.ToString() + " " + month;

            if (Variables.saveText && listView1.Items.Count > 0)
                if (!Directory.Exists(Variables.finalTextPath))
                    Directory.CreateDirectory(Variables.finalTextPath);

            if(Variables.saveImages && lvImages.Items.Count > 0)
                if (!Directory.Exists(Variables.finalImagePath))
                    Directory.CreateDirectory(Variables.finalImagePath);

            if (Variables.saveFileNames && lvFiles.Items.Count > 0)
                if (!Directory.Exists(Variables.finalFileNamePath))
                    Directory.CreateDirectory(Variables.finalFileNamePath);
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

            bLayerFile.ReadSettings();

            if (this.WindowState == FormWindowState.Minimized)
            {                
                ClipboardIcon.Visible = true;
                ClipboardIcon.Text = "ClipboardWatcher";                 
                this.Hide();
            }

            
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
            string path = bLayerFile.getUserSelectedPath();
            tbPathText.Text = path + "\\ClipboardWatcher output\\Text";
            Variables.textPath = path;

            bLayerFile.WriteSettings();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = bLayerFile.getUserSelectedPath();
            tbPathImages.Text = path + "\\ClipboardWatcher output\\Images";
            Variables.imagePath = path;

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
            switch (Variables.resolution)
            {
                case "1000,600": pictureBox1.Size = new Size(619, 414);
                    break;
                case "1280,720": pictureBox1.Size = new Size(960, 478);
                    break;
                case "1305,805": pictureBox1.Size = new Size(994, 614);
                    break;
            }            

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
            if (e.KeyCode == Keys.Delete && lvImages.SelectedItems.Count > 0)
            {//WHEN SELECTING AN IMAGE ARRAY EXCEPTION

                Variables.clipboardImageDate.RemoveAt(lvImages.SelectedItems[0].Index);
                Variables.clipboardImageList.RemoveAt(lvImages.SelectedItems[0].Index);
                lvImages.Items.RemoveAt(lvImages.SelectedItems[0].Index);

                pictureBox1.BackgroundImage = null;

                lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
                lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
                lblFilecopies.Text = "Total file copies: " + (Variables.copiedFileNames.Count);
                lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count + Variables.copiedFileNames.Count); 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in this.Controls)
                {                    
                    if(c is Label)
                    {
                        c.ForeColor = Color.White;
                        c.Font = new Font(c.Font, FontStyle.Bold);
                        c.BackColor = Color.Transparent;
                    }
                    //c.ForeColor = Color.White;

                    if (c is Button)
                    {
                        Button b = (Button)c;
                        b.TabStop = false;
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        c.Font = new Font(c.Font, FontStyle.Bold);
                    }                                                         
                }

                


                foreach (Control c in panel1.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.White;
                        c.Font = new Font(c.Font, FontStyle.Bold);
                        c.BackColor = Color.Transparent;
                    }
                    if (c is ListView)
                    {
                        c.BackColor = Color.DimGray;
                        c.ForeColor = Color.White;
                        c.Font = new Font(c.Font, FontStyle.Bold);

                    } 
                }

                foreach (Control c in panel2.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.White;
                        c.Font = new Font(c.Font, FontStyle.Bold);
                        c.BackColor = Color.Transparent;
                    }
                    if (c is ListView)
                    {
                        c.BackColor = Color.DimGray;
                        c.ForeColor = Color.White;
                        c.Font = new Font(c.Font, FontStyle.Bold);
                    } 
                }

                Image myImage = Resources.grahyblack;
                this.BackgroundImage = myImage;
                button1.BackColor = Color.DimGray;


                label1.BackColor = Color.Red;
            }
            catch { }
            
        }

        private void cbStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbStartup.Checked)
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

        private void btnFiles_Click(object sender, EventArgs e)
        {
            Variables.type = "Filenames";

            btnImages.Enabled = true;
            btnText.Enabled = true;
            btnFiles.Enabled = false;



            panel1.Location = new Point(1312, 12);
            panel2.Location = new Point(2603, 12);
            pnlfiles.Location = new Point(12, 12);            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string path = bLayerFile.getUserSelectedPath();
            tbPathFileNames.Text = path + "\\ClipboardWatcher output\\Filenames";
            Variables.fileNamePath = path;

            bLayerFile.WriteSettings();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFiles.Checked)
            {
                button6.Enabled = true;
                Variables.saveFileNames = true;
            }
            else
            {
                button6.Enabled = false;
                Variables.saveFileNames = false;
            }

            bLayerFile.WriteSettings();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)            
                lblDelRecord.Visible = true;            
            else
                lblDelRecord.Visible = false;
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count > 0)
                lblDelRecord.Visible = true;
            else
                lblDelRecord.Visible = false;
        }

        private void lvFiles_Leave(object sender, EventArgs e)
        {
            lblDelRecord.Visible = false;
        }

        private void lvImages_Leave(object sender, EventArgs e)
        {
            lblDelRecord.Visible = false;
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            lblDelRecord.Visible = false;
        }

        private void cbUnique_CheckedChanged(object sender, EventArgs e)
        {
            if(cbUnique.Checked)            
                Variables.enableUniqueFiles = true;            
            else
                Variables.enableUniqueFiles = false;
            bLayerFile.WriteSettings();
        }

        private void lvFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lvFiles.SelectedItems.Count > 0)
            {                
                Variables.copiedFileNames.RemoveAt(lvFiles.SelectedItems[0].Index);
                Variables.clipboardFileNameList.RemoveAt(lvFiles.SelectedItems[0].Index);
                lvFiles.Items.RemoveAt(lvFiles.SelectedItems[0].Index);
            }


            lblImageCopies.Text = "Total image copies: " + Variables.clipboardImageList.Count;
            lblTextcopies.Text = "Total text copies: " + Variables.clipboardTextList.Count;
            lblFilecopies.Text = "Total file copies: " + (Variables.copiedFileNames.Count);
            lblOverallcopies.Text = "Total overall copies: " + (Variables.clipboardImageList.Count + Variables.clipboardTextList.Count + Variables.copiedFileNames.Count); 
        }


        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !Variables.resolutionFormUp)
            {
                frmResolution = new Resolution(this);
                frmResolution.Show();
            }
        }

        private void pauseClipboardWatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Variables.pause)
            {
                Variables.pause = false;
                pauseClipboardWatcherToolStripMenuItem.Text = "Pause ClipboardWatcher";
                pauseClipboardWatcherToolStripMenuItem.Image = Properties.Resources.icon_pause_128;
                lblPause.Visible = false;
            }
            else
            {
                Variables.pause = true;
                lblPause.Visible = true;
                pauseClipboardWatcherToolStripMenuItem.Text = "Resume ClipboardWatcher";
                pauseClipboardWatcherToolStripMenuItem.Image = Properties.Resources.resume;
            }
        }


        





      
    }
}

