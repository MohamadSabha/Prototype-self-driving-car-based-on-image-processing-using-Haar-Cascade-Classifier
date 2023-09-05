using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Features2D;
using Emgu.CV.CvEnum;
using Emgu.CV.Flann;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.UI;
using Emgu.CV;
using System.Diagnostics;

namespace Self_Driving_Car
{
    public partial class Two_Images_Matching : Form
    {

        Capture CapWebCam;
        int Original_MainForm_Width;
        int Original_MainForm_Height;
        int Original_ImageBox_width;
        int Original_ImageBox_Height;
        /// /////////////////////////////////////
        bool scence_image_load_successfully= false; 
        bool ToFind_Image_Load_successfully= false;
        Image<Bgr, Byte> scenceImage = null;
        Image<Bgr, Byte> ToFindImage = null;
        Image<Bgr, Byte> imgResult;                   

        Bgr bgrKeyPointsColor = new Bgr(Color.Blue);     
        Bgr bgrMatchingLinesColor = new Bgr(Color.Green);
        Bgr bgrFoundImageColor = new Bgr(Color.Red);     
        Image<Bgr, Byte> imgCopyOfImageToFindWithBorder; 

        Stopwatch stopwatch = new Stopwatch();           
                                                                                                                                                                     
        public Two_Images_Matching()
        {
            InitializeComponent();
            Original_MainForm_Width = this.Width;
            Original_MainForm_Height = this.Height;
            Original_ImageBox_width = view_imageBox.Width;
            Original_ImageBox_Height = view_imageBox.Height;


        }
        private void Two_Images_Matching_Resize(object sender, EventArgs e)
        {
            view_imageBox.Width = this.Width - (Original_MainForm_Width - Original_ImageBox_width);
            view_imageBox.Height = this.Height - (Original_MainForm_Height - Original_ImageBox_Height);

        }

        private void Scence_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = Scence_openFileDialog.ShowDialog();
            Scence_text.Text = Scence_openFileDialog.FileName;
            try
            {
                scenceImage = new Image<Bgr, byte>(Scence_text.Text);
            }
            catch (Exception ex)
            {
                Instruction_textBox.Text = ex.Message;
                return;

            }
            scence_image_load_successfully = true;


            if (ToFind_Image_Load_successfully == false)
                view_imageBox.Image = scenceImage;
            else
                view_imageBox.Image = scenceImage.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
        }

        private void ToFind_btn_Click(object sender, EventArgs e)
        {
            DialogResult DialogResul = To_Find_openFileDialog.ShowDialog();
            ToFind_text.Text = To_Find_openFileDialog.FileName;

            try
            {
                ToFindImage = new Image<Bgr, byte>(ToFind_text.Text);
            }
            catch (Exception ex)
            {
                Instruction_textBox.Text = ex.Message;
                return;

            }
            ToFind_Image_Load_successfully = true;

            imgCopyOfImageToFindWithBorder = ToFindImage.Copy();
            // draw 2 pixel wide border around the copy of the image to find, use same color as box for found image

            imgCopyOfImageToFindWithBorder.Draw(new Rectangle(1, 1, imgCopyOfImageToFindWithBorder.Width - 3, imgCopyOfImageToFindWithBorder.Height - 3), bgrFoundImageColor, 2);
            if (scence_image_load_successfully == false)
                view_imageBox.Image = imgCopyOfImageToFindWithBorder;
            else
               view_imageBox.Image= scenceImage.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
        }

