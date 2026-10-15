namespace WindowsFormsApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            txtLog = new RichTextBox();
            txtUserInput = new TextBox();
            button2 = new Button();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBox1.Location = new Point(64, 163);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 186);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Right;
            txtLog.BackColor = SystemColors.InactiveCaption;
            txtLog.BorderStyle = BorderStyle.None;
            txtLog.ForeColor = SystemColors.ButtonHighlight;
            txtLog.Location = new Point(393, 106);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLog.Size = new Size(354, 329);
            txtLog.TabIndex = 2;
            txtLog.Text = "";
            txtLog.TextChanged += txtLog_TextChanged;
            // 
            // txtUserInput
            // 
            txtUserInput.Anchor = AnchorStyles.Right;
            txtUserInput.Location = new Point(427, 451);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(212, 23);
            txtUserInput.TabIndex = 3;
            txtUserInput.TextChanged += txtUserInput_TextChanged;
            txtUserInput.KeyDown += txtUserInput_KeyDown;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Right;
            button2.Location = new Point(658, 451);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "SEND";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.Location = new Point(64, 374);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(211, 50);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.MediumSeaGreen;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.HighlightText;
            textBox1.Location = new Point(427, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 23);
            textBox1.TabIndex = 6;
            textBox1.Text = "Security Chat - Live Session";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(859, 751);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(button2);
            Controls.Add(txtUserInput);
            Controls.Add(txtLog);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Start!";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private RichTextBox txtLog;
        private TextBox txtUserInput;
        private Button button2;
        private PictureBox pictureBox2;
        private TextBox textBox1;
    }
}
