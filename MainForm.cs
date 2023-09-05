using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Driving_Car
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Two_Images_Matchingbtn_Click(object sender, EventArgs e)
        {
            Two_Images_Matching T = new Two_Images_Matching();
            T.Show();
        }

        private void Webcam_Matchingbtn_Click(object sender, EventArgs e)
        {
            WebCam_Matching w = new WebCam_Matching();
            w.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
