using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using IWshRuntimeLibrary;

namespace ClipboardWatcher
{
    public class BLFile
    {        
        SaveFileDialog log;
        FolderBrowserDialog folderLog;        
        IWshShortcut Shortcut;
        WshShell shell = new WshShell();
        public BLFile()
        {
            log = new SaveFileDialog();
            folderLog = new FolderBrowserDialog();
        }


        public string FixSeconds(int seconds)
        {
            if (seconds >= 0 && seconds < 10)
                return "0" + seconds;
            else
                return seconds.ToString();
        }
        public string FixMinutes(int minutes)
        {
            if (minutes >= 0 && minutes < 10)
                return "0" + minutes;
            else
                return minutes.ToString();
        }
        public string FixHours(int hours)
        {
            if (hours >= 0 && hours < 10)
                return "0" + hours;
            else
                return hours.ToString();
        }


        public void SaveTextFile(ListView lv)
        {
            //only selectable option will be .txt
            log.Filter = "Text Files | *.txt";

            if(log.ShowDialog() == DialogResult.OK)
            {
                foreach(string itm in Variables.clipboardFileNameList)
                {
                    System.IO.File.WriteAllLines(log.FileName + ".txt", Variables.clipboardFileNameList.ToArray());                    
                }
            }
        }
        public void SaveTextFile(ListView lv,string path)
        {
            //only selectable option will be .txt
            int i = 1;
            log.Filter = "Text Files | *.txt";
           // foreach (string itm in Variables.clipboardTextList)
            //{
                if (!System.IO.File.Exists(path + "\\" + "Copied text" + ".txt"))
                    System.IO.File.WriteAllLines(path + "\\" + "Copied text" + ".txt", Variables.clipboardTextList.ToArray());
                else
                {
                    //there already exists a text file called copies text.txt , hmm.. gotta rename it then! 
                    string[] filez = Directory.GetFiles(path);//Get all the files in the text folder
                    int length = filez.Length;//amount of files in the text folder

                    string finalName = "Copied text(" + length + ").txt";
                    System.IO.File.WriteAllLines(path + "\\" + finalName, Variables.clipboardTextList.ToArray());                                   
                }
                
            //}          
        }
        public void SaveFileNamesFile(ListView lv, string path)
        {
            //only selectable option will be .txt
            int i = 1;
            log.Filter = "Text Files | *.txt";
            // foreach (string itm in Variables.clipboardTextList)
            //{
            if (!System.IO.File.Exists(path + "\\" + "Copied text" + ".txt"))
                System.IO.File.WriteAllLines(path + "\\" + "Copied text" + ".txt", Variables.clipboardFileNameList.ToArray());
            else
            {
                //there already exists a text file called copies text.txt , hmm.. gotta rename it then! 
                string[] filez = Directory.GetFiles(path);//Get all the files in the text folder
                int length = filez.Length;//amount of files in the text folder

                string finalName = "Copied text(" + length + ").txt";
                System.IO.File.WriteAllLines(path + "\\" + finalName, Variables.clipboardFileNameList.ToArray());
            }

            //}          
        }
        public void SaveImageFile(ListView lv,PictureBox pb)
        {            
            log.Filter = "Png Image (.png)|*.png|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg";
            
            if (pb.BackgroundImage != null)
            {
                if (log.ShowDialog() == DialogResult.OK)
                {
                    pb.BackgroundImage.Save(log.FileName, ImageFormat.Png);
                }
            }
        }

