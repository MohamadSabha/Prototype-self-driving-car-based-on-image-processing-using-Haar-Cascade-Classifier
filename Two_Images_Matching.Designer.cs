namespace Self_Driving_Car
{
    partial class Two_Images_Matching
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
            this.ToFind_text = new System.Windows.Forms.TextBox();
            this.Scence_text = new System.Windows.Forms.TextBox();
            this.Scence_btn = new System.Windows.Forms.Button();
            this.ToFind_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Perform_MAtching_btn = new System.Windows.Forms.Button();
            this.Scence_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.To_Find_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Show_MachLine_Checkbox = new System.Windows.Forms.CheckBox();
            this.show_KeyPoints_checkBox = new System.Windows.Forms.CheckBox();
            this.Instructionslbl = new System.Windows.Forms.Label();
            this.Instruction_textBox = new System.Windows.Forms.TextBox();
            this.view_imageBox = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.view_imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ToFind_text
            // 
            this.ToFind_text.Location = new System.Drawing.Point(317, 95);
            this.ToFind_text.Name = "ToFind_text";
            this.ToFind_text.ReadOnly = true;
            this.ToFind_text.Size = new System.Drawing.Size(525, 24);
            this.ToFind_text.TabIndex = 18;
            // 
            // Scence_text
            // 
            this.Scence_text.Location = new System.Drawing.Point(317, 37);
            this.Scence_text.Name = "Scence_text";
            this.Scence_text.ReadOnly = true;
            this.Scence_text.Size = new System.Drawing.Size(525, 24);
            this.Scence_text.TabIndex = 17;
            // 
            // Scence_btn
            // 
            this.Scence_btn.Location = new System.Drawing.Point(49, 12);
            this.Scence_btn.Name = "Scence_btn";
            this.Scence_btn.Size = new System.Drawing.Size(130, 49);
            this.Scence_btn.TabIndex = 13;
            this.Scence_btn.Text = "Brows Scence Image";
            this.Scence_btn.UseVisualStyleBackColor = true;
            this.Scence_btn.Click += new System.EventHandler(this.Scence_btn_Click);
            // 
            // ToFind_btn
            // 
            this.ToFind_btn.Location = new System.Drawing.Point(49, 83);
            this.ToFind_btn.Name = "ToFind_btn";
            this.ToFind_btn.Size = new System.Drawing.Size(130, 48);
            this.ToFind_btn.TabIndex = 14;
            this.ToFind_btn.Text = "brows ToFind Image";
            this.ToFind_btn.UseVisualStyleBackColor = true;
            this.ToFind_btn.Click += new System.EventHandler(this.ToFind_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Scence Image Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "ToFind Image Path";
            // 
            // Perform_MAtching_btn
            // 
            this.Perform_MAtching_btn.Location = new System.Drawing.Point(892, 21);
            this.Perform_MAtching_btn.Name = "Perform_MAtching_btn";
            this.Perform_MAtching_btn.Size = new System.Drawing.Size(150, 110);
            this.Perform_MAtching_btn.TabIndex = 21;
            this.Perform_MAtching_btn.Text = "Perform Matching";
            this.Perform_MAtching_btn.UseVisualStyleBackColor = true;
            this.Perform_MAtching_btn.Click += new System.EventHandler(this.Perform_MAtching_btn_Click);
            // 
            // Scence_openFileDialog
            // 
            this.Scence_openFileDialog.FileName = "openFileDialog1";
            // 
            // To_Find_openFileDialog
            // 
            this.To_Find_openFileDialog.FileName = "openFileDialog2";
            // 
            // Show_MachLine_Checkbox
            // 
            this.Show_MachLine_Checkbox.AutoSize = true;
            this.Show_MachLine_Checkbox.Checked = true;
            this.Show_MachLine_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Show_MachLine_Checkbox.Location = new System.Drawing.Point(477, 175);
            this.Show_MachLine_Checkbox.Name = "Show_MachLine_Checkbox";
            this.Show_MachLine_Checkbox.Size = new System.Drawing.Size(139, 21);
            this.Show_MachLine_Checkbox.TabIndex = 23;
            this.Show_MachLine_Checkbox.Text = "Show Match Lines";
            this.Show_MachLine_Checkbox.UseVisualStyleBackColor = true;
            this.Show_MachLine_Checkbox.CheckedChanged += new System.EventHandler(this.Show_MachLine_Checkbox_CheckedChanged);
            // 
            // show_KeyPoints_checkBox
            // 
            this.show_KeyPoints_checkBox.AutoSize = true;
            this.show_KeyPoints_checkBox.Checked = true;
            this.show_KeyPoints_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_KeyPoints_checkBox.Location = new System.Drawing.Point(227, 175);
            this.show_KeyPoints_checkBox.Name = "show_KeyPoints_checkBox";
            this.show_KeyPoints_checkBox.Size = new System.Drawing.Size(132, 21);
            this.show_KeyPoints_checkBox.TabIndex = 22;
            this.show_KeyPoints_checkBox.Text = "Show Key Points";
            this.show_KeyPoints_checkBox.UseVisualStyleBackColor = true;
            this.show_KeyPoints_checkBox.CheckedChanged += new System.EventHandler(this.show_KeyPoints_checkBox_CheckedChanged);
            // 
            // Instructionslbl
            // 
            this.Instructionslbl.AutoSize = true;
            this.Instructionslbl.Location = new System.Drawing.Point(86, 145);
            this.Instructionslbl.Name = "Instructionslbl";
            this.Instructionslbl.Size = new System.Drawing.Size(93, 17);
            this.Instructionslbl.TabIndex = 24;
            this.Instructionslbl.Text = "Instructions : ";
            // 
            // Instruction_textBox
            // 
            this.Instruction_textBox.Location = new System.Drawing.Point(185, 145);
            this.Instruction_textBox.Name = "Instruction_textBox";
            this.Instruction_textBox.ReadOnly = true;
            this.Instruction_textBox.Size = new System.Drawing.Size(657, 24);
            this.Instruction_textBox.TabIndex = 25;
            this.Instruction_textBox.Text = " use \'...\' buttons to choose both image files, then press Perform SURF button";
            // 
            // view_imageBox
            // 
            this.view_imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.view_imageBox.Enabled = false;
            this.view_imageBox.Location = new System.Drawing.Point(21, 202);
            this.view_imageBox.Name = "view_imageBox";
            this.view_imageBox.Size = new System.Drawing.Size(960, 480);
            this.view_imageBox.TabIndex = 26;
            this.view_imageBox.TabStop = false;
            // 
            // Two_Images_Matching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 697);
            this.Controls.Add(this.view_imageBox);
            this.Controls.Add(this.Instruction_textBox);
            this.Controls.Add(this.Instructionslbl);
            this.Controls.Add(this.Show_MachLine_Checkbox);
            this.Controls.Add(this.show_KeyPoints_checkBox);
            this.Controls.Add(this.Perform_MAtching_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToFind_text);
            this.Controls.Add(this.Scence_text);
            this.Controls.Add(this.Scence_btn);
            this.Controls.Add(this.ToFind_btn);
            this.Name = "Two_Images_Matching";
            this.Text = "Two_Images_Matching";
            this.Resize += new System.EventHandler(this.Two_Images_Matching_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.view_imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ToFind_text;
        private System.Windows.Forms.TextBox Scence_text;
        private System.Windows.Forms.Button Scence_btn;
        private System.Windows.Forms.Button ToFind_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Perform_MAtching_btn;
        private System.Windows.Forms.OpenFileDialog Scence_openFileDialog;
        private System.Windows.Forms.OpenFileDialog To_Find_openFileDialog;
        private System.Windows.Forms.CheckBox Show_MachLine_Checkbox;
        private System.Windows.Forms.CheckBox show_KeyPoints_checkBox;
        private System.Windows.Forms.Label Instructionslbl;
        private System.Windows.Forms.TextBox Instruction_textBox;
        private Emgu.CV.UI.ImageBox view_imageBox;
    }
}