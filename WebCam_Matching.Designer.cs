namespace Self_Driving_Car
{
    partial class WebCam_Matching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebCam_Matching));
            this.view_imageBox = new Emgu.CV.UI.ImageBox();
            this.Scence_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.To_Find_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Instrucation_textBox = new System.Windows.Forms.TextBox();
            this.instrucation_label = new System.Windows.Forms.Label();
            this.Webcam_Activate_CheckBox = new System.Windows.Forms.CheckBox();
            this.txtdistance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Found_image_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Leftbtn = new System.Windows.Forms.Button();
            this.Forwardbtn = new System.Windows.Forms.Button();
            this.Backwordbtn = new System.Windows.Forms.Button();
            this.Rightbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.view_imageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // view_imageBox
            // 
            this.view_imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.view_imageBox.Enabled = false;
            this.view_imageBox.Location = new System.Drawing.Point(21, 179);
            this.view_imageBox.Name = "view_imageBox";
            this.view_imageBox.Size = new System.Drawing.Size(960, 480);
            this.view_imageBox.TabIndex = 2;
            this.view_imageBox.TabStop = false;
            // 
            // Scence_openFileDialog
            // 
            this.Scence_openFileDialog.FileName = "openFileDialog1";
            // 
            // To_Find_openFileDialog
            // 
            this.To_Find_openFileDialog.FileName = "openFileDialog2";
            // 
            // Instrucation_textBox
            // 
            this.Instrucation_textBox.BackColor = System.Drawing.Color.Black;
            this.Instrucation_textBox.ForeColor = System.Drawing.Color.Red;
            this.Instrucation_textBox.Location = new System.Drawing.Point(177, 23);
            this.Instrucation_textBox.Multiline = true;
            this.Instrucation_textBox.Name = "Instrucation_textBox";
            this.Instrucation_textBox.ReadOnly = true;
            this.Instrucation_textBox.Size = new System.Drawing.Size(500, 50);
            this.Instrucation_textBox.TabIndex = 20;
            this.Instrucation_textBox.Text = "check the webcam_Activation to start the recognetion";
            // 
            // instrucation_label
            // 
            this.instrucation_label.AutoSize = true;
            this.instrucation_label.Location = new System.Drawing.Point(46, 38);
            this.instrucation_label.Name = "instrucation_label";
            this.instrucation_label.Size = new System.Drawing.Size(100, 17);
            this.instrucation_label.TabIndex = 15;
            this.instrucation_label.Text = "Instrucations : ";
            // 
            // Webcam_Activate_CheckBox
            // 
            this.Webcam_Activate_CheckBox.AutoSize = true;
            this.Webcam_Activate_CheckBox.Location = new System.Drawing.Point(85, 88);
            this.Webcam_Activate_CheckBox.Name = "Webcam_Activate_CheckBox";
            this.Webcam_Activate_CheckBox.Size = new System.Drawing.Size(142, 21);
            this.Webcam_Activate_CheckBox.TabIndex = 16;
            this.Webcam_Activate_CheckBox.Text = "Webcam_Activate";
            this.Webcam_Activate_CheckBox.UseVisualStyleBackColor = true;
            this.Webcam_Activate_CheckBox.CheckedChanged += new System.EventHandler(this.Webcam_Activate_CheckBox_CheckedChanged);
            // 
            // txtdistance
            // 
            this.txtdistance.Location = new System.Drawing.Point(123, 17);
            this.txtdistance.Name = "txtdistance";
            this.txtdistance.Size = new System.Drawing.Size(129, 24);
            this.txtdistance.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Infrared Sensor :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Found_image_textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Instrucation_textBox);
            this.groupBox1.Controls.Add(this.instrucation_label);
            this.groupBox1.Controls.Add(this.Webcam_Activate_CheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 146);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Controls";
            // 
            // Found_image_textBox
            // 
            this.Found_image_textBox.Location = new System.Drawing.Point(551, 86);
            this.Found_image_textBox.Name = "Found_image_textBox";
            this.Found_image_textBox.Size = new System.Drawing.Size(100, 24);
            this.Found_image_textBox.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Found Image Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Leftbtn);
            this.groupBox2.Controls.Add(this.Forwardbtn);
            this.groupBox2.Controls.Add(this.Backwordbtn);
            this.groupBox2.Controls.Add(this.Rightbtn);
            this.groupBox2.Controls.Add(this.txtdistance);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(750, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 146);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Robot Controls";
            // 
            // Leftbtn
            // 
            this.Leftbtn.Location = new System.Drawing.Point(75, 77);
            this.Leftbtn.Name = "Leftbtn";
            this.Leftbtn.Size = new System.Drawing.Size(75, 41);
            this.Leftbtn.TabIndex = 33;
            this.Leftbtn.Text = "Left";
            this.Leftbtn.UseVisualStyleBackColor = true;
            this.Leftbtn.Click += new System.EventHandler(this.Leftbtn_Click_1);
            // 
            // Forwardbtn
            // 
            this.Forwardbtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Forwardbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.Forwardbtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Forwardbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Forwardbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Forwardbtn.Location = new System.Drawing.Point(156, 47);
            this.Forwardbtn.Name = "Forwardbtn";
            this.Forwardbtn.Size = new System.Drawing.Size(96, 45);
            this.Forwardbtn.TabIndex = 32;
            this.Forwardbtn.TabStop = false;
            this.Forwardbtn.Text = "Forward";
            this.Forwardbtn.UseMnemonic = false;
            this.Forwardbtn.UseVisualStyleBackColor = false;
            this.Forwardbtn.Click += new System.EventHandler(this.Forwardbtn_Click);
            // 
            // Backwordbtn
            // 
            this.Backwordbtn.Location = new System.Drawing.Point(156, 98);
            this.Backwordbtn.Name = "Backwordbtn";
            this.Backwordbtn.Size = new System.Drawing.Size(96, 39);
            this.Backwordbtn.TabIndex = 31;
            this.Backwordbtn.Text = "Backword";
            this.Backwordbtn.UseVisualStyleBackColor = true;
            this.Backwordbtn.Click += new System.EventHandler(this.Backwordbtn_Click);
            // 
            // Rightbtn
            // 
            this.Rightbtn.Location = new System.Drawing.Point(258, 77);
            this.Rightbtn.Name = "Rightbtn";
            this.Rightbtn.Size = new System.Drawing.Size(75, 41);
            this.Rightbtn.TabIndex = 30;
            this.Rightbtn.Text = "Right";
            this.Rightbtn.UseVisualStyleBackColor = true;
            this.Rightbtn.Click += new System.EventHandler(this.Rightbtn_Click);
            // 
            // WebCam_Matching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1168, 868);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.view_imageBox);
            this.Name = "WebCam_Matching";
            this.Text = "WebCam Matching";
            this.Load += new System.EventHandler(this.WebCam_Matching_Load);
            this.Resize += new System.EventHandler(this.WebCam_Matching_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.view_imageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox view_imageBox;
        private System.Windows.Forms.OpenFileDialog Scence_openFileDialog;
        private System.Windows.Forms.OpenFileDialog To_Find_openFileDialog;
        private System.Windows.Forms.TextBox Instrucation_textBox;
        private System.Windows.Forms.Label instrucation_label;
        private System.Windows.Forms.CheckBox Webcam_Activate_CheckBox;
        private System.Windows.Forms.TextBox txtdistance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Leftbtn;
        private System.Windows.Forms.Button Forwardbtn;
        private System.Windows.Forms.Button Backwordbtn;
        private System.Windows.Forms.Button Rightbtn;
        private System.Windows.Forms.TextBox Found_image_textBox;
        private System.Windows.Forms.Label label2;
    }
}

