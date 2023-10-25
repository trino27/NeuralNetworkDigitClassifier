using System.Drawing.Imaging;

namespace NeuroTest1
{
    public partial class Form1 : Form
    {
        private Mutex mutex = new Mutex();

        private Bitmap bitmapZoomed;
        private Bitmap bitmapFull;
        private const int zoom = 16;

        private Graphics graficFull;
        private Graphics graficZoomed;
        private readonly Color foregroundColor = Color.White;

        private Pen pen;
        private const int penSize = zoom * 2 + 3;
        private readonly Color penColor = Color.Black;

        private Point p1, p2;

        private bool paint = false;

        private NeuroNetwork network;
        public NeuroTeacher teacher;

        private string dataSetDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSet");

        public Form1()
        {
            InitializeComponent();

            bitmapZoomed = new Bitmap(pictureBoxFull.Width / zoom, pictureBoxFull.Height / zoom);
            bitmapFull = new Bitmap(pictureBoxFull.Width, pictureBoxFull.Height);

            graficFull = Graphics.FromImage(bitmapFull);
            graficFull.Clear(foregroundColor);
            for (int x = 0; x < pictureBoxFull.Width; x += zoom)
            {
                for (int y = 0; y < pictureBoxFull.Height; y += zoom)
                {
                    bitmapFull.SetPixel(x, y, Color.Red);
                }
            }
            pictureBoxFull.Refresh();

            graficZoomed = Graphics.FromImage(bitmapZoomed);
            graficZoomed.Clear(foregroundColor);

            pen = new Pen(penColor, penSize);

            pictureBoxFull.Image = bitmapFull;
            pictureBoxZoomed.Image = bitmapZoomed;

            network = new NeuroNetwork();

            trackBar1.Maximum = 1000;
            trackBar1.Minimum = 1;
            trackBar1.Value = 100;

            labelLearningRateValue.Text = ((double)trackBar1.Value / 100_000D).ToString();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            buttonStudy.Visible = false;
            buttonCleanWeights.Visible = false;
            Console.WriteLine(">>Loading weights...");
            Task task = new Task(() =>
            {
                if (network.LoadWeightsIfExists())
                {
                    Console.WriteLine(">>>Load SUCCESS!");
                }
                else
                {
                    Console.WriteLine(">>>Load FAILED!");
                }
            });
            task.Start();
            await task;
            buttonStudy.Visible = task.IsCompleted;
            buttonCleanWeights.Visible = task.IsCompleted;
        }

        private async void pictureBox_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();
            await Task.Run(() =>
            {
                int i = 0;
                for (int x = 0; x < pictureBoxFull.Width; x += zoom)
                {
                    int j = 0;
                    for (int y = 0; y < pictureBoxFull.Height; y += zoom)
                    {
                        if (bitmapFull.GetPixel(x, y).ToArgb() == penColor.ToArgb())
                        {
                            bitmapZoomed.SetPixel(i, j, penColor);
                        }
                        j++;
                    }
                    i++;
                }
            });

            int maxDigit = 0;
            double maxDigitWeight = -1;
            double[] outputs = network.FeedForward(bitmapZoomed);

            for (int k = 0; k < 10; k++)
            {
                if (outputs[k] > maxDigitWeight)
                {
                    maxDigitWeight = outputs[k];
                    maxDigit = k;
                }
            }


            progressBar0.Value = Convert.ToInt32(outputs[0] * 100);
            progressBar1.Value = Convert.ToInt32(outputs[1] * 100);
            progressBar2.Value = Convert.ToInt32(outputs[2] * 100);
            progressBar3.Value = Convert.ToInt32(outputs[3] * 100);
            progressBar4.Value = Convert.ToInt32(outputs[4] * 100);
            progressBar5.Value = Convert.ToInt32(outputs[5] * 100);
            progressBar6.Value = Convert.ToInt32(outputs[6] * 100);
            progressBar7.Value = Convert.ToInt32(outputs[7] * 100);
            progressBar8.Value = Convert.ToInt32(outputs[8] * 100);
            progressBar9.Value = Convert.ToInt32(outputs[9] * 100);

            richTextBoxInfo.Text += "Answer: " + maxDigit + "\n";
            pictureBoxZoomed.Refresh();
            mutex.ReleaseMutex();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            graficFull.Clear(foregroundColor);
            for (int x = 0; x < pictureBoxFull.Width; x += zoom)
            {
                for (int y = 0; y < pictureBoxFull.Height; y += zoom)
                {
                    bitmapFull.SetPixel(x, y, Color.Red);
                }
            }
            pictureBoxFull.Refresh();

