using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardWatcher
{
    public class Plaatje
    {
        public Image image;
        public int hour;
        public int minute;
        public int second;
        public Plaatje(Image _image,int _hour,int _minute,int _second)
        {
            this.image = _image;
            this.hour = _hour;
            this.minute = _minute;
            this.second = _second;
        }
        
    }
}
