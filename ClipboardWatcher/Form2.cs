using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardWatcher
{
    public partial class Form2 : Form
    {
        BLFile bLayerFile;
        bool start = false;
        int imageCount = 1;
        int totalImageCount;
        int count = 1;
        double value = 0;
        int processedImages = 0;

        double procent;


        List<int> seconds = new List<int>();
        List<int> minutes = new List<int>();
        List<int> hours = new List<int>();

        string[] filez;//Get all the files in the text folder
        int length;//amount of files in the text folder


        public Form2()
        {
            InitializeComponent();
            bLayerFile = new BLFile();
            
        }

        private void progressBar1_MarginChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void tmrCloseApp_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 100 || imageCount >= Variables.clipboardImageList.Count)
            {                                
                Application.Exit();
            }            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            totalImageCount = Variables.clipboardImageList.Count;
            filez = Directory.GetFiles(Variables.finalImagePath);//Get all the files in the text folder
            length = (filez.Length) + 1;//amount of files in the text folder

            foreach (Plaatje p in Variables.plaatjeList)
            {
                //fill the 3 lists with the time the screenshot got taken
                //when a image is saved to the clipboard a new Plaatje will be made and added to the plaatjeList with the image, the second,the minute, and the hour
                //this foreach loops loops through those Plaatjes
                seconds.Add(p.second);
                minutes.Add(p.minute);
                hours.Add(p.hour);
            }

           

            tmrCloseApp.Start();
            
            tmrStartCalculating.Start();
            
        }

        public void CalcImageSize()
        {
            lblImages.Text = "Calculating image sizes...";


            Variables.totalImagesSize = 0;//Calculating the total size

            foreach (Image img in Variables.clipboardImageList)
            {
                using (var ms = new MemoryStream(100000000)) // estimatedLength can be original fileLength
                {
                    if (img != null)
                        img.Save(ms, ImageFormat.Png); // save image to stream in png format

                    Variables.totalImagesSize = Variables.totalImagesSize + ms.Length;
                    Variables.imageSizeList.Add(ms.Length);
                }
            }
        }
        public void SaveImages() //TODO: Get size of current image :/
        {

            //Save the files if the user selected to do so
            if (Variables.saveImages)
            {
                //there already exists a text file called copies text.txt , hmm.. gotta rename it then! 

                lblImages.Text = count + "/" + Variables.clipboardImageList.Count + " Images saved(" + CalculatePercentage(count) + "%) [" + Variables.totalImagesSize + "]";

                count = 0;
            }
           
        }


        public double CalculatePercentage(int imageCount)
        {
            double value = (double)Variables.imageSizeList[imageCount] / Variables.totalImagesSize * 100;
            procent = procent + value;
            if (procent > 100)
                procent = 100;
            return value;
        }

        private void tmrStartSaving_Tick(object sender, EventArgs e)
        {
            //lblImages.Location = new Point(65, 24);
            tmrStartSaving.Stop();
            tmrNextImage.Start();
        }
        public void RemoveNullValues()
        {
            int count = 0;
            int removedNulls = 0;
            List<int> potentionalNulls = new List<int>();            
            foreach (Image img in Variables.clipboardImageList)
            {
                if (img == null)
                {
                    potentionalNulls.Add(count);
                }
                count++;
            }
            foreach (int t in potentionalNulls)
            {
                //When you remove an null image from the list, [3] will become [2]. You thought [3] contained a null and it did.
                //When you deleted a null on [0] the [3] became [2]. if you try to remove [3] you will delete a image instead of a null.
                //Whenever i delete a null i up the counter removedNulls by 1. if it removed 2 nulls, the next removal will be variable t - 2.
                //for example, [6] is null, but we already removed 2 nulls, so it's new spot will be [4]. so, you do RemoveAt(t(which is 6) - removedNulls(which is 2)) results in (4)
                //This applies for all the possible nulls in the list. 
                

                if(removedNulls > 0)                
                    Variables.clipboardImageList.RemoveAt(t - removedNulls); //Remove those Null images!
                else
                    Variables.clipboardImageList.RemoveAt(t); //Remove those Null images!


                removedNulls++;
            }
        }
        private void tmrNextImage_Tick(object sender, EventArgs e)
        {
            try
            {
                lblImages.Location = new Point(65, 24);
                if (!System.IO.File.Exists(Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count -1]) + "-" + bLayerFile.FixMinutes(minutes[count -1]) + "-" + bLayerFile.FixSeconds(seconds[count -1]) + ").png"))
                {
                    if (imageCount <= totalImageCount)
                    {
                        Variables.clipboardImageList[imageCount -1].Save((Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count - 1]) + "-" + bLayerFile.FixMinutes(minutes[count - 1]) + "-" + bLayerFile.FixSeconds(seconds[count - 1]) + ").png"));
                        length++;
                        imageCount++;
                    }
                }
                else
                {//This shouldn't happen, but oh well.                        
                    length++;
                    if (!System.IO.File.Exists(Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count - 1]) + "-" + bLayerFile.FixMinutes(minutes[count - 1]) + "-" + bLayerFile.FixSeconds(seconds[count - 1]) + ").png"))
                    {
                        if (imageCount <= totalImageCount)
                        {
                            Variables.clipboardImageList[imageCount -1].Save((Variables.finalImagePath + "\\" + length + " (" + bLayerFile.FixHours(hours[count - 1]) + "-" + bLayerFile.FixMinutes(minutes[count - 1]) + "-" + bLayerFile.FixSeconds(seconds[count - 1]) + ").png"));
                            imageCount++;
                        }
                    }
                }

                count++;
                if (count > hours.Count)
                    count = hours.Count -1;

                lblImages.Text = count + "/" + Variables.clipboardImageList.Count + " Images saved(" + (int)Math.Ceiling(procent) +"%)";
                value = value + CalculatePercentage(count);
                progressBar1.Value = (int)Math.Ceiling(procent);
                
            }
            catch { }
        }

        private void tmrStartCalculating_Tick(object sender, EventArgs e)
        {
            RemoveNullValues();
            CalcImageSize();            

            //Completed calculating. Stop this timer, continue with saving the images
            lblImages.Location = new Point(25, 24);
            lblImages.Text = "Done Calculating. preparing image saving...";
            tmrStartCalculating.Stop();
            tmrStartSaving.Start();
        }
    }
}