        public void createFolder(string path)
        {
            if(!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        public string getUserSelectedPath()
        {
            if(folderLog.ShowDialog() == DialogResult.OK)
            {
                return folderLog.SelectedPath;
            }
            else
            {
                return "";
            }
            
        }

        public void DeleteShortcut()
        {
            if (System.IO.File.Exists(Variables.StartupFolderPath + "ClipboardWatcher.lnk"))
                System.IO.File.Delete(Variables.StartupFolderPath + "ClipboardWatcher.lnk");
            else            
                MessageBox.Show("File does not exist! \nHave you changed the name of the shortcut?");            
        }
        public void CreateShortcut()
        {
            try
            {
                    //Where do you want to create the shortcut + what is the name of the shortcut?
                    Shortcut = (IWshShortcut)shell.CreateShortcut(Variables.StartupFolderPath + "ClipboardWatcher" + ".lnk");

                    //What is the shortcut's target?
                    Shortcut.TargetPath = Application.StartupPath + "\\" + "ClipboardWatcher.exe";

                    //Tooltip
                    Shortcut.Description = "Shortcut of ClipboardWatcher";


                    Shortcut.Save();                               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong! \r\n Error code: \r\n \r\n " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateSettingsFile()
        {            
            if (!System.IO.Directory.Exists(Variables.UserProfile + @"\Documents\ClipboardWatcher Data"))
            {
                System.IO.Directory.CreateDirectory(Variables.UserProfile + @"\Documents\ClipboardWatcher Data");
                System.IO.Directory.CreateDirectory(Variables.UserProfile + @"\Documents\ClipboardWatcher Data\Text");
                System.IO.Directory.CreateDirectory(Variables.UserProfile + @"\Documents\ClipboardWatcher Data\Images");

                System.IO.File.Create(Variables.UserProfile + @"\Documents\ClipboardWatcher Data\Settings.ini");                
            }
        }

        public void WriteSettings()
        {

            try
            {
                if (System.IO.File.Exists(Variables.iniFile))
                    System.IO.File.WriteAllText(Variables.iniFile, ""); // clear the file before writing           


                using (FileStream fs = new FileStream(Variables.iniFile, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {                    
                    if (Variables.saveText)
                        sw.WriteLine("Save Text = true");
                    else
                        sw.WriteLine("Save Text = false");


                    if (Variables.saveImages)
                        sw.WriteLine("Save Images = true");
                    else
                        sw.WriteLine("Save Images = false");

                    if (Variables.saveFileNames)
                        sw.WriteLine("Save Filenames = true");
                    else
                        sw.WriteLine("Save Filenames = false");

                    if (Variables.uniqueFiles)
                        sw.WriteLine("Unique files = true");
                    else
                        sw.WriteLine("Unique files = false");

                    if (Variables.textPath != "" && Variables.textPath != null)
                        sw.WriteLine("Save path for text = [" + Variables.textPath + "]");
                    else
                        sw.WriteLine("Save path for text = ");

                    if (Variables.imagePath != "" && Variables.imagePath != null)
                        sw.WriteLine("Save path for images = [" + Variables.imagePath + "]");
                    else
                        sw.WriteLine("Save path for images = ");

                    if (Variables.imagePath != "" && Variables.imagePath != null)
                        sw.WriteLine("Save path for Filenames = [" + Variables.fileNamePath + "]");
                    else
                        sw.WriteLine("Save path for Filenames = ");

                    if (Variables.stretchImage)
                        sw.WriteLine("Stretch image = true");
                    else
                        sw.WriteLine("Stretch image = false");
                }
            }
            catch(IOException)
            {                
            }
        }
        public void ReadSettings()
        {
            try
            {
                Variables.iniFileLines.Clear(); // clear the list

                using (StreamReader read = new StreamReader(Variables.iniFile))
                {
                    while (!read.EndOfStream)//go through all the lines
                    {
                        Variables.iniFileLines.Add(read.ReadLine());//put them in a string list
                    }

                }

                if (Variables.iniFileLines.Contains("Save Text = true"))
                    Variables.saveText = true;
                else
                    Variables.saveText = false;

                if (Variables.iniFileLines.Contains("Save Images = true"))
                    Variables.saveImages = true;
                else
                    Variables.saveImages = false;

                if (Variables.iniFileLines.Contains("Save Filenames = true"))
                    Variables.saveFileNames = true;
                else
                    Variables.saveFileNames = false;

                if (Variables.iniFileLines.Contains("Unique files = true"))
                    Variables.uniqueFiles = true;
                else
                    Variables.uniqueFiles = false;


                if (Variables.iniFileLines.Contains("Stretch image = true"))
                    Variables.stretchImage = true;
                else
                    Variables.stretchImage = false;

                //[4] = text
                //[5] = images
                //[6] = filenames
                if (Variables.iniFileLines.Count >= 3)
                {
                    if (Variables.iniFileLines[4].Contains("Save path for text = ["))
                    {
                        string s = Variables.iniFileLines[4];
                        int start = s.IndexOf("[") + 1;
                        int end = s.IndexOf("]", start);
                        string result = s.Substring(start, end - start);

                        Variables.textPath = result;
                    }
                    else
                        Variables.textPath = Variables.defaultTextFolder; //default


                    if (Variables.iniFileLines[5].Contains("Save path for images = ["))
                    {
                        string s = Variables.iniFileLines[5];
                        int start = s.IndexOf("[") + 1;
                        int end = s.IndexOf("]", start);
                        string result = s.Substring(start, end - start);

                        Variables.imagePath = result;
                    }
                    else
                        Variables.imagePath = Variables.defaultImagesFolder; //default

                    if (Variables.iniFileLines[6].Contains("Save path for Filenames = ["))
                    {
                        string s = Variables.iniFileLines[6];
                        int start = s.IndexOf("[") + 1;
                        int end = s.IndexOf("]", start);
                        string result = s.Substring(start, end - start);

                        Variables.fileNamePath = result;
                    }
                    else
                        Variables.fileNamePath = Variables.defaultFileNamesFolder; //default
                }
                else
                {
                    Variables.textPath = Variables.defaultTextFolder; //default
                    Variables.imagePath = Variables.defaultImagesFolder; //default
                    Variables.fileNamePath = Variables.defaultFileNamesFolder; //default
                }
            }            
            catch(IOException)
            {
                AutoClosingMessageBox.Show("Finished Preparing ClipboardWatcher for first use!\r\nClosing ClipboardWatcher in 5 seconds, Please restart ClipboardWatcher!", "Restarting", 5000);
                Application.Exit();                
            }
        }
    }
}
