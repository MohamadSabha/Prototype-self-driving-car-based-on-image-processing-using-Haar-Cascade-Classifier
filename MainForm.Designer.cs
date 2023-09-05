namespace Self_Driving_Car
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Two_Images_Matchingbtn = new System.Windows.Forms.Button();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.Webcam_Matchingbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Two_Images_Matchingbtn
            // 
            this.Two_Images_Matchingbtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Two_Images_Matchingbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Two_Images_Matchingbtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Two_Images_Matchingbtn.FlatAppearance.BorderSize = 4;
            this.Two_Images_Matchingbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Two_Images_Matchingbtn.Font = new System.Drawing.Font("Urdu Typesetting", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Two_Images_Matchingbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Two_Images_Matchingbtn.Location = new System.Drawing.Point(416, 73);
            this.Two_Images_Matchingbtn.Name = "Two_Images_Matchingbtn";
            this.Two_Images_Matchingbtn.Size = new System.Drawing.Size(387, 103);
            this.Two_Images_Matchingbtn.TabIndex = 0;
            this.Two_Images_Matchingbtn.Text = "Two Images Matching";
            this.Two_Images_Matchingbtn.UseVisualStyleBackColor = false;
            this.Two_Images_Matchingbtn.Click += new System.EventHandler(this.Two_Images_Matchingbtn_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Exit_btn.FlatAppearance.BorderSize = 4;
            this.Exit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Exit_btn.Font = new System.Drawing.Font("Urdu Typesetting", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn.Location = new System.Drawing.Point(416, 337);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(387, 103);
            this.Exit_btn.TabIndex = 1;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = false;
            // 
            // Webcam_Matchingbtn
            // 
            this.Webcam_Matchingbtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Webcam_Matchingbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Webcam_Matchingbtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Webcam_Matchingbtn.FlatAppearance.BorderSize = 4;
            this.Webcam_Matchingbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Webcam_Matchingbtn.Font = new System.Drawing.Font("Urdu Typesetting", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Webcam_Matchingbtn.Location = new System.Drawing.Point(416, 198);
            this.Webcam_Matchingbtn.Name = "Webcam_Matchingbtn";
            this.Webcam_Matchingbtn.Size = new System.Drawing.Size(387, 103);
            this.Webcam_Matchingbtn.TabIndex = 3;
            this.Webcam_Matchingbtn.Text = "Webcam Matching";
            this.Webcam_Matchingbtn.UseVisualStyleBackColor = false;
            this.Webcam_Matchingbtn.Click += new System.EventHandler(this.Webcam_Matchingbtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1317, 662);
            this.Controls.Add(this.Webcam_Matchingbtn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Two_Images_Matchingbtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Two_Images_Matchingbtn;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.Button Webcam_Matchingbtn;
    }
}