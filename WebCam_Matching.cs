using System;
using Emgu.Util.TypeEnum;
using Emgu.Util;
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
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
using System.Diagnostics;
using System.Threading;

namespace Self_Driving_Car
{

    public partial class WebCam_Matching : Form
    {

        Brick _brik;
        int forword = 70;
        int backword = -70;
        uint time = 800;
        int Obstacle;
        Capture CapWebCam;
        bool green_light_flash=false;
        HaarCascade righthaar = new HaarCascade("L:\\محاضرات\\Lectures\\tabouk uni\\السنة الثالثة\\graduation project\\My graduation project 2\\my graduation project\\The Code\\Self_Driving_Car - Copy\\cascades\\cascade.xml");
        HaarCascade stophaar = new HaarCascade("C:\\Emgu\\emgucv-windows-x86 2.4.0.1717\\opencv\\data\\haarcascades\\stop.xml");
        HaarCascade lefthaar = new HaarCascade("C:\\Emgu\\emgucv-windows-x86 2.4.0.1717\\opencv\\data\\haarcascades\\left.xml");
        HaarCascade Green_Light_Haar = new HaarCascade("C:\\Emgu\\emgucv-windows-x86 2.4.0.1717\\opencv\\data\\haarcascades\\green-light.xml");
        HaarCascade Red_Light_Haar = new HaarCascade("C:\\Emgu\\emgucv-windows-x86 2.4.0.1717\\opencv\\data\\haarcascades\\red2.xml");


        int Original_MainForm_Width;
        int Original_MainForm_Height;
        int Original_ImageBox_width;
        int Original_ImageBox_Height;
        bool Capturing_in_process = false;
        bool current_sign_in_proccess = false;

        /// /////////////////////////////////////


        Image<Bgr, Byte> imgCopyOfImageToFindWithBorder;

        Stopwatch stopwatch = new Stopwatch();


        public WebCam_Matching()
        {
            InitializeComponent();
            Original_MainForm_Width = this.Width;
            Original_MainForm_Height = this.Height;
            Original_ImageBox_width = view_imageBox.Width;
            Original_ImageBox_Height = view_imageBox.Height;


        }
        private async void WebCam_Matching_Load(object sender, EventArgs e)
        {

            _brik = new Brick(new BluetoothCommunication("COM24"));

            _brik.BrickChanged += _brik_BrickChanged;
            await _brik.ConnectAsync();
            await _brik.DirectCommand.PlayToneAsync(100, 1000, 300);
            await _brik.DirectCommand.SetMotorPolarityAsync(OutputPort.B | OutputPort.C, Polarity.Forward);
            await _brik.DirectCommand.StopMotorAsync(OutputPort.All, false);
            await _brik.DirectCommand.ClearAllDevicesAsync();

        }
        private void _brik_BrickChanged(object sender, BrickChangedEventArgs e)
        {
            txtdistance.Text = e.Ports[InputPort.Four].SIValue.ToString();

        }
        private void WebCam_Matching_Resize(object sender, EventArgs e)
        {
            view_imageBox.Width = this.Width - (Original_MainForm_Width - Original_ImageBox_width);
            view_imageBox.Height = this.Height - (Original_MainForm_Height - Original_ImageBox_Height);
        }



