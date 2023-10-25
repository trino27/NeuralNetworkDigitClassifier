namespace NeuroTest1
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
            buttonStudy = new Button();
            buttonCleanWeights = new Button();
            numericUpDownEpochs = new NumericUpDown();
            labelEpochs = new Label();
            labelLearningRate = new Label();
            trackBar1 = new TrackBar();
            labelLearningRateValue = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFull).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxZoomed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEpochs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
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
            buttonClearImg.Location = new Point(1044, 9);
            buttonClearImg.Name = "buttonClearImg";
            buttonClearImg.Size = new Size(195, 67);
            buttonClearImg.TabIndex = 1;
            buttonClearImg.Text = "Clear Img";
            buttonClearImg.UseVisualStyleBackColor = false;
            buttonClearImg.Click += buttonClear_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(939, 527);
            label1.Name = "label1";
            label1.Size = new Size(22, 26);
            label1.TabIndex = 2;
            label1.Text = "0";
            // 
            // progressBar0
            // 
            progressBar0.Location = new Point(958, 527);
            progressBar0.Name = "progressBar0";
            progressBar0.Size = new Size(78, 26);
            progressBar0.TabIndex = 12;
            // 
            // richTextBoxInfo
            // 
            richTextBoxInfo.Location = new Point(1044, 82);
            richTextBoxInfo.Name = "richTextBoxInfo";
            richTextBoxInfo.Size = new Size(195, 223);
            richTextBoxInfo.TabIndex = 22;
            richTextBoxInfo.Text = "";
            // 
            // buttonSave1
            // 
            buttonSave1.Location = new Point(12, 559);
            buttonSave1.Name = "buttonSave1";
            buttonSave1.Size = new Size(97, 26);
            buttonSave1.TabIndex = 23;
            buttonSave1.Text = "Save";
            buttonSave1.UseVisualStyleBackColor = true;
            buttonSave1.Click += buttonSave_Click;
            // 
            // pictureBoxZoomed
            // 
            pictureBoxZoomed.BackColor = SystemColors.ActiveCaption;
            pictureBoxZoomed.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxZoomed.Location = new Point(958, 478);
            pictureBoxZoomed.MaximumSize = new Size(64, 32);
            pictureBoxZoomed.MinimumSize = new Size(64, 32);
            pictureBoxZoomed.Name = "pictureBoxZoomed";
            pictureBoxZoomed.Size = new Size(64, 32);
            pictureBoxZoomed.TabIndex = 42;
            pictureBoxZoomed.TabStop = false;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(836, 527);
            label2.Name = "label2";
            label2.Size = new Size(22, 26);
            label2.TabIndex = 43;
            label2.Text = "9";
            // 
            // progressBar9
            // 
            progressBar9.Location = new Point(855, 527);
            progressBar9.Name = "progressBar9";
            progressBar9.Size = new Size(78, 26);
            progressBar9.TabIndex = 44;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(733, 527);
            label3.Name = "label3";
            label3.Size = new Size(22, 26);
            label3.TabIndex = 45;
            label3.Text = "8";
            // 
            // progressBar8
            // 
            progressBar8.Location = new Point(752, 527);
            progressBar8.Name = "progressBar8";
            progressBar8.Size = new Size(78, 26);
            progressBar8.TabIndex = 46;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(630, 527);
            label4.Name = "label4";
            label4.Size = new Size(22, 26);
            label4.TabIndex = 47;
            label4.Text = "7";
            // 
            // progressBar7
            // 
            progressBar7.Location = new Point(649, 527);
            progressBar7.Name = "progressBar7";
            progressBar7.Size = new Size(78, 26);
            progressBar7.TabIndex = 48;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(527, 527);
            label5.Name = "label5";
            label5.Size = new Size(22, 26);
            label5.TabIndex = 49;
            label5.Text = "6";
            // 
            // progressBar6
            // 
            progressBar6.Location = new Point(546, 527);
            progressBar6.Name = "progressBar6";
            progressBar6.Size = new Size(78, 26);
            progressBar6.TabIndex = 50;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(424, 527);
            label6.Name = "label6";
            label6.Size = new Size(22, 26);
            label6.TabIndex = 51;
            label6.Text = "5";
            // 
            // progressBar5
            // 
            progressBar5.ForeColor = Color.Yellow;
            progressBar5.Location = new Point(443, 527);
            progressBar5.Name = "progressBar5";
            progressBar5.Size = new Size(78, 26);
            progressBar5.TabIndex = 52;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(321, 527);
            label7.Name = "label7";
            label7.Size = new Size(22, 26);
            label7.TabIndex = 53;
            label7.Text = "4";
            // 
            // progressBar4
            // 
            progressBar4.Location = new Point(340, 527);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new Size(78, 26);
            progressBar4.TabIndex = 54;
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(218, 527);
            label8.Name = "label8";
            label8.Size = new Size(22, 26);
            label8.TabIndex = 55;
            label8.Text = "3";
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(237, 527);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(78, 26);
            progressBar3.TabIndex = 56;
            // 
            // label9
            // 
            label9.BorderStyle = BorderStyle.FixedSingle;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(115, 527);
            label9.Name = "label9";
            label9.Size = new Size(22, 26);
            label9.TabIndex = 57;
            label9.Text = "2";
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(134, 527);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(78, 26);
            progressBar2.TabIndex = 58;
            // 
            // label10
            // 
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(12, 527);
            label10.Name = "label10";
            label10.Size = new Size(22, 26);
            label10.TabIndex = 59;
            label10.Text = "1";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(31, 527);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(78, 26);
            progressBar1.TabIndex = 60;
            // 
            // buttonSave2
            // 
            buttonSave2.Location = new Point(115, 559);
            buttonSave2.Name = "buttonSave2";
            buttonSave2.Size = new Size(97, 26);
            buttonSave2.TabIndex = 61;
            buttonSave2.Text = "Save";
            buttonSave2.UseVisualStyleBackColor = true;
            buttonSave2.Click += buttonSave2_Click;
            // 
            // buttonSave3
            // 
            buttonSave3.Location = new Point(218, 559);
            buttonSave3.Name = "buttonSave3";
            buttonSave3.Size = new Size(97, 26);
            buttonSave3.TabIndex = 62;
            buttonSave3.Text = "Save";
            buttonSave3.UseVisualStyleBackColor = true;
            buttonSave3.Click += buttonSave3_Click;
            // 
            // buttonSave4
            // 
            buttonSave4.Location = new Point(321, 559);
            buttonSave4.Name = "buttonSave4";
            buttonSave4.Size = new Size(97, 26);
            buttonSave4.TabIndex = 63;
            buttonSave4.Text = "Save";
            buttonSave4.UseVisualStyleBackColor = true;
            buttonSave4.Click += buttonSave4_Click;
            // 
            // buttonSave5
            // 
            buttonSave5.Location = new Point(424, 559);
            buttonSave5.Name = "buttonSave5";
            buttonSave5.Size = new Size(97, 26);
            buttonSave5.TabIndex = 64;
            buttonSave5.Text = "Save";
            buttonSave5.UseVisualStyleBackColor = true;
            buttonSave5.Click += buttonSave5_Click;
            // 
            // buttonSave6
            // 
            buttonSave6.Location = new Point(527, 559);
            buttonSave6.Name = "buttonSave6";
            buttonSave6.Size = new Size(97, 26);
            buttonSave6.TabIndex = 65;
            buttonSave6.Text = "Save";
            buttonSave6.UseVisualStyleBackColor = true;
            buttonSave6.Click += buttonSave6_Click;
            // 
            // buttonSave7
            // 
            buttonSave7.Location = new Point(630, 559);
            buttonSave7.Name = "buttonSave7";
            buttonSave7.Size = new Size(97, 26);
            buttonSave7.TabIndex = 66;
            buttonSave7.Text = "Save";
            buttonSave7.UseVisualStyleBackColor = true;
            buttonSave7.Click += buttonSave7_Click;
            // 
            // buttonSave8
            // 
            buttonSave8.Location = new Point(733, 559);
            buttonSave8.Name = "buttonSave8";
            buttonSave8.Size = new Size(97, 26);
            buttonSave8.TabIndex = 67;
            buttonSave8.Text = "Save";
            buttonSave8.UseVisualStyleBackColor = true;
            buttonSave8.Click += buttonSave8_Click;
            // 
            // buttonSave9
            // 
            buttonSave9.Location = new Point(836, 559);
            buttonSave9.Name = "buttonSave9";
            buttonSave9.Size = new Size(97, 26);
            buttonSave9.TabIndex = 68;
            buttonSave9.Text = "Save";
            buttonSave9.UseVisualStyleBackColor = true;
            buttonSave9.Click += buttonSave9_Click;
            // 
            // buttonSave0
            // 
            buttonSave0.Location = new Point(939, 559);
            buttonSave0.Name = "buttonSave0";
            buttonSave0.Size = new Size(97, 26);
            buttonSave0.TabIndex = 69;
            buttonSave0.Text = "Save";
            buttonSave0.UseVisualStyleBackColor = true;
            buttonSave0.Click += buttonSave0_Click;
            // 
            // buttonClearText
            // 
            buttonClearText.Location = new Point(1044, 311);
            buttonClearText.Name = "buttonClearText";
            buttonClearText.Size = new Size(195, 32);
            buttonClearText.TabIndex = 72;
            buttonClearText.Text = "Clear Text";
            buttonClearText.UseVisualStyleBackColor = true;
            buttonClearText.Click += buttonClearText_Click;
            // 
            // buttonStudy
            // 
            buttonStudy.BackColor = Color.FromArgb(128, 128, 255);
            buttonStudy.FlatStyle = FlatStyle.Popup;
            buttonStudy.Location = new Point(1044, 458);
            buttonStudy.Name = "buttonStudy";
            buttonStudy.Size = new Size(195, 63);
            buttonStudy.TabIndex = 73;
            buttonStudy.Text = "Study";
            buttonStudy.UseVisualStyleBackColor = false;
            buttonStudy.Click += buttonStudy_Click;
            // 
            // buttonCleanWeights
            // 
            buttonCleanWeights.BackColor = Color.FromArgb(255, 128, 128);
            buttonCleanWeights.FlatStyle = FlatStyle.Popup;
            buttonCleanWeights.Location = new Point(1044, 528);
            buttonCleanWeights.Name = "buttonCleanWeights";
            buttonCleanWeights.Size = new Size(195, 57);
            buttonCleanWeights.TabIndex = 76;
            buttonCleanWeights.Text = "Clean Weights";
            buttonCleanWeights.UseVisualStyleBackColor = false;
            buttonCleanWeights.Click += buttonCleanWeights_Click;
            // 
            // numericUpDownEpochs
            // 
            numericUpDownEpochs.Location = new Point(1109, 424);
            numericUpDownEpochs.Name = "numericUpDownEpochs";
            numericUpDownEpochs.Size = new Size(130, 23);
            numericUpDownEpochs.TabIndex = 77;
            numericUpDownEpochs.TextAlign = HorizontalAlignment.Center;
            // 
            // labelEpochs
            // 
            labelEpochs.AutoSize = true;
            labelEpochs.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelEpochs.Location = new Point(1044, 424);
            labelEpochs.Name = "labelEpochs";
            labelEpochs.Size = new Size(59, 20);
            labelEpochs.TabIndex = 79;
            labelEpochs.Text = "Epochs:";
            // 
            // labelLearningRate
            // 
            labelLearningRate.AutoSize = true;
            labelLearningRate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelLearningRate.Location = new Point(1044, 355);
            labelLearningRate.Name = "labelLearningRate";
            labelLearningRate.Size = new Size(103, 20);
            labelLearningRate.TabIndex = 80;
            labelLearningRate.Text = "Learning rate: ";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(1044, 378);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(206, 45);
            trackBar1.TabIndex = 81;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // labelLearningRateValue
            // 
            labelLearningRateValue.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelLearningRateValue.Location = new Point(1143, 355);
            labelLearningRateValue.Name = "labelLearningRateValue";
            labelLearningRateValue.Size = new Size(96, 23);
            labelLearningRateValue.TabIndex = 82;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 596);
            Controls.Add(labelLearningRateValue);
            Controls.Add(trackBar1);
            Controls.Add(labelLearningRate);
            Controls.Add(labelEpochs);
            Controls.Add(numericUpDownEpochs);
            Controls.Add(buttonCleanWeights);
            Controls.Add(buttonStudy);
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
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Perceptron";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxFull).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxZoomed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEpochs).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
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
        private Button buttonStudy;
        private Button buttonCleanWeights;
        private NumericUpDown numericUpDownEpochs;
        private Label labelEpochs;
        private Label labelLearningRate;
        private TrackBar trackBar1;
        private Label labelLearningRateValue;
    }
}