            graficZoomed.Clear(foregroundColor);
            pictureBoxZoomed.Refresh();


            progressBar0.Value = 0;
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            progressBar5.Value = 0;
            progressBar6.Value = 0;
            progressBar7.Value = 0;
            progressBar8.Value = 0;
            progressBar9.Value = 0;
        }

        private void buttonClearText_Click(object sender, EventArgs e)
        {
            richTextBoxInfo.Text = "";
        }

        private async void buttonStudy_Click(object sender, EventArgs e)
        {
            buttonStudy.Visible = false;
            buttonCleanWeights.Visible = false;

            Task task = new Task(() =>
            {
                Console.WriteLine(">>Start teaching!");

                teacher = new NeuroTeacher(Convert.ToDouble(labelLearningRateValue.Text), network);
                teacher.Teach((int)numericUpDownEpochs.Value);

                Console.WriteLine(">>Finish teaching!");
            });
            task.Start();
            await task;
            buttonStudy.Visible = task.IsCompleted;
            buttonCleanWeights.Visible = task.IsCompleted;
        }
        private async void buttonCleanWeights_Click(object sender, EventArgs e)
        {
            buttonStudy.Visible = false;
            buttonCleanWeights.Visible = false;
            Task task = new Task(() =>
            {
                network.CleanWeights();
            });
            task.Start();
            await task;
            buttonStudy.Visible = task.IsCompleted;
            buttonCleanWeights.Visible = task.IsCompleted;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {

                if (e.Location.X % 2 == 0 && e.Location.Y % 2 == 0)
                {
                    Task.Run(() =>
                    {
                        mutex.WaitOne();

                        p1 = e.Location;
                        p2 = p1;
                        p2.Offset(penSize - 1, 0);
                        graficFull.DrawLine(pen, p1, p2);

                        mutex.ReleaseMutex();
                    });
                }
                else if (e.Location.X % 2 != 0 && e.Location.Y % 2 == 0)
                {
                    Task.Run(() =>
                    {
                        mutex.WaitOne();

                        p1 = e.Location;
                        p2 = p1;
                        p2.Offset(penSize - 1, 0);
                        graficFull.DrawLine(pen, p1, p2);

                        mutex.ReleaseMutex();
                    });
                }
                else if (e.Location.X % 2 == 0 && e.Location.Y % 2 != 0)
                {
                    Task.Run(() =>
                    {
                        mutex.WaitOne();

                        p1 = e.Location;
                        p2 = p1;
                        p2.Offset(penSize - 1, 0);
                        graficFull.DrawLine(pen, p1, p2);

                        mutex.ReleaseMutex();

                    });
                }
                else if (e.Location.X % 2 != 0 && e.Location.Y % 2 != 0)
                {
                    Task.Run(() =>
                    {
                        mutex.WaitOne();

                        p1 = e.Location;
                        p2 = p1;
                        p2.Offset(penSize - 1, 0);
                        graficFull.DrawLine(pen, p1, p2);

                        mutex.ReleaseMutex();

                    });
                }

                pictureBoxFull.Refresh();
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_1";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_1";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }

        }
        private void buttonSave2_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_2";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_2";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }
        private void buttonSave3_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_3";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_3";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }
        private void buttonSave4_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_4";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_4";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }
        private void buttonSave5_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_5";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_5";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }
        private void buttonSave6_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_6";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_6";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }
        private void buttonSave7_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_7";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_7";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }
        private void buttonSave8_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_8";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_8";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }
        private void buttonSave9_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_9";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_9";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }
        private void buttonSave0_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            if (Directory.Exists(dataSetDirectoryPath))
            {
                string[] files = Directory.GetFiles(dataSetDirectoryPath);
                fileCount = files.Length;

                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_0";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine("File saved " + fileName + " )");
                Console.WriteLine($"Number of files: {fileCount + 1}");
            }
            else
            {
                Directory.CreateDirectory(dataSetDirectoryPath);
                Console.WriteLine(">>Directory Created.");
                string fileName = "DataSet_N" + Convert.ToString(fileCount) + "_0";

                bitmapZoomed.Save(Path.Combine(dataSetDirectoryPath, fileName), ImageFormat.Bmp);

                Console.WriteLine(">>>File saved " + fileName + " )!");
                Console.WriteLine($">>Number of files: {fileCount + 1}");
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelLearningRateValue.Text = Convert.ToString((double)trackBar1.Value / (double)100_000);
        }
    }
}