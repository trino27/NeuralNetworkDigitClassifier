namespace Neuro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxFull = new PictureBox();
            buttonClearImg = new Button();
            label1 = new Label();
            progressBar0 = new ProgressBar();
            richTextBoxInfo = new RichTextBox();
            buttonSave1 = new Button();
            pictureBoxZoomed = new PictureBox();
            label2 = new Label();
            progressBar9 = new ProgressBar();
            label3 = new Label();
            progressBar8 = new ProgressBar();
            label4 = new Label();
            progressBar7 = new ProgressBar();
            label5 = new Label();
            progressBar6 = new ProgressBar();
            label6 = new Label();
            progressBar5 = new ProgressBar();
            label7 = new Label();
            progressBar4 = new ProgressBar();
            label8 = new Label();
            progressBar3 = new ProgressBar();
            label9 = new Label();
            progressBar2 = new ProgressBar();
            label10 = new Label();
            progressBar1 = new ProgressBar();
            buttonSave2 = new Button();
            buttonSave3 = new Button();
            buttonSave4 = new Button();
            buttonSave5 = new Button();
            buttonSave6 = new Button();
            buttonSave7 = new Button();
            buttonSave8 = new Button();
            buttonSave9 = new Button();
            buttonSave0 = new Button();
            buttonClearText = new Button();
            buttonStudyClassifier = new Button();
            buttonCleanClassifierWeights = new Button();
            numericUpDownEpochs = new NumericUpDown();
            labelEpochs = new Label();
            labelLearningRate = new Label();
            trackBar1 = new TrackBar();
            labelLearningRateValue = new Label();
            buttonDraw0 = new Button();
            buttonDraw9 = new Button();
            buttonDraw8 = new Button();
            buttonDraw7 = new Button();
            buttonDraw6 = new Button();
            buttonDraw5 = new Button();
            buttonDraw4 = new Button();
            buttonDraw3 = new Button();
            buttonDraw2 = new Button();
            buttonDraw1 = new Button();
            buttonStudyArtist = new Button();
            buttonCleanWeightsDraw = new Button();
            buttonPredict = new Button();
            checkBoxArtist = new CheckBox();
            checkBoxClassiffier = new CheckBox();
            groupBoxNeuroWeights = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFull).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxZoomed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEpochs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            groupBoxNeuroWeights.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxFull
            // 
            pictureBoxFull.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxFull.BackColor = SystemColors.ControlDark;
            pictureBoxFull.Location = new Point(12, 9);
            pictureBoxFull.MaximumSize = new Size(1024, 512);
            pictureBoxFull.MinimumSize = new Size(1024, 512);
            pictureBoxFull.Name = "pictureBoxFull";
            pictureBoxFull.Size = new Size(1024, 512);
            pictureBoxFull.TabIndex = 0;
            pictureBoxFull.TabStop = false;
            pictureBoxFull.Click += pictureBox_Click;
            pictureBoxFull.MouseDown += pictureBox_MouseDown;
            pictureBoxFull.MouseMove += pictureBox_MouseMove;
            pictureBoxFull.MouseUp += pictureBox_MouseUp;
            // 
            // buttonClearImg
            // 
            buttonClearImg.BackColor = Color.FromArgb(128, 128, 255);
            buttonClearImg.FlatStyle = FlatStyle.Popup;
            buttonClearImg.Location = new Point(1042, 577);
            buttonClearImg.Name = "buttonClearImg";
            buttonClearImg.Size = new Size(195, 51);
            buttonClearImg.TabIndex = 1;
            buttonClearImg.Text = "Clear Img";
            buttonClearImg.UseVisualStyleBackColor = false;
            buttonClearImg.Click += buttonClear_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(939, 570);
            label1.Name = "label1";
            label1.Size = new Size(22, 26);
            label1.TabIndex = 2;
            label1.Text = "0";
            // 
            // progressBar0
            // 
            progressBar0.Location = new Point(958, 570);
            progressBar0.Name = "progressBar0";
            progressBar0.Size = new Size(78, 26);
            progressBar0.TabIndex = 12;
            // 
            // richTextBoxInfo
            // 
            richTextBoxInfo.Location = new Point(1042, 283);
            richTextBoxInfo.Name = "richTextBoxInfo";
            richTextBoxInfo.Size = new Size(195, 238);
            richTextBoxInfo.TabIndex = 22;
            richTextBoxInfo.Text = "";
            // 
            // buttonSave1
            // 
            buttonSave1.Location = new Point(12, 602);
            buttonSave1.Name = "buttonSave1";
            buttonSave1.Size = new Size(97, 26);
            buttonSave1.TabIndex = 23;
            buttonSave1.Text = "Add to DataSet";
            buttonSave1.UseVisualStyleBackColor = true;
            buttonSave1.Click += buttonSave_Click;
            // 
            // pictureBoxZoomed
            // 
            pictureBoxZoomed.BackColor = SystemColors.ActiveCaption;
            pictureBoxZoomed.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxZoomed.Location = new Point(958, 476);
            pictureBoxZoomed.MaximumSize = new Size(64, 32);
            pictureBoxZoomed.MinimumSize = new Size(64, 32);
            pictureBoxZoomed.Name = "pictureBoxZoomed";
            pictureBoxZoomed.Size = new Size(64, 32);
            pictureBoxZoomed.TabIndex = 42;
            pictureBoxZoomed.TabStop = false;
            pictureBoxZoomed.Click += pictureBoxZoomed_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(836, 570);
            label2.Name = "label2";
            label2.Size = new Size(22, 26);
            label2.TabIndex = 43;
            label2.Text = "9";
            // 
            // progressBar9
            // 
            progressBar9.Location = new Point(855, 570);
            progressBar9.Name = "progressBar9";
            progressBar9.Size = new Size(78, 26);
            progressBar9.TabIndex = 44;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(733, 570);
            label3.Name = "label3";
            label3.Size = new Size(22, 26);
            label3.TabIndex = 45;
            label3.Text = "8";
            // 
            // progressBar8
            // 
            progressBar8.Location = new Point(752, 570);
            progressBar8.Name = "progressBar8";
            progressBar8.Size = new Size(78, 26);
            progressBar8.TabIndex = 46;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(630, 570);
            label4.Name = "label4";
            label4.Size = new Size(22, 26);
            label4.TabIndex = 47;
            label4.Text = "7";
            // 
            // progressBar7
            // 
            progressBar7.Location = new Point(649, 570);
            progressBar7.Name = "progressBar7";
            progressBar7.Size = new Size(78, 26);
            progressBar7.TabIndex = 48;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(527, 570);
            label5.Name = "label5";
            label5.Size = new Size(22, 26);
            label5.TabIndex = 49;
            label5.Text = "6";
            // 
            // progressBar6
            // 
            progressBar6.Location = new Point(546, 570);
            progressBar6.Name = "progressBar6";
            progressBar6.Size = new Size(78, 26);
            progressBar6.TabIndex = 50;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(424, 570);
            label6.Name = "label6";
            label6.Size = new Size(22, 26);
            label6.TabIndex = 51;
            label6.Text = "5";
            // 
            // progressBar5
            // 
            progressBar5.ForeColor = Color.Yellow;
            progressBar5.Location = new Point(443, 570);
            progressBar5.Name = "progressBar5";
            progressBar5.Size = new Size(78, 26);
            progressBar5.TabIndex = 52;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(321, 570);
            label7.Name = "label7";
            label7.Size = new Size(22, 26);
            label7.TabIndex = 53;
            label7.Text = "4";
            // 
            // progressBar4
            // 
            progressBar4.Location = new Point(340, 570);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new Size(78, 26);
            progressBar4.TabIndex = 54;
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(218, 570);
            label8.Name = "label8";
            label8.Size = new Size(22, 26);
            label8.TabIndex = 55;
            label8.Text = "3";
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(237, 570);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(78, 26);
            progressBar3.TabIndex = 56;
            // 
            // label9
            // 
            label9.BorderStyle = BorderStyle.FixedSingle;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(115, 570);
            label9.Name = "label9";
            label9.Size = new Size(22, 26);
            label9.TabIndex = 57;
            label9.Text = "2";
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(134, 570);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(78, 26);
            progressBar2.TabIndex = 58;
            // 
            // label10
            // 
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(12, 570);
            label10.Name = "label10";
            label10.Size = new Size(22, 26);
            label10.TabIndex = 59;
            label10.Text = "1";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(31, 570);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(78, 26);
            progressBar1.TabIndex = 60;
            // 
            // buttonSave2
            // 
            buttonSave2.Location = new Point(115, 602);
            buttonSave2.Name = "buttonSave2";
            buttonSave2.Size = new Size(97, 26);
            buttonSave2.TabIndex = 61;
            buttonSave2.Text = "Add to DataSet";
            buttonSave2.UseVisualStyleBackColor = true;
            buttonSave2.Click += buttonSave2_Click;
            // 
            // buttonSave3
            // 
            buttonSave3.Location = new Point(218, 602);
            buttonSave3.Name = "buttonSave3";
            buttonSave3.Size = new Size(97, 26);
            buttonSave3.TabIndex = 62;
            buttonSave3.Text = "Add to DataSet";
            buttonSave3.UseVisualStyleBackColor = true;
            buttonSave3.Click += buttonSave3_Click;
            // 
            // buttonSave4
            // 
            buttonSave4.Location = new Point(321, 602);
            buttonSave4.Name = "buttonSave4";
            buttonSave4.Size = new Size(97, 26);
            buttonSave4.TabIndex = 63;
            buttonSave4.Text = "Add to DataSet";
            buttonSave4.UseVisualStyleBackColor = true;
            buttonSave4.Click += buttonSave4_Click;
            // 
            // buttonSave5
            // 
            buttonSave5.Location = new Point(424, 602);
            buttonSave5.Name = "buttonSave5";
            buttonSave5.Size = new Size(97, 26);
            buttonSave5.TabIndex = 64;
            buttonSave5.Text = "Add to DataSet";
            buttonSave5.UseVisualStyleBackColor = true;
            buttonSave5.Click += buttonSave5_Click;
            // 
            // buttonSave6
            // 
            buttonSave6.Location = new Point(527, 602);
            buttonSave6.Name = "buttonSave6";
            buttonSave6.Size = new Size(97, 26);
            buttonSave6.TabIndex = 65;
            buttonSave6.Text = "Add to DataSet";
            buttonSave6.UseVisualStyleBackColor = true;
            buttonSave6.Click += buttonSave6_Click;
            // 
            // buttonSave7
            // 
            buttonSave7.Location = new Point(630, 602);
            buttonSave7.Name = "buttonSave7";
            buttonSave7.Size = new Size(97, 26);
            buttonSave7.TabIndex = 66;
            buttonSave7.Text = "Add to DataSet";
            buttonSave7.UseVisualStyleBackColor = true;
            buttonSave7.Click += buttonSave7_Click;
            // 
            // buttonSave8
            // 
            buttonSave8.Location = new Point(733, 602);
            buttonSave8.Name = "buttonSave8";
            buttonSave8.Size = new Size(97, 26);
            buttonSave8.TabIndex = 67;
            buttonSave8.Text = "Add to DataSet";
            buttonSave8.UseVisualStyleBackColor = true;
            buttonSave8.Click += buttonSave8_Click;
            // 
            // buttonSave9
            // 
            buttonSave9.Location = new Point(836, 602);
            buttonSave9.Name = "buttonSave9";
            buttonSave9.Size = new Size(97, 26);
            buttonSave9.TabIndex = 68;
            buttonSave9.Text = "Add to DataSet";
            buttonSave9.UseVisualStyleBackColor = true;
            buttonSave9.Click += buttonSave9_Click;
            // 
            // buttonSave0
            // 
            buttonSave0.Location = new Point(939, 602);
            buttonSave0.Name = "buttonSave0";
            buttonSave0.Size = new Size(97, 26);
            buttonSave0.TabIndex = 69;
            buttonSave0.Text = "Add to DataSet";
            buttonSave0.UseVisualStyleBackColor = true;
            buttonSave0.Click += buttonSave0_Click;
            // 
            // buttonClearText
            // 
            buttonClearText.Location = new Point(1042, 480);
            buttonClearText.Name = "buttonClearText";
            buttonClearText.Size = new Size(195, 41);
            buttonClearText.TabIndex = 72;
            buttonClearText.Text = "Clear Text";
            buttonClearText.UseVisualStyleBackColor = true;
            buttonClearText.Click += buttonClearText_Click;
            // 
            // buttonStudyClassifier
            // 
            buttonStudyClassifier.BackColor = Color.FromArgb(128, 128, 255);
            buttonStudyClassifier.FlatStyle = FlatStyle.Popup;
            buttonStudyClassifier.Location = new Point(6, 22);
            buttonStudyClassifier.Name = "buttonStudyClassifier";
            buttonStudyClassifier.Size = new Size(183, 37);
            buttonStudyClassifier.TabIndex = 73;
            buttonStudyClassifier.Text = "Study Classifier";
            buttonStudyClassifier.UseVisualStyleBackColor = false;
            buttonStudyClassifier.Click += buttonStudy_Click;
            // 
            // buttonCleanClassifierWeights
            // 
            buttonCleanClassifierWeights.BackColor = Color.FromArgb(255, 128, 128);
            buttonCleanClassifierWeights.FlatStyle = FlatStyle.Popup;
            buttonCleanClassifierWeights.Location = new Point(6, 64);
            buttonCleanClassifierWeights.Name = "buttonCleanClassifierWeights";
            buttonCleanClassifierWeights.Size = new Size(162, 26);
            buttonCleanClassifierWeights.TabIndex = 76;
            buttonCleanClassifierWeights.Text = "Clean Weights Classiffier";
            buttonCleanClassifierWeights.UseVisualStyleBackColor = false;
            buttonCleanClassifierWeights.Click += buttonCleanWeights_Click;
            // 
            // numericUpDownEpochs
            // 
            numericUpDownEpochs.Location = new Point(1107, 83);
            numericUpDownEpochs.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownEpochs.Name = "numericUpDownEpochs";
            numericUpDownEpochs.Size = new Size(130, 23);
            numericUpDownEpochs.TabIndex = 77;
            numericUpDownEpochs.TextAlign = HorizontalAlignment.Center;
            // 
            // labelEpochs
            // 
            labelEpochs.AutoSize = true;
            labelEpochs.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelEpochs.Location = new Point(1042, 83);
            labelEpochs.Name = "labelEpochs";
            labelEpochs.Size = new Size(59, 20);
            labelEpochs.TabIndex = 79;
            labelEpochs.Text = "Epochs:";
            // 
            // labelLearningRate
            // 
            labelLearningRate.AutoSize = true;
            labelLearningRate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelLearningRate.Location = new Point(1042, 9);
            labelLearningRate.Name = "labelLearningRate";
            labelLearningRate.Size = new Size(103, 20);
            labelLearningRate.TabIndex = 80;
            labelLearningRate.Text = "Learning rate: ";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(1042, 35);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(195, 45);
            trackBar1.TabIndex = 81;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // labelLearningRateValue
            // 
            labelLearningRateValue.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelLearningRateValue.Location = new Point(1141, 9);
            labelLearningRateValue.Name = "labelLearningRateValue";
            labelLearningRateValue.Size = new Size(96, 23);
            labelLearningRateValue.TabIndex = 82;
            // 
            // buttonDraw0
            // 
            buttonDraw0.Location = new Point(939, 527);
            buttonDraw0.Name = "buttonDraw0";
            buttonDraw0.Size = new Size(97, 37);
            buttonDraw0.TabIndex = 92;
            buttonDraw0.Text = "Draw";
            buttonDraw0.UseVisualStyleBackColor = true;
            buttonDraw0.Click += buttonDraw0_Click;
            // 
            // buttonDraw9
            // 
            buttonDraw9.Location = new Point(836, 527);
            buttonDraw9.Name = "buttonDraw9";
            buttonDraw9.Size = new Size(97, 37);
            buttonDraw9.TabIndex = 91;
            buttonDraw9.Text = "Draw";
            buttonDraw9.UseVisualStyleBackColor = true;
            buttonDraw9.Click += buttonDraw9_Click;
            // 
            // buttonDraw8
            // 
            buttonDraw8.Location = new Point(733, 527);
            buttonDraw8.Name = "buttonDraw8";
            buttonDraw8.Size = new Size(97, 37);
            buttonDraw8.TabIndex = 90;
            buttonDraw8.Text = "Draw";
            buttonDraw8.UseVisualStyleBackColor = true;
            buttonDraw8.Click += buttonDraw8_Click;
            // 
            // buttonDraw7
            // 
            buttonDraw7.Location = new Point(630, 527);
            buttonDraw7.Name = "buttonDraw7";
            buttonDraw7.Size = new Size(97, 37);
            buttonDraw7.TabIndex = 89;
            buttonDraw7.Text = "Draw";
            buttonDraw7.UseVisualStyleBackColor = true;
            buttonDraw7.Click += buttonDraw7_Click;
            // 
            // buttonDraw6
            // 
            buttonDraw6.Location = new Point(527, 527);
            buttonDraw6.Name = "buttonDraw6";
            buttonDraw6.Size = new Size(97, 37);
            buttonDraw6.TabIndex = 88;
            buttonDraw6.Text = "Draw";
            buttonDraw6.UseVisualStyleBackColor = true;
            buttonDraw6.Click += buttonDraw6_Click;
            // 
            // buttonDraw5
            // 
            buttonDraw5.Location = new Point(424, 527);
            buttonDraw5.Name = "buttonDraw5";
            buttonDraw5.Size = new Size(97, 37);
            buttonDraw5.TabIndex = 87;
            buttonDraw5.Text = "Draw";
            buttonDraw5.UseVisualStyleBackColor = true;
            buttonDraw5.Click += buttonDraw5_Click;
            // 
            // buttonDraw4
            // 
            buttonDraw4.Location = new Point(321, 527);
            buttonDraw4.Name = "buttonDraw4";
            buttonDraw4.Size = new Size(97, 37);
            buttonDraw4.TabIndex = 86;
            buttonDraw4.Text = "Draw";
            buttonDraw4.UseVisualStyleBackColor = true;
            buttonDraw4.Click += buttonDraw4_Click;
            // 
            // buttonDraw3
            // 
            buttonDraw3.Location = new Point(218, 527);
            buttonDraw3.Name = "buttonDraw3";
            buttonDraw3.Size = new Size(97, 37);
            buttonDraw3.TabIndex = 85;
            buttonDraw3.Text = "Draw";
            buttonDraw3.UseVisualStyleBackColor = true;
            buttonDraw3.Click += buttonDraw3_Click;
            // 
            // buttonDraw2
            // 
            buttonDraw2.Location = new Point(115, 527);
            buttonDraw2.Name = "buttonDraw2";
            buttonDraw2.Size = new Size(97, 37);
            buttonDraw2.TabIndex = 84;
            buttonDraw2.Text = "Draw";
            buttonDraw2.UseVisualStyleBackColor = true;
            buttonDraw2.Click += buttonDraw2_Click;
            // 
            // buttonDraw1
            // 
            buttonDraw1.Location = new Point(12, 527);
            buttonDraw1.Name = "buttonDraw1";
            buttonDraw1.Size = new Size(97, 37);
            buttonDraw1.TabIndex = 83;
            buttonDraw1.Text = "Draw";
            buttonDraw1.UseVisualStyleBackColor = true;
            buttonDraw1.Click += buttonDraw1_Click;
            // 
            // buttonStudyArtist
            // 
            buttonStudyArtist.BackColor = Color.FromArgb(128, 128, 255);
            buttonStudyArtist.FlatStyle = FlatStyle.Popup;
            buttonStudyArtist.Location = new Point(6, 96);
            buttonStudyArtist.Name = "buttonStudyArtist";
            buttonStudyArtist.Size = new Size(183, 37);
            buttonStudyArtist.TabIndex = 93;
            buttonStudyArtist.Text = "Study Artist";
            buttonStudyArtist.UseVisualStyleBackColor = false;
            buttonStudyArtist.Click += buttonStudyDraw_Click;
            // 
            // buttonCleanWeightsDraw
            // 
            buttonCleanWeightsDraw.BackColor = Color.FromArgb(255, 128, 128);
            buttonCleanWeightsDraw.FlatStyle = FlatStyle.Popup;
            buttonCleanWeightsDraw.Location = new Point(6, 139);
            buttonCleanWeightsDraw.Name = "buttonCleanWeightsDraw";
            buttonCleanWeightsDraw.Size = new Size(162, 26);
            buttonCleanWeightsDraw.TabIndex = 94;
            buttonCleanWeightsDraw.Text = "Clean Weights Artist";
            buttonCleanWeightsDraw.UseVisualStyleBackColor = false;
            buttonCleanWeightsDraw.Click += buttonCleanWeightsDraw_Click;
            // 
            // buttonPredict
            // 
            buttonPredict.BackColor = Color.FromArgb(128, 128, 255);
            buttonPredict.FlatStyle = FlatStyle.Popup;
            buttonPredict.Location = new Point(1042, 527);
            buttonPredict.Name = "buttonPredict";
            buttonPredict.Size = new Size(195, 47);
            buttonPredict.TabIndex = 95;
            buttonPredict.Text = "Predict";
            buttonPredict.UseVisualStyleBackColor = false;
            buttonPredict.Click += buttonPredict_Click;
            // 
            // checkBoxArtist
            // 
            checkBoxArtist.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxArtist.Location = new Point(174, 144);
            checkBoxArtist.Name = "checkBoxArtist";
            checkBoxArtist.Size = new Size(15, 21);
            checkBoxArtist.TabIndex = 96;
            checkBoxArtist.UseVisualStyleBackColor = true;
            // 
            // checkBoxClassiffier
            // 
            checkBoxClassiffier.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxClassiffier.Location = new Point(174, 69);
            checkBoxClassiffier.Name = "checkBoxClassiffier";
            checkBoxClassiffier.Size = new Size(15, 21);
            checkBoxClassiffier.TabIndex = 97;
            checkBoxClassiffier.UseVisualStyleBackColor = true;
            // 
            // groupBoxNeuroWeights
            // 
            groupBoxNeuroWeights.Controls.Add(checkBoxArtist);
            groupBoxNeuroWeights.Controls.Add(checkBoxClassiffier);
            groupBoxNeuroWeights.Controls.Add(buttonStudyClassifier);
            groupBoxNeuroWeights.Controls.Add(buttonCleanWeightsDraw);
            groupBoxNeuroWeights.Controls.Add(buttonCleanClassifierWeights);
            groupBoxNeuroWeights.Controls.Add(buttonStudyArtist);
            groupBoxNeuroWeights.Location = new Point(1042, 106);
            groupBoxNeuroWeights.Name = "groupBoxNeuroWeights";
            groupBoxNeuroWeights.Size = new Size(195, 171);
            groupBoxNeuroWeights.TabIndex = 98;
            groupBoxNeuroWeights.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 635);
            Controls.Add(buttonPredict);
            Controls.Add(buttonDraw0);
            Controls.Add(buttonDraw9);
            Controls.Add(buttonDraw8);
            Controls.Add(buttonDraw7);
            Controls.Add(buttonDraw6);
            Controls.Add(buttonDraw5);
            Controls.Add(buttonDraw4);
            Controls.Add(buttonDraw3);
            Controls.Add(buttonDraw2);
            Controls.Add(buttonDraw1);
            Controls.Add(labelLearningRateValue);
            Controls.Add(trackBar1);
            Controls.Add(labelLearningRate);
            Controls.Add(labelEpochs);
            Controls.Add(numericUpDownEpochs);
            Controls.Add(buttonClearText);
            Controls.Add(buttonSave0);
            Controls.Add(buttonSave9);
            Controls.Add(buttonSave8);
            Controls.Add(buttonSave7);
            Controls.Add(buttonSave6);
            Controls.Add(buttonSave5);
            Controls.Add(buttonSave4);
            Controls.Add(buttonSave3);
            Controls.Add(buttonSave2);
            Controls.Add(label10);
            Controls.Add(progressBar1);
            Controls.Add(label9);
            Controls.Add(progressBar2);
            Controls.Add(label8);
            Controls.Add(progressBar3);
            Controls.Add(label7);
            Controls.Add(progressBar4);
            Controls.Add(label6);
            Controls.Add(progressBar5);
            Controls.Add(label5);
            Controls.Add(progressBar6);
            Controls.Add(label4);
            Controls.Add(progressBar7);
            Controls.Add(label3);
            Controls.Add(progressBar8);
            Controls.Add(label2);
            Controls.Add(progressBar9);
            Controls.Add(pictureBoxZoomed);
            Controls.Add(buttonSave1);
            Controls.Add(richTextBoxInfo);
            Controls.Add(label1);
            Controls.Add(buttonClearImg);
            Controls.Add(pictureBoxFull);
            Controls.Add(progressBar0);
            Controls.Add(groupBoxNeuroWeights);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxFull).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxZoomed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEpochs).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            groupBoxNeuroWeights.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxFull;
        private Button buttonClearImg;
        private Label label1;
        private ProgressBar progressBar0;
        private RichTextBox richTextBoxInfo;
        private Button buttonSave1;
        private PictureBox pictureBoxZoomed;
        private Label label2;
        private ProgressBar progressBar9;
        private Label label3;
        private ProgressBar progressBar8;
        private Label label4;
        private ProgressBar progressBar7;
        private Label label5;
        private ProgressBar progressBar6;
        private Label label6;
        private ProgressBar progressBar5;
        private Label label7;
        private ProgressBar progressBar4;
        private Label label8;
        private ProgressBar progressBar3;
        private Label label9;
        private ProgressBar progressBar2;
        private Label label10;
        private ProgressBar progressBar1;
        private Button buttonSave2;
        private Button buttonSave3;
        private Button buttonSave4;
        private Button buttonSave5;
        private Button buttonSave6;
        private Button buttonSave7;
        private Button buttonSave8;
        private Button buttonSave9;
        private Button buttonSave0;
        private Button buttonClearText;
        private Button buttonStudyClassifier;
        private Button buttonCleanClassifierWeights;
        private NumericUpDown numericUpDownEpochs;
        private Label labelEpochs;
        private Label labelLearningRate;
        private TrackBar trackBar1;
        private Label labelLearningRateValue;
        private Button buttonDraw0;
        private Button buttonDraw9;
        private Button buttonDraw8;
        private Button buttonDraw7;
        private Button buttonDraw6;
        private Button buttonDraw5;
        private Button buttonDraw4;
        private Button buttonDraw3;
        private Button buttonDraw2;
        private Button buttonDraw1;
        private Button buttonStudyArtist;
        private Button buttonCleanWeightsDraw;
        private Button buttonPredict;
        private CheckBox checkBoxArtist;
        private CheckBox checkBoxClassiffier;
        private GroupBox groupBoxNeuroWeights;
    }
}