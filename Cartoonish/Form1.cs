using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Windows.Forms;

namespace Cartoonish
{
    public partial class Form1 : Form
    {

        private const string FILE_TYPES = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|TIFF Files (*.tif)|*.tif";
        private string img1FilePath;
        private string img1FileName;
        private Image<Bgr, Byte> origImage;
        private Image<Bgr, Byte> currImage;


        public Form1()
        {
            InitializeComponent();
        }

        public Boolean checkImageUploaded()
        {
            error.Clear();
            if (currImage == null)
            {
                error.SetError(loadBtn, "Upload an image!");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = FILE_TYPES;
            dialog.Title = "Please select an image file.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                img1FileName = dialog.SafeFileName;
                img1FilePath = dialog.FileName;
                origImage = new Image<Bgr, byte>(dialog.FileName);
                currImage = origImage.Copy();
                pictureBox.Image = origImage.ToBitmap();
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (!(origImage == null))
            {
                pictureBox.Image = origImage.ToBitmap();
                currImage = origImage.Copy();
            }
            if (checkImageUploaded())
            {
                //updateHistogram();
                //updateDFT();
            }
            error.Clear();
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            currImage = ColorUtils.run(currImage).Copy();
            pictureBox.Image = currImage.ToBitmap();
        }

        private void edgebtn_Click(object sender, EventArgs e)
        {
            currImage = EdgeUtils.run(currImage).Copy();
            pictureBox.Image = currImage.ToBitmap();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            currImage = ColorUtils.run(currImage).Copy();
            currImage = EdgeUtils.run(currImage).Copy();
            pictureBox.Image = currImage.ToBitmap();
        }
    }
}