        private async void Forwardbtn_Click(object sender, EventArgs e)
        {
            await _brik.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B | OutputPort.C, forword, time, true);

        }
        private async void Leftbtn_Click_1(object sender, EventArgs e)
        {

            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, backword, time, false);
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, forword, time, false);
            await _brik.BatchCommand.SendCommandAsync();
        }
        private async void Rightbtn_Click(object sender, EventArgs e)
        {
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, forword, time, false);
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, backword, time, false);
            await _brik.BatchCommand.SendCommandAsync();

        }
        private async void Backwordbtn_Click(object sender, EventArgs e)
        {
            await _brik.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B | OutputPort.C, backword, time, true);

        }



        public async void moveforward()
        {
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, 73, time, false);
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C,70 , time, false);
            await _brik.BatchCommand.SendCommandAsync();

            //await _brik.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B | OutputPort.C, forword, time, true);

        }
        public async void move_right()
        {
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, 100, time, false);
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, 0, time, false);
            await _brik.BatchCommand.SendCommandAsync();
        }
        public async void move_left()
        {
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, backword, time, false);
            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, forword, time, false);
            await _brik.BatchCommand.SendCommandAsync();
        }
        public async void stopmotor()
        {
            await _brik.DirectCommand.StopMotorAsync(OutputPort.All, false);
        }


        public async void Stop_Thread()
        {
            stopwatch.Reset();

            stopwatch.Start();
            //for (int i = 0; i < 20; i++)
            //{
            //    _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, 73, time, false);
            //    _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, 70, time, false);
            //    await _brik.BatchCommand.SendCommandAsync();
            //    Thread.Sleep(20);
            //}

            while (stopwatch.Elapsed.Seconds < 5)
            {
                await _brik.DirectCommand.StopMotorAsync(OutputPort.All, false);

                Debug.WriteLine("stop sign ahead");
                Debug.WriteLine(stopwatch.Elapsed.TotalSeconds);


            }
            //for (int i = 0; i < 10; i++)
            //{
            //    move_right();

            //}

            //_brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, forword, time, false);
            //_brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, backword, time, false);
            //await _brik.BatchCommand.SendCommandAsync();
            current_sign_in_proccess = false;
            //Obstacle = Convert.ToInt32(_brik.Ports[InputPort.Four].SIValue.ToString());
            //while (Obstacle < 20)
            //{
            //    await _brik.DirectCommand.StopMotorAsync(OutputPort.All, false);

            //    Obstacle = Convert.ToInt32(_brik.Ports[InputPort.Four].SIValue.ToString());

            //}
        }

        private void Webcam_Activate_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (Webcam_Activate_CheckBox.Checked == true)
            {

               // Capturing_in_process = true;

                //CapWebCam = new Capture("rtsp://192.168.1.254/sjcam.mov");
                CapWebCam = new Capture(2);
                //CapWebCam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 720);
                //CapWebCam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 576);
                //CapWebCam.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_TRIGGER,5);

                Application.Idle += PerformSURFevent;
                Instrucation_textBox.Text = "searching for an Object ";

            }
            else
            {
                view_imageBox.Image = null;
                CapWebCam.Dispose();

            }
        }
        private async void PerformSURFevent(object sender, EventArgs e)
        {

            #region surf Detection
            //try
            //{
            //    scenceImage = CapWebCam.QueryFrame();

            //    Instrucation_textBox.Text = "processing, please wait . . .";      // 'show processing message on title bar
            //    //string[] arr1 = new string[] {
            //    //    "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\Forward.jpeg",
            //    //    "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\left.jpg",
            //    //    "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\Right.jpg" ,
            //    //    "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\book.png "};
            //    stopwatch.Restart();

            //    ToFindImage = new Image<Bgr, byte>("C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\trafficlego.png");
            //    imgCopyOfImageToFindWithBorder = ToFindImage.Copy();
            //    imgCopyOfImageToFindWithBorder.Draw(new Rectangle(1, 1, imgCopyOfImageToFindWithBorder.Width - 3, imgCopyOfImageToFindWithBorder.Height - 3), bgrFoundImageColor, 2);

            //    SURFDetector surfDetector = new SURFDetector(500, false);

            //    Image<Gray, Byte> imgSceneGray = null;
            //    Image<Gray, Byte> imgToFindGray = null;

            //    //
            //    VectorOfKeyPoint vkpSceneKeyPoints;
            //    VectorOfKeyPoint vkpToFindKeyPoints;

            //    Matrix<Single> mtxSceneDescriptors;
            //    Matrix<Single> mtxToFindDescriptors;

            //    Matrix<int> mtxMatchIndices;
            //    Matrix<Single> mtxDistance;
            //    Matrix<Byte> mtxMask;

            //    BruteForceMatcher<Single> bruteForceMatcher;
            //    HomographyMatrix homographyMatrix = null;

            //    int intKNumNearestNeighbors = 2;
            //    double dblUniquenessThreshold = 0.8;

            //    int intNumNonZeroElements;

            //    // params for use with call to VoteForSize               
            //    double dblScaleIncrement = 1.5;
            //    int intRotationBins = 20;

            //    double dblRansacReprojectionThreshold = 2.0;


            //    PointF[] ptfPointsF;

            //    imgSceneGray = scenceImage.Convert<Gray, Byte>();
            //    imgToFindGray = ToFindImage.Convert<Gray, Byte>();

            //    vkpSceneKeyPoints = surfDetector.DetectKeyPointsRaw(imgSceneGray, null);
            //    mtxSceneDescriptors = surfDetector.ComputeDescriptorsRaw(imgSceneGray, null, vkpSceneKeyPoints);

            //    vkpToFindKeyPoints = surfDetector.DetectKeyPointsRaw(imgToFindGray, null);
            //    mtxToFindDescriptors = surfDetector.ComputeDescriptorsRaw(imgToFindGray, null, vkpToFindKeyPoints);

            //    bruteForceMatcher = new BruteForceMatcher<Single>(DistanceType.L2);

            //    bruteForceMatcher.Add(mtxToFindDescriptors);

            //    mtxMatchIndices = new Matrix<int>(mtxSceneDescriptors.Rows, intKNumNearestNeighbors);
            //    mtxDistance = new Matrix<Single>(mtxSceneDescriptors.Rows, intKNumNearestNeighbors);
            //    // find the matches points in both image
            //    bruteForceMatcher.KnnMatch(mtxSceneDescriptors, mtxMatchIndices, mtxDistance, intKNumNearestNeighbors, null);

            //    mtxMask = new Matrix<Byte>(mtxDistance.Rows, 1);
            //    mtxMask.SetValue(250);

            //    // we use the next command to delete the simmilar matches if the ration is smaller than 0.8
            //    Features2DToolbox.VoteForUniqueness(mtxDistance, dblUniquenessThreshold, mtxMask);

            //    intNumNonZeroElements = CvInvoke.cvCountNonZero(mtxMask);
            //    if (intNumNonZeroElements >= 4)
            //    {                                                       //'if at least 4,
            //        intNumNonZeroElements = Features2DToolbox.VoteForSizeAndOrientation(vkpToFindKeyPoints, vkpSceneKeyPoints, mtxMatchIndices, mtxMask, dblScaleIncrement, intRotationBins);

            //        if (intNumNonZeroElements >= 4)
            //        { //if still at least 4 non-zero elements,
            //          //get the homography matrix using RANSAC (RANdom SAmple Consensus)
            //            intNumNonZeroElements = Features2DToolbox.VoteForSizeAndOrientation(vkpToFindKeyPoints, vkpSceneKeyPoints, mtxMatchIndices, mtxMask, dblScaleIncrement, intRotationBins);


            //            homographyMatrix = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(vkpToFindKeyPoints, vkpSceneKeyPoints, mtxMatchIndices, mtxMask, dblRansacReprojectionThreshold);
            //        }
            //    }
            //    //if (intNumNonZeroElements < 25)
            //    //{
            //    //    view_imageBox.Image = scenceImage;
            //    //    stopwatch.Stop();                                  //stop the stopwatch and update the form title bar with the time
            //    //    Instrucation_textBox.Text = "processing time = " + stopwatch.Elapsed.TotalSeconds.ToString() + " sec, done processing, choose another image if desired";
            //    //}
            //    //else
            //    //{
            //    imgCopyOfImageToFindWithBorder = ToFindImage.Copy();             //make a copy of the image to find, so we can draw on the copy, therefore no changing the original image to find
            //                                                                     //draw a 2 pixel wide border around the copy of the image to find, use same color as box for found image
            //    imgCopyOfImageToFindWithBorder.Draw(new Rectangle(1, 1, imgCopyOfImageToFindWithBorder.Width - 3, imgCopyOfImageToFindWithBorder.Height - 3), bgrFoundImageColor, 2);

            //    //next we will draw the scene image and image to find together in the result image
            //    //3 conditionals are necessary, depenting on which check boxes are checked (draw key points and / or draw matching lines)
            //    //if (show_KeyPoints_checkBox.Checked == true && Show_MachLine_Checkbox.Checked == true)
            //    //{      //if drawing both key points & matching lines on result image,
            //    //       //use DrawMatches function, combines scene image and copy of image to find into result, then draws key points and matching lines all in one step
            //    imgResult = Features2DToolbox.DrawMatches
            //        (imgCopyOfImageToFindWithBorder,
            //         vkpToFindKeyPoints,
            //          scenceImage,
            //          vkpSceneKeyPoints,
            //          mtxMatchIndices,
            //          bgrMatchingLinesColor,
            //          bgrKeyPointsColor,
            //          mtxMask,
            //          Features2DToolbox.KeypointDrawType.DEFAULT
            //     );
            //    //}
            //    //else if (show_KeyPoints_checkBox.Checked == true && Show_MachLine_Checkbox.Checked == false)
            //    //{
            //    //    imgResult = Features2DToolbox.DrawKeypoints(scenceImage, vkpSceneKeyPoints, bgrKeyPointsColor, Features2DToolbox.KeypointDrawType.DEFAULT);
            //    //    //then draw key points on copy of image to find,
            //    //    imgCopyOfImageToFindWithBorder = Features2DToolbox.DrawKeypoints(imgCopyOfImageToFindWithBorder, vkpToFindKeyPoints, bgrKeyPointsColor, Features2DToolbox.KeypointDrawType.DEFAULT);
            //    //    imgResult = imgResult.ConcateHorizontal(imgCopyOfImageToFindWithBorder);                //then concatenate copy of image to find onto result image
            //    //}
            //    //else if (show_KeyPoints_checkBox.Checked == false && Show_MachLine_Checkbox.Checked == false)
            //    //{

            //    //}

            //    if (homographyMatrix != null)
            //    {  //draw a rectangle along the projected model
            //        Rectangle rect = imgSceneGray.ROI;
            //        rect.X = 0;
            //        rect.Y = 0;
            //        rect.Width = imgToFindGray.Width;
            //        rect.Height = imgToFindGray.Height;
            //        ptfPointsF = new PointF[] {
            //              new PointF(rect.Left, rect.Bottom),
            //              new PointF(rect.Right, rect.Bottom),
            //              new PointF(rect.Right, rect.Top),
            //              new PointF(rect.Left, rect.Top)};
            //        homographyMatrix.ProjectPoints(ptfPointsF);

            //        imgResult.DrawPolyline(Array.ConvertAll<PointF, Point>(ptfPointsF, Point.Round), true, new Bgr(System.Drawing.Color.Red), 5);

            //    }
            //    //if (intNumNonZeroElements > 10)
            //    //{


            //    //    imgResult = imgResult.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
            //    //    Found_image_textBox.Text = "found";

            //    //}
            //    else
            //    {
            //        imgResult = scenceImage; //assign scene image to result image
            //    }
            //    view_imageBox.Image = imgResult;

            //    stopwatch.Stop();                                  //stop the stopwatch and update the form title bar with the time
            //    Instrucation_textBox.Text = "processing time = " + stopwatch.Elapsed.TotalSeconds.ToString() + " sec, done processing, choose another image if desired";
            //    ////}
            //    ////}
            //    //i++;
            //    //if (i == 4)
            //    //    i = 0;


            //}
            //catch (Exception ex)
            //{
            //    Instrucation_textBox.Text = ex.Message;
            //}
            #endregion


            #region sign  Detection

           // int Obstacle;

            System.Media.SoundPlayer player;
            MCvFont Font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_DUPLEX, 0.7, 0.7);

            using (Image<Bgr, byte> nextFrame = CapWebCam.QueryFrame())
            {
                if (nextFrame != null)
                {
                    bool detected_object = false;

                    string[] arr1 = new string[]
                    {
                     "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\stop.png",
                     "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\left.png",
                     "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\Right.jpg",
                     "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\traffic-green.png",
                     "C:\\Users\\MHD\\Documents\\Visual Studio 2015\\Projects\\Self_Driving_Car\\images\\traffic-red.png",
                    };

                    Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();

                    var Stop_Sign = stophaar.Detect(grayframe, 1.2, 24, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                    new Size(nextFrame.Width / 8, nextFrame.Height / 8), Size.Empty);

                    var Right_Sign = righthaar.Detect(grayframe, 1.2, 20, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                  new Size(nextFrame.Width / 8, nextFrame.Height / 8), Size.Empty);

                    var Left_Sign = lefthaar.Detect(grayframe, 1.2, 20, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                  new Size(nextFrame.Width / 8, nextFrame.Height / 8), Size.Empty);
                    var Green_Light = Green_Light_Haar.Detect(grayframe,1.1,20, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                 new Size(nextFrame.Width / 8, nextFrame.Height / 8), Size.Empty);

                    var Red_Light = Red_Light_Haar.Detect(grayframe, 1.1, 35, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                new Size(nextFrame.Width / 8, nextFrame.Height / 8), Size.Empty);
                    #region stop sign
                    if (Stop_Sign != null)
                    {
                        foreach (var stop in Stop_Sign)
                        {

                            player = new System.Media.SoundPlayer(@"C:\Users\MHD\documents\visual studio 2015\Projects\Self_Driving_Car\sounds\stop_sign.Wav");
                            player.Play();
                            //////////////////
                            nextFrame.Draw(stop.rect, new Bgr(0, 0, 255), 3);
                            nextFrame.Draw("Stop Sign", ref Font, new Point(stop.rect.X, stop.rect.Y-6), new Bgr(0, 0, 255));
                            Instrucation_textBox.Text = " Detected Object  ";
                            Found_image_textBox.Text = "Stop";

                            //////////////////
                            imgCopyOfImageToFindWithBorder = new Image<Bgr, byte>(arr1[0]);
                            view_imageBox.Image = nextFrame.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
                            detected_object = true;
                            /////////////////////
                            for (int i = 0; i < 10; i++)
                            {
                                moveforward();
                            }
                            
                            if (current_sign_in_proccess == false)
                            {
                                current_sign_in_proccess = true;
                                Thread othread = new Thread(new ThreadStart(Stop_Thread));
                                othread.Start();
                                while (!othread.IsAlive) ;
                                Thread.Sleep(3);

                            }



                        }
                    }
                    #endregion
                    #region Left Sign
                    if (Left_Sign != null)
                        foreach (var left in Left_Sign)
                        {
                            player = new System.Media.SoundPlayer(@"C:\Users\MHD\documents\visual studio 2015\Projects\Self_Driving_Car\sounds\lefft_sign.Wav");
                            player.Play();
                            nextFrame.Draw(left.rect, new Bgr(255, 0, 0), 3);
                            nextFrame.Draw("Left Sign", ref Font, new Point(left.rect.X, left.rect.Y - 6), new Bgr(255, 0, 0));
                            Found_image_textBox.Text = "Left";
                            Instrucation_textBox.Text = " Detected Object   ";
                            
                            detected_object = true;
                            imgCopyOfImageToFindWithBorder = new Image<Bgr, byte>(arr1[1]);
                            view_imageBox.Image = nextFrame.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
                          


                            move_left();


                        }
                    #endregion

                    #region Right Sign
                    if (Right_Sign != null)
                        foreach (var right in Right_Sign)
                        {
                            player = new System.Media.SoundPlayer(@"C:\Users\MHD\documents\visual studio 2015\Projects\Self_Driving_Car\sounds\right_sign.Wav");
                            player.Play();
                            nextFrame.Draw(right.rect, new Bgr(0, 255, 255),3);
                            nextFrame.Draw("Right Sign",ref Font , new Point(right.rect.X,right.rect.Y-6), new Bgr(0, 255, 255));
                            detected_object = true;
                            Found_image_textBox.Text = "Right";
                            Instrucation_textBox.Text = " Detected Object   ";

                            imgCopyOfImageToFindWithBorder = new Image<Bgr, byte>(arr1[2]);
                            view_imageBox.Image = nextFrame.ConcateHorizontal(imgCopyOfImageToFindWithBorder);

                             move_right();
                             System.Threading.Thread.Sleep(500);
                             move_right();


                        }
                    #endregion

                    #region Green Light
                    if (Green_Light != null)
                        foreach (var green in Green_Light)
                        {
                            //player = new System.Media.SoundPlayer(@"C:\Users\MHD\documents\visual studio 2015\Projects\Self_Driving_Car\sounds\lefft_sign.Wav");
                            //player.Play();
                            nextFrame.Draw(green.rect, new Bgr(0, 255, 0), 3);
                            nextFrame.Draw("Green Light", ref Font, new Point(green.rect.X, green.rect.Y-6), new Bgr(0, 255, 0));

                           //detected_object = true;
                            imgCopyOfImageToFindWithBorder = new Image<Bgr, byte>(arr1[3]);
                            view_imageBox.Image = nextFrame.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
                            Found_image_textBox.Text = "Green Light";
                            Instrucation_textBox.Text = " Detected Object  ";
                            //green_light_flash = true;

                            // move_left();


                        }
                    #endregion
                    #region Red Light
                    if (Red_Light != null)
                        foreach (var red in Red_Light)
                        {
                            //player = new System.Media.SoundPlayer(@"C:\Users\MHD\documents\visual studio 2015\Projects\Self_Driving_Car\sounds\lefft_sign.Wav");
                            //player.Play();
                            nextFrame.Draw(red.rect, new Bgr(0, 0, 255), 3);
                            nextFrame.Draw("Red Light", ref Font, new Point(red.rect.X, red.rect.Y-6), new Bgr(0, 0,255));
                            green_light_flash = false;
                           // detected_object = true;
                            imgCopyOfImageToFindWithBorder = new Image<Bgr, byte>(arr1[4]);
                            view_imageBox.Image = nextFrame.ConcateHorizontal(imgCopyOfImageToFindWithBorder);
                            Found_image_textBox.Text = "Red Light";
                            Instrucation_textBox.Text = " Detected Object  ";

                           
                            if (green_light_flash == false)
                            {
                                current_sign_in_proccess = true;
                                Thread othread = new Thread(new ThreadStart(Stop_Thread));
                                othread.Start();
                                while (!othread.IsAlive) ;
                                Thread.Sleep(3);


                            }
                            //  await _brik.DirectCommand.StopMotorAsync(OutputPort.All, false);


                            // move_left();


                        }
                    #endregion
                    if (detected_object != true  )
                    {
                        Instrucation_textBox.Text = " detected object  ";

                        view_imageBox.Image = nextFrame;
                        int color = Convert.ToInt32(_brik.Ports[InputPort.One].SIValue.ToString());

                        if (color > 60)
                        {
                            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, backword, 300, false);
                            _brik.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, forword, 300, false);
                            await _brik.BatchCommand.SendCommandAsync();
                        }
                        else
                            moveforward();

                    }

                }
            }

            #endregion
        }





    }
}
