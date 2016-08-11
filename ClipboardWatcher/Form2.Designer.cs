namespace ClipboardWatcher
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblImages = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tmrCloseApp = new System.Windows.Forms.Timer(this.components);
            this.tmrStartSaving = new System.Windows.Forms.Timer(this.components);
            this.tmrNextImage = new System.Windows.Forms.Timer(this.components);
            this.tmrStartCalculating = new System.Windows.Forms.Timer(this.components);
            this.lblProcent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblImages
            // 
            this.lblImages.AutoSize = true;
            this.lblImages.Location = new System.Drawing.Point(65, 24);
            this.lblImages.Name = "lblImages";
            this.lblImages.Size = new System.Drawing.Size(125, 13);
            this.lblImages.TabIndex = 0;
            this.lblImages.Text = "Calculating image sizes...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 53);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // tmrCloseApp
            // 
            this.tmrCloseApp.Interval = 1000;
            this.tmrCloseApp.Tick += new System.EventHandler(this.tmrCloseApp_Tick);
            // 
            // tmrStartSaving
            // 
            this.tmrStartSaving.Interval = 300;
            this.tmrStartSaving.Tick += new System.EventHandler(this.tmrStartSaving_Tick);
            // 
            // tmrNextImage
            // 
            this.tmrNextImage.Tick += new System.EventHandler(this.tmrNextImage_Tick);
            // 
            // tmrStartCalculating
            // 
            this.tmrStartCalculating.Tick += new System.EventHandler(this.tmrStartCalculating_Tick);
            // 
            // lblProcent
            // 
            this.lblProcent.AutoSize = true;
            this.lblProcent.BackColor = System.Drawing.Color.Transparent;
            this.lblProcent.Location = new System.Drawing.Point(238, 57);
            this.lblProcent.Name = "lblProcent";
            this.lblProcent.Size = new System.Drawing.Size(21, 13);
            this.lblProcent.TabIndex = 2;
            this.lblProcent.Text = "0%";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(271, 113);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblProcent);
            this.Controls.Add(this.lblImages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saving images";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImages;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer tmrCloseApp;
        private System.Windows.Forms.Timer tmrStartSaving;
        private System.Windows.Forms.Timer tmrNextImage;
        private System.Windows.Forms.Timer tmrStartCalculating;
        private System.Windows.Forms.Label lblProcent;
    }
}