        private void show_KeyPoints_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (show_KeyPoints_checkBox.Checked == false)
            {
                Show_MachLine_Checkbox.Checked = false;
                Show_MachLine_Checkbox.Enabled = false;
            }
            else
            {
                Show_MachLine_Checkbox.Enabled = true;
            }
                PerformSURFevent(new Object(), new EventArgs());           //call SURF button click event to update image for draw key points check box change


            
        }



        private void Show_MachLine_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            PerformSURFevent(new Object(), new EventArgs());


        }
        private void Perform_MAtching_btn_Click(object sender, EventArgs e)
        {
            if (Scence_text.Text != string.Empty && ToFind_text.Text != string.Empty)   //check that something is entered in each image file text box
            PerformSURFevent(new Object(), new EventArgs());
        }

       
        private void PerformSURFevent(object v, EventArgs eventArgs)
        {
            if (scence_image_load_successfully == false || ToFind_Image_Load_successfully == false)
            {
                Instruction_textBox.Text = "either or both images are not loaded or null, please choose both images before performing SURF";
            }
            else
            {

                Instruction_textBox.Text = "processing, please wait . . .";      // 'show processing message on title bar
                stopwatch.Restart();

                SURFDetector surfDetector = new SURFDetector(500, false);
                                                                         
                Image<Gray, Byte> imgSceneGray = null;                   
                Image<Gray, Byte> imgToFindGray = null;                  

                //
                VectorOfKeyPoint vkpSceneKeyPoints;                      
                VectorOfKeyPoint vkpToFindKeyPoints;                     
                                                                         
                Matrix<Single> mtxSceneDescriptors;                      
                Matrix<Single> mtxToFindDescriptors;                     
                                                                         
                Matrix<int> mtxMatchIndices;                          
                Matrix<Single> mtxDistance;                           
                Matrix<Byte> mtxMask;                                 
                                                                      
                BruteForceMatcher<Single> bruteForceMatcher;          
                HomographyMatrix homographyMatrix = null;                
                                                                         
                int intKNumNearestNeighbors = 2;                         
                double dblUniquenessThreshold = 0.8;                     
                                                                         
                int intNumNonZeroElements;                               
                                                                         
                // params for use with call to VoteForSize               
                double dblScaleIncrement = 3;                          
                int intRotationBins = 40;                                
                                                                         
                double dblRansacReprojectionThreshold = 2.0;             
                                                                         
                                                                         
                PointF[] ptfPointsF;                                     
                                                                         
                imgSceneGray = scenceImage.Convert<Gray, Byte>();        
                imgToFindGray = ToFindImage.Convert<Gray, Byte>();    

                vkpSceneKeyPoints = surfDetector.DetectKeyPointsRaw(imgSceneGray, null);                        
                mtxSceneDescriptors = surfDetector.ComputeDescriptorsRaw(imgSceneGray, null, vkpSceneKeyPoints);   
                                                                                                                   
                vkpToFindKeyPoints = surfDetector.DetectKeyPointsRaw(imgToFindGray, null);                         
                mtxToFindDescriptors = surfDetector.ComputeDescriptorsRaw(imgToFindGray, null, vkpToFindKeyPoints);

                bruteForceMatcher = new BruteForceMatcher<Single>(DistanceType.L2);                  

                bruteForceMatcher.Add(mtxToFindDescriptors);                                       

                mtxMatchIndices = new Matrix<int>(mtxSceneDescriptors.Rows, intKNumNearestNeighbors);
                mtxDistance = new Matrix<Single>(mtxSceneDescriptors.Rows, intKNumNearestNeighbors); 

                bruteForceMatcher.KnnMatch(mtxSceneDescriptors, mtxMatchIndices, mtxDistance, intKNumNearestNeighbors, null); 

                mtxMask = new Matrix<Byte>(mtxDistance.Rows, 1);                       
                mtxMask.SetValue(255);                                                             
                                                                                                   
                Features2DToolbox.VoteForUniqueness(mtxDistance, dblUniquenessThreshold, mtxMask); 
                                                                                                   
                intNumNonZeroElements = CvInvoke.cvCountNonZero(mtxMask);                          
                if (intNumNonZeroElements >= 4)
                {                                                       //'if at least 4,
                    intNumNonZeroElements = Features2DToolbox.VoteForSizeAndOrientation(vkpToFindKeyPoints, vkpSceneKeyPoints, mtxMatchIndices, mtxMask, dblScaleIncrement, intRotationBins);

                    if (intNumNonZeroElements > 4)
                    { 
                      
                        homographyMatrix = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(vkpToFindKeyPoints, vkpSceneKeyPoints, mtxMatchIndices, mtxMask, dblRansacReprojectionThreshold);
                    }
                }

                imgCopyOfImageToFindWithBorder = ToFindImage.Copy();            
                                                                                            
                imgCopyOfImageToFindWithBorder.Draw(new Rectangle(1, 1, imgCopyOfImageToFindWithBorder.Width - 3, imgCopyOfImageToFindWithBorder.Height - 3), bgrFoundImageColor, 2);

               ///////////////////////////////////////////////////////
                if (show_KeyPoints_checkBox.Checked == true && Show_MachLine_Checkbox.Checked == true)
                {      //if drawing both key points & matching lines on result image,
                       //use DrawMatches function, combines scene image and copy of image to find into result, then draws key points and matching lines all in one step
                    imgResult = Features2DToolbox.DrawMatches
                        (imgCopyOfImageToFindWithBorder,
                         vkpToFindKeyPoints,
                          scenceImage,
                          vkpSceneKeyPoints,
                          mtxMatchIndices,
                          bgrMatchingLinesColor,
                          bgrKeyPointsColor,
                          mtxMask,
                          Features2DToolbox.KeypointDrawType.DEFAULT
                        );
                }
                else if (show_KeyPoints_checkBox.Checked == true && Show_MachLine_Checkbox.Checked == false)
                { 
                    imgResult = Features2DToolbox.DrawKeypoints(scenceImage, vkpSceneKeyPoints, bgrKeyPointsColor, Features2DToolbox.KeypointDrawType.DEFAULT);
                 
                    imgCopyOfImageToFindWithBorder = Features2DToolbox.DrawKeypoints(imgCopyOfImageToFindWithBorder, vkpToFindKeyPoints, bgrKeyPointsColor, Features2DToolbox.KeypointDrawType.DEFAULT);
                    imgResult = imgResult.ConcateHorizontal(imgCopyOfImageToFindWithBorder);                
                }
                else if (show_KeyPoints_checkBox.Checked == false && Show_MachLine_Checkbox.Checked == false)          
                {
                    imgResult = scenceImage; 
                    imgResult = imgResult.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
                }
                
                if (homographyMatrix != null)
                {  
                    Rectangle rect = imgSceneGray.ROI;
                    rect.X = 0;
                    rect.Y = 0;
                    rect.Width = imgToFindGray.Width;
                    rect.Height = imgToFindGray.Height;
                    ptfPointsF = new PointF[] {
                      new PointF(rect.Left, rect.Bottom),
                      new PointF(rect.Right, rect.Bottom),
                      new PointF(rect.Right, rect.Top),
                      new PointF(rect.Left, rect.Top)};
                    homographyMatrix.ProjectPoints(ptfPointsF);

                    imgResult.DrawPolyline(Array.ConvertAll<PointF, Point>(ptfPointsF, Point.Round), true, new Bgr(Color.Red), 5);

                  }
                

                view_imageBox.Image = imgResult;                                        

                stopwatch.Stop();                                 
                Instruction_textBox.Text = "processing time = " + stopwatch.Elapsed.TotalSeconds.ToString() + " sec, done processing, choose another image if desired";
            }

        }

      
    }
}
