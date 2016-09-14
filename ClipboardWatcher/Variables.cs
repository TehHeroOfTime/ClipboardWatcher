using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardWatcher
{
    public class Variables
    {
        private static string _fileSavePath;

        public static List<string> clipboardTextList = new List<string>();
        public static List<string> clipboardFileNameList = new List<string>();

        public static List<Image> clipboardImageList = new List<Image>();
        public static List<Plaatje> plaatjeList = new List<Plaatje>();
        public static List<string> clipboardImageDate = new List<string>();

        public static List<long> imageSizeList = new List<long>();

        public static List<string> copiedFileNames = new List<string>();

        public static List<string> iniFileLines = new List<string>();

        public static string UserProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
        public static string StartupFolderPath = UserProfile + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\";

        public static string iniFile = UserProfile + @"\Documents\ClipboardWatcher Data\Settings.ini";
        public static string defaultTextFolder = UserProfile + @"\Documents\ClipboardWatcher Data";
        public static string defaultImagesFolder = UserProfile + @"\Documents\ClipboardWatcher Data";
        public static string defaultFileNamesFolder = UserProfile + @"\Documents\ClipboardWatcher Data";

        public static bool stretchImage;
        public static bool enableUniqueFiles;

        public static string textPath;
        public static string imagePath;
        public static string fileNamePath;
        

        public static string finalTextPath;
        public static string finalImagePath;
        public static string finalFileNamePath;

        public static bool saveText;
        public static bool saveImages;
        public static bool saveFileNames;

        public static int restartSeconds;

        private static string _type;

        public static long totalImagesSize;
        public static long savedImagesSize;

        public static string resolution = "1305, 805";
        public static bool resolutionFormUp;

        public static bool pause;

        public static string fileSavePath
        {
            get { return _fileSavePath; }
            set { _fileSavePath = value; }
        }


        public static string type
        {
            get { return _type; }
            set { _type = value; }
        }
        

    }
}
