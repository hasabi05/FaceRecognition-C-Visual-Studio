using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {
        Capture capture;
        CascadeClassifier cascade;
        bool captureProgress;

        public Form1()
        {
            InitializeComponent();
            cascade = new CascadeClassifier("haarcascade_frontalface_default.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            if (capture != null)
            {
                if (captureProgress)
                {
                   
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    Application.Idle += ProcessFrame;
                }
                captureProgress = !captureProgress;
            }
        }
        private void ProcessFrame(Object sender, EventArgs arg)
        {

            Mat ImageFrame = new Mat();
            ImageFrame = capture.QueryFrame();
            Rectangle[] detectedFaces = cascade.DetectMultiScale(ImageFrame);
            foreach (Rectangle r in detectedFaces)
            {

                CvInvoke.Rectangle(ImageFrame, r, new Bgr(Color.Red).MCvScalar, 2);

            }
            imageBox1.Image = ImageFrame;

        }
        private void ReleaseData()
        {
            if (capture != null)
            {
                capture.Dispose();
            }
        }


        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}




