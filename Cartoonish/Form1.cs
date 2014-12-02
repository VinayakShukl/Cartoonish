using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
        private static double[][] histogramData;
        private static bool showCurrentFrame = false;
        private static int SCALE_FACTOR = 24, BILLATERAL_KERNEL_SIZE = 2,
            BILLATERAL_ITERATIONS = 2, EDGE_THICKNESS = 2;
        private static double EDGE_QUANTITY = 0.00005;

        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
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

        public static double[][] histogram(Image<Bgr, Byte> img)
        {
            byte[, ,] data = img.Data;
            double[][] result = new double[3][];
            for (int i = 0; i < 3; i++)
                result[i] = new double[256];

            int curr;
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        curr = data[i, j, k];
                        result[k][curr] += 1;
                    }
                }
            }
            return result;
        }

        private void drawHistogram()
        {
            string blueSeries = "Blue";
            string greenSeries = "Green";
            string redSeries = "Red";
            int TRANSPERANCY = 75;

            if (chart1.Series.IndexOf(blueSeries) == -1)
            {
                chart1.Series.Add(blueSeries);
                chart1.Series[blueSeries].ChartType = SeriesChartType.Area;
                chart1.Series[blueSeries].Color = Color.FromArgb(TRANSPERANCY, Color.Blue);
            }
            if (chart1.Series.IndexOf(greenSeries) == -1)
            {
                chart1.Series.Add(greenSeries);
                chart1.Series[greenSeries].ChartType = SeriesChartType.Area;
                chart1.Series[greenSeries].Color = Color.FromArgb(TRANSPERANCY, Color.Green);
            }
            if (chart1.Series.IndexOf(redSeries) == -1)
            {
                chart1.Series.Add(redSeries);
                chart1.Series[redSeries].ChartType = SeriesChartType.Area;
                chart1.Series[redSeries].Color = Color.FromArgb(TRANSPERANCY, Color.Red);
            }

            foreach (var series in chart1.Series)
                series.Points.Clear();

            double[][] data = histogramData;
            double[] count = new double[256];
            for (int i = 0; i < 256; i++)
            {
                chart1.Series[blueSeries].Points.AddXY(i, data[0][i]);
                chart1.Series[greenSeries].Points.AddXY(i, data[1][i]);
                chart1.Series[redSeries].Points.AddXY(i, data[2][i]);
            }
        }

        private void updateHistogram()
        {
            if (!histogramWorker.IsBusy)
            {
                chart1.Visible = false;
                histogramWorker.RunWorkerAsync();
            }
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
                    updateHistogram();
                } else
                {
                    isVideoSelected = true;
                    videoFileName = dialog.SafeFileName;
                    videoFilePath = dialog.FileName;
                    currVideo = new Capture(videoFilePath);
                    currImage = currVideo.QueryFrame().Copy();
                    pictureBox.Image = currImage.ToBitmap();
                    updateHistogram();
                }
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (!(origImage == null)) {
                pictureBox.Image = origImage.ToBitmap();
                currImage = origImage.Copy();
                updateHistogram();
                Console.WriteLine("Image RESET");
            }
            progressBar.Value = 0;
            error.Clear();
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            if (!checkImageUploaded()) return;
            currImage = ColorUtils.run(currImage, SCALE_FACTOR, BILLATERAL_KERNEL_SIZE, BILLATERAL_ITERATIONS).Copy();
            pictureBox.Image = currImage.ToBitmap();
            updateHistogram();
        }

        private void edgebtn_Click(object sender, EventArgs e)
        {
            if (!checkImageUploaded()) return;
            currImage = EdgeUtils.run(currImage, EDGE_QUANTITY, EDGE_THICKNESS).Copy();
            pictureBox.Image = currImage.ToBitmap();
            updateHistogram();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            if (!checkImageUploaded()) return;
            if (isVideoSelected)
                processVideo();
            else
                processImage();
        }

        private void processImage()
        {
            if (!imageWorker.IsBusy)
                imageWorker.RunWorkerAsync();
            else
                Console.WriteLine("An Image is already being processed");
        }

        private void processVideo()
        {
            if (!videoWorker2.IsBusy)
                videoWorker2.RunWorkerAsync();
            else
                Console.WriteLine("A Video is already being processed");
            
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
            if ((imageWorker.CancellationPending == true))
            {

                e.Cancel = true;
                imageWorker.ReportProgress(0);
                Console.WriteLine("Image Operations Stopped");
                return;
            }
            else
            {
                imageWorker.ReportProgress(10);
                Image<Bgr, byte> color = ColorUtils.run(currImage, SCALE_FACTOR, BILLATERAL_KERNEL_SIZE, BILLATERAL_ITERATIONS);
                
                if(imageWorker.CancellationPending==true)
                {
                    Console.WriteLine("Stopped after Colors");
                    imageWorker.ReportProgress(0);
                    e.Cancel = true;
                    return;
                }
                
                imageWorker.ReportProgress(60);
                Image<Bgr, byte> edges = EdgeUtils.run(currImage, EDGE_QUANTITY, EDGE_THICKNESS);

                if (imageWorker.CancellationPending == true)
                {
                    Console.WriteLine("Stopped after Edges");
                    imageWorker.ReportProgress(0);
                    e.Cancel = true;
                    return;
                }

                imageWorker.ReportProgress(90);
                Image<Gray, byte> copy = edges.Copy().Convert<Gray, byte>();
                copy = ~edges.Convert<Gray, byte>();
                copy = copy.ThresholdBinary(new Gray(127), new Gray(255));
                currImage = color.Copy(copy);
                imageWorker.ReportProgress(100);
            }
        }

        private void imageWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void videoWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {}

        private void videoWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Set the progress bar to 1% to show that the process has started
            videoWorker2.ReportProgress(1);
            
            //Re-initialize the caputre - For the stop and start operation function
            currVideo = new Capture(videoFilePath);
            Image<Bgr, byte> currFrame;
            Image<Bgr, Byte> tempImage = currVideo.QueryFrame();
            String outputName = videoFileName + ".avi";

            VideoWriter videoWriter = new VideoWriter(outputName, 25, tempImage.Width, tempImage.Height, true); ; 
            
            double frameCount = currVideo.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_COUNT);
            int i = 0;
            while (true)
            {
                if ((videoWorker2.CancellationPending == true))
                {
                    e.Cancel = true;
                    Console.WriteLine("Video Operations stopped");
                    videoWorker2.ReportProgress(0);
                    break;
                }
                else
                {
                    currFrame = currVideo.QueryFrame();
                    if (currFrame != null)
                    {
                        Console.WriteLine("Processing Frame " + i + " of " + frameCount);
                        Image<Bgr, byte> colors = ColorUtils.run(currFrame, SCALE_FACTOR, BILLATERAL_KERNEL_SIZE, BILLATERAL_ITERATIONS);
                        Image<Bgr, byte> edges = EdgeUtils.run(currFrame, EDGE_QUANTITY, EDGE_THICKNESS);
                        Image<Gray, byte> copy = edges.Copy().Convert<Gray, byte>();
                        copy = ~edges.Convert<Gray, byte>();
                        copy = copy.ThresholdBinary(new Gray(127), new Gray(255));
                        currFrame = colors.Copy(copy);

                        //Show current frame
                        if (showCurrentFrame) { 
                            pictureBox.Image = currFrame.ToBitmap();
                            showCurrentFrame = false;
                        }
                        

                        //if (i % 30 == 0)
                        //    pictureBox.Image = currFrame.ToBitmap();
                        videoWriter.WriteFrame(currFrame);
                        int progress = (int)(i / frameCount * 100);
                        if(progress>1)
                            videoWorker2.ReportProgress(progress);
                        i++;
                    }
                    else
                    {
                        videoWorker2.ReportProgress(100);
                        break;
                    }
                }
            }
        }

        private void videoWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void imageWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox.Image = currImage.ToBitmap();
            updateHistogram();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            videoWorker2.CancelAsync();
            imageWorker.CancelAsync();
        }

        private void histogramWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            histogramData = histogram(currImage);
        }

        private void histogramWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            chart1.Visible = true;
            drawHistogram();
        }

        private void currFrameBtn_Click(object sender, EventArgs e)
        {
            showCurrentFrame = true;
        }
    }
}
