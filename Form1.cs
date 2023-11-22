using System.Drawing;
using System.Drawing.Imaging;
using NeuroDigits.NeuralNetwork;
using NeuroDigits.NeuralNetwork.Teachers;

namespace Neuro
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

        private NeuralNetworkModel networkClassifier;
        private NeuralNetworkModel networkArtist;

        public NeuroTeacherClassifier teacherClassifier;
        public NeuroTeacherArtist teacherArtist;

        private string dataSetDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSet");

        public Form1()
        {
            InitializeComponent();

            bitmapZoomed = new Bitmap(pictureBoxFull.Width / zoom, pictureBoxFull.Height / zoom);
            bitmapFull = new Bitmap(pictureBoxFull.Width, pictureBoxFull.Height);

            graficFull = Graphics.FromImage(bitmapFull);
            graficFull.Clear(foregroundColor);

            DrawNet();

            graficZoomed = Graphics.FromImage(bitmapZoomed);
            graficZoomed.Clear(foregroundColor);

            pen = new Pen(penColor, penSize);

            pictureBoxFull.Image = bitmapFull;
            pictureBoxZoomed.Image = bitmapZoomed;

            NetworksConfig();

            trackBar1.Maximum = 1000;
            trackBar1.Minimum = 1;
            trackBar1.Value = 100;

            labelLearningRateValue.Text = ((double)trackBar1.Value / 100_000D).ToString();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxFull.MinimumSize = new Size(1024, 512);
            pictureBoxZoomed.MinimumSize = new Size(64, 32);

            groupBoxNeuroWeights.Visible = false;

            Console.WriteLine(">>Loading Classifier Weights...");
            Task task = new Task(() =>
            {
                if (networkClassifier.LoadWeightsIfExists())
                {
                    Console.WriteLine(">>>Load Classifier SUCCESS!");
                }
                else
                {
                    Console.WriteLine(">>>Load Classifier FAILED!");
                }
            });
            task.Start();

            Console.WriteLine(">>Loading Artist Weights...");
            Task task2 = new Task(() =>
            {
                if (networkArtist.LoadWeightsIfExists())
                {
                    Console.WriteLine(">>>Load Artist SUCCESS!");
                }
                else
                {
                    Console.WriteLine(">>>Load Artist FAILED!");
                }
            });
            task2.Start();

            await task;
            await task2;

            groupBoxNeuroWeights.Visible = task2.IsCompleted;
        }

        private void NetworksConfig()
        {
            int[] LayersClassifire =
            {
                2048,

                4096,
                1024,
                1024,
                2048,

                10
            };
            Console.WriteLine(">>>Create Classifier");
            networkClassifier = new NeuralNetworkModel("layersClassifier.xml", LayersClassifire);

            int[] LayersArtist =
            {
                10,

                512,
                1024,
                1024,

                2048
            };
            Console.WriteLine(">>>Create Artist");
            networkArtist = new NeuralNetworkModel("layersArtist.xml", LayersArtist);
        }

        private double[] BitmapToDouble(Bitmap bitmap)
        {
            double[] res = new double[bitmap.Width * bitmap.Height];
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    res[x * bitmap.Height + y] = (pixel.ToArgb() == Color.Black.ToArgb()) ? 1 : 0;
                }
            }
            if (bitmap.Width != 64 || bitmap.Height != 32)
            {
                throw new Exception("Uncorrect bitmap size! Should be - (64; 32)");
            }
            return res;
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

            buttonPredict_Click(sender, e);

            pictureBoxZoomed.Refresh();
            mutex.ReleaseMutex();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            graficFull.Clear(foregroundColor);
            DrawNet();

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
            groupBoxNeuroWeights.Visible = false;

            Task task = new Task(() =>
            {
                Console.WriteLine(">>Start teaching!");

                teacherClassifier = new NeuroTeacherClassifier(Convert.ToDouble(labelLearningRateValue.Text), networkClassifier, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSet"));
                teacherClassifier.Teach((int)numericUpDownEpochs.Value);

                Console.WriteLine(">>Finish teaching!");
            });
            task.Start();
            await task;
            groupBoxNeuroWeights.Visible = true;
        }
        private async void buttonCleanWeights_Click(object sender, EventArgs e)
        {
            if (checkBoxArtist.Checked)
            {
                groupBoxNeuroWeights.Visible  = false;

                Task task = new Task(() =>
                {
                    networkClassifier.CleanWeights();
                });
                task.Start();

                await task;
                groupBoxNeuroWeights.Visible = true;
            }
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
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
            buttonClear_Click(sender, e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelLearningRateValue.Text = Convert.ToString((double)trackBar1.Value / (double)100_000);
        }

        private void DrawNet()
        {
            for (int x = 0; x < pictureBoxFull.Width; x++)
            {
                bitmapFull.SetPixel(x, pictureBoxFull.Height / zoom, Color.Gray);
            }
            for (int x = 0; x < pictureBoxFull.Width; x++)
            {
                bitmapFull.SetPixel(x, pictureBoxFull.Height - pictureBoxFull.Height / zoom, Color.Gray);
            }

            for (int y = 0; y < pictureBoxFull.Height; y++)
            {
                bitmapFull.SetPixel(pictureBoxFull.Width / zoom * 4, y, Color.Gray);
            }
            for (int y = 0; y < pictureBoxFull.Height; y++)
            {
                bitmapFull.SetPixel(pictureBoxFull.Width - pictureBoxFull.Width / zoom * 4, y, Color.Gray);
            }


            for (int x = 0; x < pictureBoxFull.Width; x += zoom)
            {
                for (int y = 0; y < pictureBoxFull.Height; y += zoom)
                {
                    bitmapFull.SetPixel(x, y, Color.Red);
                }
            }

            pictureBoxFull.Refresh();
        }

        private void pictureBoxZoomed_Click(object sender, EventArgs e)
        {

        }

        private void DrawNumber(int number)
        {
            mutex.WaitOne();


            double[] inputs = new double[networkArtist.layersSizes[0]];
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = 0;
            }
            inputs[number] = number;


            double[] outputs = networkArtist.FeedForward(inputs);

            for (int i = 0; i < outputs.Length; i++)
            {
                if (outputs[i] > 0.8)
                {
                    bitmapZoomed.SetPixel(i / bitmapZoomed.Height, i % bitmapZoomed.Height, Color.Black);

                    p1 = new Point(i / bitmapZoomed.Height * zoom, i % bitmapZoomed.Height * zoom);
                    p2 = p1;
                    p2.Offset(penSize / 2, 0);
                    graficFull.DrawLine(pen, p1, p2);
                }
            }

            DrawNet();

            pictureBoxZoomed.Refresh();
            pictureBoxFull.Refresh();
            mutex.ReleaseMutex();
        }

        private void buttonDraw1_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(1);
        }
        private void buttonDraw2_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(2);
        }
        private void buttonDraw3_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(3);
        }
        private void buttonDraw4_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(4);
        }
        private void buttonDraw5_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(5);
        }
        private void buttonDraw6_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(6);
        }
        private void buttonDraw7_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(7);
        }
        private void buttonDraw8_Click(object sender, EventArgs e)
        {
            DrawNumber(8);
        }
        private void buttonDraw9_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(9);
        }
        private void buttonDraw0_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            DrawNumber(0);
        }

        private async void buttonStudyDraw_Click(object sender, EventArgs e)
        {
            groupBoxNeuroWeights.Visible = false;

            Task task = new Task(() =>
            {
                Console.WriteLine(">>Start teaching!");

                teacherArtist = new NeuroTeacherArtist(Convert.ToDouble(labelLearningRateValue.Text), networkArtist, networkClassifier, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataSet"));
                teacherArtist.Teach((int)numericUpDownEpochs.Value);

                Console.WriteLine(">>Finish teaching!");
            });
            task.Start();
            await task;
            groupBoxNeuroWeights.Visible = true;
        }

        private async void buttonCleanWeightsDraw_Click(object sender, EventArgs e)
        {
            if (checkBoxArtist.Checked)
            {
                groupBoxNeuroWeights.Visible = false;

                Task task = new Task(() =>
                {
                    networkArtist.CleanWeights();
                });
                task.Start();

                await task;
                groupBoxNeuroWeights.Visible = true;
            }
        }

        private void buttonPredict_Click(object sender, EventArgs e)
        {

            int maxDigit = 0;
            double maxDigitWeight = -1;
            double[] outputs = networkClassifier.FeedForward(BitmapToDouble(bitmapZoomed));

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

            richTextBoxInfo.Text = "Answer: " + maxDigit + "\n" + richTextBoxInfo.Text;
        }

    }
}