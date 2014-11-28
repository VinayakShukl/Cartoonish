using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.IO;
using System.Windows.Forms;

namespace Cartoonish
{
    public partial class Form1 : Form
    {

        private const string IMAGE_TYPES = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
        private const string VIDEO_TYPE = "MP4 Files (*.mp4)|*.mp4";
        private const string FILE_TYPES = IMAGE_TYPES + "|" + VIDEO_TYPE;
        private static string imgFilePath, imgFileName, videoFilePath, videoFileName;
        private static Image<Bgr, Byte> origImage;
        private static Image<Bgr, Byte> currImage;
        private static Capture currVideo;
        private static bool isVideoSelected = false;

        private static int SCALE_FACTOR = 24, BILLATERAL_KERNEL_SIZE = 2,
            BILLATERAL_ITERATIONS = 2, EDGE_THICKNESS = 2;
        private static double EDGE_QUANTITY = 0.00005;

        public Form1()
        {
            InitializeComponent();
        }

        public Boolean checkImageUploaded()
        {
            error.Clear();
            if (currImage == null) {
                error.SetError(loadBtn, "Upload an image!");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = FILE_TYPES;
            dialog.Title = "Please select an image file.";
            if (dialog.ShowDialog() == DialogResult.OK) {
                string ext = Path.GetExtension(dialog.FileName).ToLower(); ;
                if (ext.Equals(".jpg") || ext.Equals(".png"))
                {
                    isVideoSelected = false;
                    imgFileName = dialog.SafeFileName;
                    imgFilePath = dialog.FileName;
                    origImage = new Image<Bgr, byte>(dialog.FileName);
                    currImage = origImage.Copy();
                    pictureBox.Image = origImage.ToBitmap();

                } else
                {
                    isVideoSelected = true;
                    videoFileName = dialog.SafeFileName;
                    videoFilePath = dialog.FileName;
                    currVideo = new Capture(videoFilePath);
                    currImage = currVideo.QueryFrame();
                    pictureBox.Image = currImage.ToBitmap();

                }
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (!(origImage == null)) {
                pictureBox.Image = origImage.ToBitmap();
                currImage = origImage.Copy();
            }
            if (checkImageUploaded()) {
                //updateHistogram();
                //updateDFT();
            }
            progressBar.Value = 0;
            error.Clear();
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            currImage = ColorUtils.run(currImage, SCALE_FACTOR, BILLATERAL_KERNEL_SIZE, BILLATERAL_ITERATIONS).Copy();
            pictureBox.Image = currImage.ToBitmap();
        }

        private void edgebtn_Click(object sender, EventArgs e)
        {
            currImage = EdgeUtils.run(currImage, EDGE_QUANTITY, EDGE_THICKNESS).Copy();
            pictureBox.Image = currImage.ToBitmap();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            if (isVideoSelected)
            {
                processVideo();
            } else
            {
                processImage();
            }
        }

        private void processImage()
        {
            imageWorker.RunWorkerAsync();
        }

        private void processVideo()
        {
            videoWorker2.RunWorkerAsync();
        }

        private void scaleFactor_ValueChanged(object sender, EventArgs e)
        {
            int value = ((TrackBar)sender).Value;
            switch (value)
            {
                case 1:
                    SCALE_FACTOR = 16;
                    break;
                case 2:
                    SCALE_FACTOR = 32;
                    break;
                case 3:
                    SCALE_FACTOR = 64;
                    break;
                default:
                    SCALE_FACTOR = 32;
                    break;
            }
        }
        
        private void kernelLow_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                BILLATERAL_KERNEL_SIZE = 3;
        }

        private void kernelMed_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                BILLATERAL_KERNEL_SIZE = 9;
        }

        private void kernelHigh_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                BILLATERAL_KERNEL_SIZE = 27;
        }

        private void iterLow_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                BILLATERAL_ITERATIONS = 5;
        }

        private void iterMed_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                BILLATERAL_ITERATIONS = 10;
        }

        private void iterHigh_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                BILLATERAL_ITERATIONS = 20;
        }

        private void edgeAmountMed_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                EDGE_QUANTITY = 0.00005;
        }

        private void edgeAmountLow_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                EDGE_QUANTITY = 0.0005;
        }

        private void edgeAmountHigh_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                EDGE_QUANTITY = 0.000005;
        }

        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void edgeThicknessLow_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                EDGE_THICKNESS = 0;
        }

        private void edgeThicknessMed_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                EDGE_THICKNESS = 1;
        }

        private void edgeThicknessHigh_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                EDGE_THICKNESS = 2;
        }

        private void imageWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if ((videoWorker.CancellationPending != false))
            {
                e.Cancel = true;
                return;
            }

            imageWorker.ReportProgress(10);
            currImage = ColorUtils.run(currImage, SCALE_FACTOR, BILLATERAL_KERNEL_SIZE, BILLATERAL_ITERATIONS);
            imageWorker.ReportProgress(60);
            Image<Bgr, byte> edges = EdgeUtils.run(currImage, EDGE_QUANTITY, EDGE_THICKNESS);
            imageWorker.ReportProgress(90);
            Image<Gray, byte> copy = edges.Copy().Convert<Gray, byte>();
            copy = ~edges.Convert<Gray, byte>();
            copy = copy.ThresholdBinary(new Gray(127), new Gray(255));
            currImage = currImage.Copy(copy);
            imageWorker.ReportProgress(100);
        }

        private void imageWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void videoWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void videoWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void videoWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Image<Bgr, byte> currFrame;
            Image<Bgr, Byte> tempImage = currVideo.QueryFrame();
            VideoWriter videoWriter = new VideoWriter("a.avi", 30, tempImage.Width, tempImage.Height, true);

            double frameCount = currVideo.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_COUNT);
            int i = 0;

            while (true)
            {
                if ((videoWorker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    currFrame = currVideo.QueryFrame();
                    if (currFrame != null)
                    {
                        Image<Bgr, byte> colors = ColorUtils.run(currFrame, SCALE_FACTOR, BILLATERAL_KERNEL_SIZE, BILLATERAL_ITERATIONS);
                        Image<Bgr, byte> edges = EdgeUtils.run(colors, EDGE_QUANTITY, EDGE_THICKNESS);
                        Image<Gray, byte> copy = edges.Copy().Convert<Gray, byte>();
                        copy = ~edges.Convert<Gray, byte>();
                        copy = copy.ThresholdBinary(new Gray(127), new Gray(255));
                        videoWriter.WriteFrame(currFrame);
                        videoWorker2.ReportProgress((int)(i / frameCount * 100));
                        Console.WriteLine((int)(i / frameCount * 100));
                        i++;
                    }
                    else
                        break;
                }
            }
        }

        private void videoWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (isVideoSelected)
                videoWorker2.CancelAsync();
            else
                imageWorker.CancelAsync();

        }

        private void imageWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox.Image = currImage.ToBitmap();
        }
    }
}
