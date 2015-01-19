namespace AmbiLED_HD
{
    partial class ColorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.ColorPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPic)).BeginInit();
            this.SuspendLayout();
            // 
            // ColorPic
            // 
            this.ColorPic.Image = global::AmbiLED_HD.Properties.Resources.led_color;
            this.ColorPic.Location = new System.Drawing.Point(0, 0);
            this.ColorPic.Name = "ColorPic";
            this.ColorPic.Size = new System.Drawing.Size(501, 303);
            this.ColorPic.TabIndex = 0;
            this.ColorPic.TabStop = false;
            this.ColorPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // ColorForm
            // 
            this.ClientSize = new System.Drawing.Size(502, 301);
            this.Controls.Add(this.ColorPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ColorForm";
            this.Text = "AmbiLED Color Select";
            ((System.ComponentModel.ISupportInitialize)(this.ColorPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ColorPic;


    }
}
