namespace ClipboardWatcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.chText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbStretch = new System.Windows.Forms.CheckBox();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvImages = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTextcopies = new System.Windows.Forms.Label();
            this.lblImageCopies = new System.Windows.Forms.Label();
            this.lblOverallcopies = new System.Windows.Forms.Label();
            this.ClipboardIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cpwSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrHide = new System.Windows.Forms.Timer(this.components);
            this.cbText = new System.Windows.Forms.CheckBox();
            this.cbImages = new System.Windows.Forms.CheckBox();
            this.tbPathText = new System.Windows.Forms.TextBox();
            this.tbPathImages = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlfiles = new System.Windows.Forms.Panel();
            this.cbUnique = new System.Windows.Forms.CheckBox();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.cbStartup = new System.Windows.Forms.CheckBox();
            this.btnFiles = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.btnImages = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tbPathFileNames = new System.Windows.Forms.TextBox();
            this.cbFiles = new System.Windows.Forms.CheckBox();
            this.lblDelRecord = new System.Windows.Forms.Label();
            this.toolTipUnique = new System.Windows.Forms.ToolTip(this.components);
            this.lblFilecopies = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cpwSettings.SuspendLayout();
            this.pnlfiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chText,
            this.chDate});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1272, 620);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            this.listView1.Leave += new System.EventHandler(this.listView1_Leave);
            // 
            // chText
            // 
            this.chText.Text = "Text";
            this.chText.Width = 1000;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 260;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clipboard Text";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 655);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.cbStretch);
            this.panel2.Controls.Add(this.pnlImage);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lvImages);
            this.panel2.Location = new System.Drawing.Point(1313, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 655);
            this.panel2.TabIndex = 6;
            // 
            // cbStretch
            // 
            this.cbStretch.AutoSize = true;
            this.cbStretch.Location = new System.Drawing.Point(8, 632);
            this.cbStretch.Name = "cbStretch";
            this.cbStretch.Size = new System.Drawing.Size(91, 17);
            this.cbStretch.TabIndex = 22;
            this.cbStretch.Text = "Stretch image";
            this.toolTipUnique.SetToolTip(this.cbStretch, "Stretches the image to fit the screen");
            this.cbStretch.UseVisualStyleBackColor = true;
            this.cbStretch.CheckedChanged += new System.EventHandler(this.cbStretch_CheckedChanged);
            // 
            // pnlImage
            // 
            this.pnlImage.AutoScroll = true;
            this.pnlImage.Controls.Add(this.pictureBox1);
            this.pnlImage.Location = new System.Drawing.Point(273, 32);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(1000, 620);
            this.pnlImage.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(994, 614);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Clipboard Images";
            // 
            // lvImages
            // 
            this.lvImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvImages.FullRowSelect = true;
            this.lvImages.Location = new System.Drawing.Point(3, 32);
            this.lvImages.MultiSelect = false;
            this.lvImages.Name = "lvImages";
            this.lvImages.Size = new System.Drawing.Size(264, 589);
            this.lvImages.TabIndex = 6;
            this.lvImages.UseCompatibleStateImageBehavior = false;
            this.lvImages.View = System.Windows.Forms.View.Details;
            this.lvImages.SelectedIndexChanged += new System.EventHandler(this.lvImages_SelectedIndexChanged);
            this.lvImages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvImages_KeyUp);
            this.lvImages.Leave += new System.EventHandler(this.lvImages_Leave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 260;
            // 
            // lblTextcopies
            // 
            this.lblTextcopies.AutoSize = true;
            this.lblTextcopies.Location = new System.Drawing.Point(186, 695);
            this.lblTextcopies.Name = "lblTextcopies";
            this.lblTextcopies.Size = new System.Drawing.Size(91, 13);
            this.lblTextcopies.TabIndex = 10;
            this.lblTextcopies.Text = "Total text copies: ";
            // 
            // lblImageCopies
            // 
            this.lblImageCopies.AutoSize = true;
            this.lblImageCopies.Location = new System.Drawing.Point(186, 713);
            this.lblImageCopies.Name = "lblImageCopies";
            this.lblImageCopies.Size = new System.Drawing.Size(102, 13);
            this.lblImageCopies.TabIndex = 11;
            this.lblImageCopies.Text = "Total image copies: ";
            // 
            // lblOverallcopies
            // 
            this.lblOverallcopies.AutoSize = true;
            this.lblOverallcopies.Location = new System.Drawing.Point(186, 746);
            this.lblOverallcopies.Name = "lblOverallcopies";
            this.lblOverallcopies.Size = new System.Drawing.Size(102, 13);
            this.lblOverallcopies.TabIndex = 12;
            this.lblOverallcopies.Text = "Total overall copies:";
            // 
            // ClipboardIcon
            // 
            this.ClipboardIcon.BalloonTipText = "Watches your clipboard";
            this.ClipboardIcon.BalloonTipTitle = "ClipboardWatcher";
            this.ClipboardIcon.ContextMenuStrip = this.cpwSettings;
            this.ClipboardIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ClipboardIcon.Icon")));
            this.ClipboardIcon.Text = "ClipboardWatcher";
            this.ClipboardIcon.Visible = true;
            this.ClipboardIcon.BalloonTipShown += new System.EventHandler(this.ClipboardIcon_BalloonTipShown);
            this.ClipboardIcon.DoubleClick += new System.EventHandler(this.ClipboardIcon_DoubleClick);
            // 
            // cpwSettings
            // 
            this.cpwSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.cpwSettings.Name = "cpwSettings";
            this.cpwSettings.Size = new System.Drawing.Size(93, 26);
            this.cpwSettings.Text = "Exit";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::ClipboardWatcher.Properties.Resources.bin;
            this.exitToolStripMenuItem.MergeIndex = 0;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tmrHide
            // 
            this.tmrHide.Interval = 2000;
            this.tmrHide.Tick += new System.EventHandler(this.tmrHide_Tick);
            // 
            // cbText
            // 
            this.cbText.AutoSize = true;
            this.cbText.Location = new System.Drawing.Point(399, 695);
            this.cbText.Name = "cbText";
            this.cbText.Size = new System.Drawing.Size(153, 17);
            this.cbText.TabIndex = 14;
            this.cbText.Text = "Save all copied text on exit";
            this.cbText.UseVisualStyleBackColor = true;
            this.cbText.CheckedChanged += new System.EventHandler(this.cbText_CheckedChanged);
            // 
            // cbImages
            // 
            this.cbImages.AutoSize = true;
            this.cbImages.Location = new System.Drawing.Point(399, 719);
            this.cbImages.Name = "cbImages";
            this.cbImages.Size = new System.Drawing.Size(169, 17);
            this.cbImages.TabIndex = 15;
            this.cbImages.Text = "Save all copied images on exit";
            this.cbImages.UseVisualStyleBackColor = true;
            this.cbImages.CheckedChanged += new System.EventHandler(this.cbImages_CheckedChanged);
            // 
            // tbPathText
            // 
            this.tbPathText.Enabled = false;
            this.tbPathText.Location = new System.Drawing.Point(583, 695);
            this.tbPathText.Name = "tbPathText";
            this.tbPathText.Size = new System.Drawing.Size(384, 20);
            this.tbPathText.TabIndex = 16;
            this.tbPathText.Leave += new System.EventHandler(this.tbPathText_Leave);
            // 
            // tbPathImages
            // 
            this.tbPathImages.Enabled = false;
            this.tbPathImages.Location = new System.Drawing.Point(583, 717);
            this.tbPathImages.Name = "tbPathImages";
            this.tbPathImages.Size = new System.Drawing.Size(384, 20);
            this.tbPathImages.TabIndex = 17;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(1221, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(69, 13);
            this.lblVersion.TabIndex = 21;
            this.lblVersion.Text = "Version 2.6.0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(318, 674);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pnlfiles
            // 
            this.pnlfiles.Controls.Add(this.cbUnique);
            this.pnlfiles.Controls.Add(this.lvFiles);
            this.pnlfiles.Controls.Add(this.label4);
            this.pnlfiles.Location = new System.Drawing.Point(2603, 12);
            this.pnlfiles.Name = "pnlfiles";
            this.pnlfiles.Size = new System.Drawing.Size(1284, 655);
            this.pnlfiles.TabIndex = 23;
            // 
            // cbUnique
            // 
            this.cbUnique.AutoSize = true;
            this.cbUnique.Location = new System.Drawing.Point(1164, 15);
            this.cbUnique.Name = "cbUnique";
            this.cbUnique.Size = new System.Drawing.Size(115, 17);
            this.cbUnique.TabIndex = 2;
            this.cbUnique.Text = "Enable unique files";
            this.toolTipUnique.SetToolTip(this.cbUnique, "When selecting this there will be no duplicates in the list");
            this.cbUnique.UseVisualStyleBackColor = true;
            this.cbUnique.CheckedChanged += new System.EventHandler(this.cbUnique_CheckedChanged);
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.Location = new System.Drawing.Point(3, 32);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(1272, 620);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            this.lvFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvFiles_KeyUp);
            this.lvFiles.Leave += new System.EventHandler(this.lvFiles_Leave);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Text";
            this.columnHeader2.Width = 1000;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 260;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Text", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Clipboard Files";
            // 
            // cbStartup
            // 
            this.cbStartup.AutoSize = true;
            this.cbStartup.Location = new System.Drawing.Point(399, 672);
            this.cbStartup.Name = "cbStartup";
            this.cbStartup.Size = new System.Drawing.Size(294, 17);
            this.cbStartup.TabIndex = 24;
            this.cbStartup.Text = "Start ClipboardWatcher automatically on windows startup";
            this.cbStartup.UseVisualStyleBackColor = true;
            this.cbStartup.CheckedChanged += new System.EventHandler(this.cbStartup_CheckedChanged);
            // 
            // btnFiles
            // 
            this.btnFiles.BackgroundImage = global::ClipboardWatcher.Properties.Resources.fie;
            this.btnFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFiles.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnFiles.Location = new System.Drawing.Point(1032, 695);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(81, 64);
            this.btnFiles.TabIndex = 25;
            this.toolTipUnique.SetToolTip(this.btnFiles, "Files");
            this.btnFiles.UseVisualStyleBackColor = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ClipboardWatcher.Properties.Resources.save;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(12, 695);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 64);
            this.button1.TabIndex = 2;
            this.toolTipUnique.SetToolTip(this.button1, "Saves the list of text,file names or images");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::ClipboardWatcher.Properties.Resources.folder;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(973, 715);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 20);
            this.button4.TabIndex = 19;
            this.toolTipUnique.SetToolTip(this.button4, "Set a path");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::ClipboardWatcher.Properties.Resources.folder;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(973, 694);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 20);
            this.button3.TabIndex = 18;
            this.toolTipUnique.SetToolTip(this.button3, "Set a path");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_3);
            // 
            // btnText
            // 
            this.btnText.BackgroundImage = global::ClipboardWatcher.Properties.Resources.txtt;
            this.btnText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnText.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnText.Location = new System.Drawing.Point(1119, 695);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(81, 64);
            this.btnText.TabIndex = 9;
            this.toolTipUnique.SetToolTip(this.btnText, "Text");
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // btnImages
            // 
            this.btnImages.BackgroundImage = global::ClipboardWatcher.Properties.Resources.images;
            this.btnImages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImages.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnImages.Location = new System.Drawing.Point(1206, 695);
            this.btnImages.Name = "btnImages";
            this.btnImages.Size = new System.Drawing.Size(81, 64);
            this.btnImages.TabIndex = 4;
            this.toolTipUnique.SetToolTip(this.btnImages, "Images");
            this.btnImages.UseVisualStyleBackColor = true;
            this.btnImages.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::ClipboardWatcher.Properties.Resources.bin;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(99, 695);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 64);
            this.button2.TabIndex = 3;
            this.toolTipUnique.SetToolTip(this.button2, "Delete the entire list");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::ClipboardWatcher.Properties.Resources.folder;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.Location = new System.Drawing.Point(973, 738);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(33, 20);
            this.button6.TabIndex = 28;
            this.toolTipUnique.SetToolTip(this.button6, "Set a path");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tbPathFileNames
            // 
            this.tbPathFileNames.Enabled = false;
            this.tbPathFileNames.Location = new System.Drawing.Point(583, 740);
            this.tbPathFileNames.Name = "tbPathFileNames";
            this.tbPathFileNames.Size = new System.Drawing.Size(384, 20);
            this.tbPathFileNames.TabIndex = 27;
            // 
            // cbFiles
            // 
            this.cbFiles.AutoSize = true;
            this.cbFiles.Location = new System.Drawing.Point(399, 742);
            this.cbFiles.Name = "cbFiles";
            this.cbFiles.Size = new System.Drawing.Size(180, 17);
            this.cbFiles.TabIndex = 26;
            this.cbFiles.Text = "Save all copied filenames on exit";
            this.cbFiles.UseVisualStyleBackColor = true;
            this.cbFiles.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblDelRecord
            // 
            this.lblDelRecord.AutoSize = true;
            this.lblDelRecord.Location = new System.Drawing.Point(12, 670);
            this.lblDelRecord.Name = "lblDelRecord";
            this.lblDelRecord.Size = new System.Drawing.Size(146, 13);
            this.lblDelRecord.TabIndex = 29;
            this.lblDelRecord.Text = "Press DEL to delete a record!";
            // 
            // lblFilecopies
            // 
            this.lblFilecopies.AutoSize = true;
            this.lblFilecopies.Location = new System.Drawing.Point(186, 730);
            this.lblFilecopies.Name = "lblFilecopies";
            this.lblFilecopies.Size = new System.Drawing.Size(87, 13);
            this.lblFilecopies.TabIndex = 30;
            this.lblFilecopies.Text = "Total file copies: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 766);
            this.Controls.Add(this.lblFilecopies);
            this.Controls.Add(this.lblDelRecord);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.tbPathFileNames);
            this.Controls.Add(this.cbFiles);
            this.Controls.Add(this.btnFiles);
            this.Controls.Add(this.cbStartup);
            this.Controls.Add(this.pnlfiles);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbPathImages);
            this.Controls.Add(this.tbPathText);
            this.Controls.Add(this.cbImages);
            this.Controls.Add(this.cbText);
            this.Controls.Add(this.lblOverallcopies);
            this.Controls.Add(this.lblImageCopies);
            this.Controls.Add(this.lblTextcopies);
            this.Controls.Add(this.btnText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnImages);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Clipboard Watcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp_1);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cpwSettings.ResumeLayout(false);
            this.pnlfiles.ResumeLayout(false);
            this.pnlfiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ColumnHeader chText;
        public System.Windows.Forms.ColumnHeader chDate;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btnImages;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListView lvImages;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.Button btnText;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblTextcopies;
        public System.Windows.Forms.Label lblImageCopies;
        public System.Windows.Forms.Label lblOverallcopies;
        public System.Windows.Forms.Panel pnlImage;
        public System.Windows.Forms.NotifyIcon ClipboardIcon;
        public System.Windows.Forms.Timer tmrHide;
        public System.Windows.Forms.CheckBox cbText;
        public System.Windows.Forms.CheckBox cbImages;
        public System.Windows.Forms.TextBox tbPathText;
        public System.Windows.Forms.TextBox tbPathImages;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.ContextMenuStrip cpwSettings;
        public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.Label lblVersion;
        public System.Windows.Forms.CheckBox cbStretch;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Panel pnlfiles;
        public System.Windows.Forms.ListView lvFiles;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox cbStartup;
        public System.Windows.Forms.Button btnFiles;
        public System.Windows.Forms.Button button6;
        public System.Windows.Forms.TextBox tbPathFileNames;
        public System.Windows.Forms.CheckBox cbFiles;
        public System.Windows.Forms.Label lblDelRecord;
        public System.Windows.Forms.CheckBox cbUnique;
        public System.Windows.Forms.ToolTip toolTipUnique;
        public System.Windows.Forms.Label lblFilecopies;
    }
}

