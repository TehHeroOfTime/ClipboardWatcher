using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardWatcher
{
    public partial class Resolution : Form
    {
        ResolutionManager manager;
        Form1 frm;
        BLFile bLayerFile;
        public Resolution(Form1 form)
        {
            InitializeComponent();
            frm = form;
            manager = new ResolutionManager(frm);
            bLayerFile = new BLFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Variables.resolution = "1305,805";
            manager.ChangeResolution(Variables.resolution);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Variables.resolution = "1280,720";
            manager.ChangeResolution(Variables.resolution);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Variables.resolution = "720,480";
            manager.ChangeResolution(Variables.resolution);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Variables.resolution = "1000,600";
            manager.ChangeResolution(Variables.resolution);            
            frm.cbStretch.Location = new Point(8, 427);

            frm.panel2.Size = new Size(928, 477);
            frm.lvImages.Location = new Point(3,32);
            frm.cbStretch.Location = new Point(8, 427);
            frm.panel2.Location = new Point(12, 12);
        }

        private void Resolution_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; 
            
            this.KeyPreview = true;
            Variables.resolutionFormUp = true;
        }

        private void Resolution_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Variables.resolutionFormUp = false;
                this.Hide();
                this.Dispose();
            }
        }

        private void Resolution_FormClosing(object sender, FormClosingEventArgs e)
        {
            Variables.resolutionFormUp = false;
        }

    }
}
