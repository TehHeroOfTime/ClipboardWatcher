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
    public class ResolutionManager
    {
        Form1 mainForm;
        BLFile bLayerFile;
        public ResolutionManager(Form1 frm)
        {
            mainForm = frm;
            bLayerFile = new BLFile();
        }
        
        public void ResetDefaultResolution()
        {
            ChangeResolution("1305,805");
        }
        public void ChangeResolution(string resolution)
        {        
            mainForm.pictureBox1.Image = null;
            if (resolution == "1305,805") //original
            {
                //[Sizes]
                mainForm.panel1.Size = new Size(1284,655);
                mainForm.panel2.Size = new Size(1284, 655);
                mainForm.pnlfiles.Size = new Size(1284, 655);

                mainForm.btnImages.Size = new Size(81, 64);
                mainForm.btnText.Size = new Size(81, 64);
                mainForm.btnFiles.Size = new Size(81, 64);

                mainForm.listView1.Size = new Size(1272, 620);
                mainForm.pictureBox1.Size = new Size(994, 614);
                mainForm.lvImages.Size = new Size(264, 589);
                mainForm.pnlImage.Size = new Size(1000, 620);
                mainForm.pnlfiles.Size = new Size(1284,655);

                mainForm.Size = new Size(1305, 805);
                
                //[Locations]
                mainForm.button1.Location = new Point(12, 695);
                mainForm.button2.Location = new Point(99, 695);
                mainForm.lblTextcopies.Location = new Point(186, 695);
                mainForm.lblImageCopies.Location = new Point(186, 713);
                mainForm.lblFilecopies.Location = new Point(186, 730);
                mainForm.lblOverallcopies.Location = new Point(186, 746);

                mainForm.cbStartup.Location = new Point(399, 672);
                mainForm.cbText.Location = new Point(399, 695);
                mainForm.cbImages.Location = new Point(399, 719);
                mainForm.cbFiles.Location = new Point(399, 742);

                mainForm.tbPathText.Location = new Point(583, 695);      mainForm.button3.Location = new Point(973, 694);
                mainForm.tbPathImages.Location = new Point(583, 717);    mainForm.button4.Location = new Point(973, 715);
                mainForm.tbPathFileNames.Location = new Point(583, 740); mainForm.button6.Location = new Point(973, 738);

                mainForm.btnFiles.Location = new Point(1032, 695);
                mainForm.btnText.Location = new Point(1119, 695);
                mainForm.btnImages.Location = new Point(1206, 695);

                mainForm.cbStretch.Location = new Point(8, 632);
                mainForm.cbUnique.Location = new Point(1164, 15);

                mainForm.listView1.Columns[1].Width = 260;
                mainForm.listView1.Columns[0].Width = 1000;

                mainForm.lvFiles.Columns[1].Width = 260;
                mainForm.lvFiles.Columns[0].Width = 1000;


                mainForm.lvFiles.Size = new Size(1272, 620);

                mainForm.lblVersion.Location = new Point(1221, 0);
            }
            else if (resolution == "1280,720")
            {
                //[Sizes]
                mainForm.panel1.Size = new Size(1240,550);
                mainForm.panel2.Size = new Size(1260, 570);
                mainForm.pnlfiles.Size = new Size(1240, 550);

                mainForm.listView1.Size = new Size(1234,515);
                mainForm.pictureBox1.Size = new Size(960, 488);
                mainForm.lvImages.Size = new Size(264, 483);
                mainForm.pnlImage.Size = new Size(963,504); //
                mainForm.pnlfiles.Size = new Size(1240, 550);

                mainForm.btnImages.Size = new Size(81, 64);
                mainForm.btnText.Size = new Size(81, 64);
                mainForm.btnFiles.Size = new Size(81, 64);


                mainForm.Size = new Size(1280, 720);

                //[Locations]
                mainForm.button1.Location = new Point(6,605);
                mainForm.button2.Location = new Point(93,605);
                mainForm.lblTextcopies.Location = new Point(180, 607);
                mainForm.lblImageCopies.Location = new Point(180, 623);
                mainForm.lblFilecopies.Location = new Point(180, 640);
                mainForm.lblOverallcopies.Location = new Point(180, 656);

                mainForm.cbStartup.Location = new Point(364, 582);
                mainForm.cbText.Location = new Point(364, 605);
                mainForm.cbImages.Location = new Point(364, 629);
                mainForm.cbFiles.Location = new Point(364, 652);

                mainForm.tbPathText.Location = new Point(548, 605); mainForm.button3.Location = new Point(938, 604);
                mainForm.tbPathImages.Location = new Point(548, 627); mainForm.button4.Location = new Point(938, 625);
                mainForm.tbPathFileNames.Location = new Point(548, 650); mainForm.button6.Location = new Point(938, 648);

                mainForm.btnFiles.Location = new Point(997, 605);
                mainForm.btnText.Location = new Point(1084, 605);
                mainForm.btnImages.Location = new Point(1171, 605);

                mainForm.cbStretch.Location = new Point(8, 519);
                mainForm.cbUnique.Location = new Point(1123, 15);

                mainForm.listView1.Columns[1].Width = 230;
                mainForm.listView1.Columns[0].Width = 1000;

                mainForm.lvFiles.Columns[1].Width = 230;
                mainForm.lvFiles.Columns[0].Width = 1000;


                mainForm.lvFiles.Size = new Size(1234, 515);
                
                mainForm.lblVersion.Location = new Point(1021, 0);

                
            }
            else if (resolution == "1000,600")
            {
                mainForm.Size = new Size(1000, 600);

                //[Sizes]
                mainForm.panel1.Size = new Size(928,457);
                mainForm.panel2.Size = new Size(928, 477);
                mainForm.pnlfiles.Size = new Size(928, 457);

                mainForm.lvFiles.Size = new Size(920, 417);
                mainForm.listView1.Size = new Size(920,417);
                mainForm.pictureBox1.Size = new Size(619, 414); 
                mainForm.lvImages.Size = new Size(264,389);
                mainForm.pnlImage.Size = new Size(625, 425);
                mainForm.pnlfiles.Size = new Size(928, 457);

                mainForm.btnImages.Size = new Size(44, 43);
                mainForm.btnText.Size = new Size(44, 43);
                mainForm.btnFiles.Size = new Size(44, 43);
                

                //[Locations]
                mainForm.button1.Location = new Point(12,492);
                mainForm.button2.Location = new Point(99, 492);
                mainForm.lblTextcopies.Location = new Point(186, 492);
                mainForm.lblImageCopies.Location = new Point(186, 510);
                mainForm.lblFilecopies.Location = new Point(186, 527);
                mainForm.lblOverallcopies.Location = new Point(186, 543);

                mainForm.cbStartup.Location = new Point(332,471);
                mainForm.cbText.Location = new Point(332, 493);
                mainForm.cbImages.Location = new Point(332, 516);
                mainForm.cbFiles.Location = new Point(332, 539);

                mainForm.tbPathText.Location = new Point(516,494); mainForm.button3.Location = new Point(906,493);
                mainForm.tbPathImages.Location = new Point(516, 516); mainForm.button4.Location = new Point(906, 514);
                mainForm.tbPathFileNames.Location = new Point(516, 539); mainForm.button6.Location = new Point(906, 537);

                mainForm.btnFiles.Location = new Point(938, 143);
                mainForm.btnText.Location = new Point(938, 94);
                mainForm.btnImages.Location = new Point(938, 44);

                mainForm.cbStretch.Location = new Point(8, 427); 
                mainForm.cbUnique.Location = new Point(1164, 15);

                mainForm.listView1.Columns[1].Width = 260;
                mainForm.listView1.Columns[0].Width = 655;

                mainForm.lvFiles.Columns[1].Width = 260;
                mainForm.lvFiles.Columns[0].Width = 655;



                
                
            }
            else //The user has changed the resolution in settings.ini , Resetting to default!
            {
                //[Sizes]
                mainForm.panel1.Size = new Size(1284, 655);
                mainForm.panel2.Size = new Size(1284, 655);
                mainForm.pnlfiles.Size = new Size(1284, 655);

                mainForm.btnImages.Size = new Size(81, 64);
                mainForm.btnText.Size = new Size(81, 64);
                mainForm.btnFiles.Size = new Size(81, 64);

                mainForm.listView1.Size = new Size(1272, 620);
                mainForm.pictureBox1.Size = new Size(994, 614);
                mainForm.lvImages.Size = new Size(264, 589);
                mainForm.pnlImage.Size = new Size(1000, 620);
                mainForm.pnlfiles.Size = new Size(1284, 655);

                mainForm.Size = new Size(1305, 805);

                //[Locations]
                mainForm.button1.Location = new Point(12, 695);
                mainForm.button2.Location = new Point(99, 695);
                mainForm.lblTextcopies.Location = new Point(186, 695);
                mainForm.lblImageCopies.Location = new Point(186, 713);
                mainForm.lblFilecopies.Location = new Point(186, 730);
                mainForm.lblOverallcopies.Location = new Point(186, 746);

                mainForm.cbStartup.Location = new Point(399, 672);
                mainForm.cbText.Location = new Point(399, 695);
                mainForm.cbImages.Location = new Point(399, 719);
                mainForm.cbFiles.Location = new Point(399, 742);

                mainForm.tbPathText.Location = new Point(583, 695); mainForm.button3.Location = new Point(973, 694);
                mainForm.tbPathImages.Location = new Point(583, 717); mainForm.button4.Location = new Point(973, 715);
                mainForm.tbPathFileNames.Location = new Point(583, 740); mainForm.button6.Location = new Point(973, 738);

                mainForm.btnFiles.Location = new Point(1032, 695);
                mainForm.btnText.Location = new Point(1119, 695);
                mainForm.btnImages.Location = new Point(1206, 695);

                mainForm.cbStretch.Location = new Point(8, 632);
                mainForm.cbUnique.Location = new Point(1164, 15);

                mainForm.listView1.Columns[1].Width = 260;
                mainForm.listView1.Columns[0].Width = 1000;

                mainForm.lvFiles.Columns[1].Width = 260;
                mainForm.lvFiles.Columns[0].Width = 1000;


                mainForm.lvFiles.Size = new Size(1272, 620);

                mainForm.lblVersion.Location = new Point(1221, 0);
            }

            mainForm.lblDelRecord.Location = new Point(mainForm.button1.Location.X, (mainForm.button1.Location.Y - 15));
            mainForm.lblVersion.Location = new Point((mainForm.Size.Width - (mainForm.lblVersion.Size.Width + 20)), 0);
            Variables.resolution = resolution;
            bLayerFile.WriteSettings();
        }
    }
}
