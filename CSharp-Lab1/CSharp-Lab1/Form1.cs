using System.Drawing;

namespace CSharp_Lab1
{
    public partial class Form1 : Form
    {
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog= new OpenFileDialog();
            dialog.Filter = "Image Files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";

            if (dialog.ShowDialog() == DialogResult.OK) { 
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            { 
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[,] matrix = {{1/9, 1/9, 1/9},{ 1 / 9, 1 / 9, 1 / 9 },{ 1 / 9, 1 / 9, 1 / 9 } };
            MatrixFilter filter = new MatrixFilter(matrix);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlackNWhiteFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter(50);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightnessFilter(50);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[,] matrix = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            Filters filter = new MatrixFilter(matrix);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           EmbossingFilter filter= new EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedianFilter filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SobelFilter filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlassFilter filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MotionBlurFilter filter= new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferFilter filter= new TransferFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TurnFilter filter= new TurnFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WavesFilter1 filter = new WavesFilter1();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WavesFilter2 filter = new WavesFilter2();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                kernel = form2.GetRes();
                Filters filter = new TopHatFilter(kernel, 1, 1);
                backgroundWorker1.RunWorkerAsync(filter);
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("����������� ������� �� �����", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}