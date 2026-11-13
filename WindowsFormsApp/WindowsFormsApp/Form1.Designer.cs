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
            button1 = new Button();
            tabControl1 = new TabControl();
            tabChat = new TabPage();
            textBox3 = new TextBox();
            button4 = new Button();
            pictureBox3 = new PictureBox();
            richTextBox1 = new RichTextBox();
            pictureBox4 = new PictureBox();
            textBox2 = new TextBox();
            button3 = new Button();
            tabTasks = new TabPage();
            tabQuiz = new TabPage();
            btnNextQuestion_click = new Button();
            btnSubmitAnswer_click = new Button();
            btnStartQuiz_click = new Button();
            rdoOptionD = new RadioButton();
            rdoOptionC = new RadioButton();
            rdoOptionB = new RadioButton();
            rdoOptionA = new RadioButton();
            lblFinalScore = new Label();
            lblFeedback = new Label();
            lblQuizTitle = new Label();
            lblQuestion = new Label();
            lblQuestionNumber = new Label();
            lblScore = new Label();
            tabLog = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tabControl1.SuspendLayout();
            tabChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            tabQuiz.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1267, 751);
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
            txtLog.Location = new Point(739, 186);
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
            txtUserInput.Location = new Point(795, 526);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(246, 23);
            txtUserInput.TabIndex = 3;
            txtUserInput.TextChanged += txtUserInput_TextChanged;
            txtUserInput.KeyDown += txtUserInput_KeyDown;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Right;
            button2.BackColor = Color.MediumSeaGreen;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(1074, 525);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "SEND";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1267, 751);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.MediumSeaGreen;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.HighlightText;
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1267, 23);
            textBox1.TabIndex = 6;
            textBox1.Text = "Security Chat - Live Session";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSeaGreen;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(1267, 751);
            button1.TabIndex = 7;
            button1.Text = "START";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabChat);
            tabControl1.Controls.Add(tabTasks);
            tabControl1.Controls.Add(tabQuiz);
            tabControl1.Controls.Add(tabLog);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1267, 751);
            tabControl1.TabIndex = 8;
            // 
            // tabChat
            // 
            tabChat.BackColor = Color.Navy;
            tabChat.Controls.Add(textBox3);
            tabChat.Controls.Add(button4);
            tabChat.Controls.Add(pictureBox3);
            tabChat.Controls.Add(richTextBox1);
            tabChat.Controls.Add(pictureBox4);
            tabChat.Controls.Add(textBox2);
            tabChat.Controls.Add(txtLog);
            tabChat.Controls.Add(button3);
            tabChat.Location = new Point(4, 24);
            tabChat.Name = "tabChat";
            tabChat.Padding = new Padding(3);
            tabChat.Size = new Size(1259, 723);
            tabChat.TabIndex = 0;
            tabChat.Text = "Chat";
            tabChat.Click += tabChat_Click;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.MediumSeaGreen;
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.ForeColor = SystemColors.HighlightText;
            textBox3.Location = new Point(371, 85);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(278, 23);
            textBox3.TabIndex = 6;
            textBox3.Text = "Security Chat - Live Session";
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox1_TextChanged;
            // 
            // button4
            // 
            button4.BackColor = Color.MediumSeaGreen;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(297, 407);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 7;
            button4.Text = "START";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button1_Click_1;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBox3.Location = new Point(212, 69);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(211, 186);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Right;
            richTextBox1.BackColor = SystemColors.InactiveCaption;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = SystemColors.ButtonHighlight;
            richTextBox1.Location = new Point(739, 186);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(354, 329);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += txtLog_TextChanged;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.Location = new Point(237, 313);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(186, 44);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox2_Click;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Right;
            textBox2.Location = new Point(739, 531);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(246, 23);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += txtUserInput_TextChanged;
            textBox2.KeyDown += txtUserInput_KeyDown;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Right;
            button3.BackColor = Color.MediumSeaGreen;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(1018, 530);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "SEND";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button2_Click_1;
            // 
            // tabTasks
            // 
            tabTasks.Location = new Point(4, 24);
            tabTasks.Name = "tabTasks";
            tabTasks.Padding = new Padding(3);
            tabTasks.Size = new Size(1259, 723);
            tabTasks.TabIndex = 1;
            tabTasks.Text = "Task Assistant";
            tabTasks.UseVisualStyleBackColor = true;
            // 
            // tabQuiz
            // 
            tabQuiz.BackColor = Color.Teal;
            tabQuiz.Controls.Add(btnNextQuestion_click);
            tabQuiz.Controls.Add(btnSubmitAnswer_click);
            tabQuiz.Controls.Add(btnStartQuiz_click);
            tabQuiz.Controls.Add(rdoOptionD);
            tabQuiz.Controls.Add(rdoOptionC);
            tabQuiz.Controls.Add(rdoOptionB);
            tabQuiz.Controls.Add(rdoOptionA);
            tabQuiz.Controls.Add(lblFinalScore);
            tabQuiz.Controls.Add(lblFeedback);
            tabQuiz.Controls.Add(lblQuizTitle);
            tabQuiz.Controls.Add(lblQuestion);
            tabQuiz.Controls.Add(lblQuestionNumber);
            tabQuiz.Controls.Add(lblScore);
            tabQuiz.ForeColor = SystemColors.ControlText;
            tabQuiz.Location = new Point(4, 24);
            tabQuiz.Name = "tabQuiz";
            tabQuiz.Size = new Size(1259, 723);
            tabQuiz.TabIndex = 2;
            tabQuiz.Text = "Quiz";
            tabQuiz.Click += tabQuiz_Click;
            // 
            // btnNextQuestion_click
            // 
            btnNextQuestion_click.Location = new Point(533, 392);
            btnNextQuestion_click.Name = "btnNextQuestion_click";
            btnNextQuestion_click.Size = new Size(129, 23);
            btnNextQuestion_click.TabIndex = 12;
            btnNextQuestion_click.Text = "Next Question";
            btnNextQuestion_click.UseVisualStyleBackColor = true;
            // 
            // btnSubmitAnswer_click
            // 
            btnSubmitAnswer_click.Location = new Point(381, 392);
            btnSubmitAnswer_click.Name = "btnSubmitAnswer_click";
            btnSubmitAnswer_click.Size = new Size(75, 23);
            btnSubmitAnswer_click.TabIndex = 11;
            btnSubmitAnswer_click.Text = "Submit Answer";
            btnSubmitAnswer_click.UseVisualStyleBackColor = true;
            btnSubmitAnswer_click.Click += btnSubmitAnswer_Click_1;
            // 
            // btnStartQuiz_click
            // 
            btnStartQuiz_click.Location = new Point(396, 90);
            btnStartQuiz_click.Name = "btnStartQuiz_click";
            btnStartQuiz_click.Size = new Size(75, 23);
            btnStartQuiz_click.TabIndex = 10;
            btnStartQuiz_click.Text = "Start Quiz";
            btnStartQuiz_click.UseVisualStyleBackColor = true;
            // 
            // rdoOptionD
            // 
            rdoOptionD.AutoSize = true;
            rdoOptionD.Location = new Point(200, 299);
            rdoOptionD.Name = "rdoOptionD";
            rdoOptionD.Size = new Size(73, 19);
            rdoOptionD.TabIndex = 9;
            rdoOptionD.Text = "Option D";
            rdoOptionD.UseVisualStyleBackColor = true;
            // 
            // rdoOptionC
            // 
            rdoOptionC.AutoSize = true;
            rdoOptionC.Location = new Point(200, 260);
            rdoOptionC.Name = "rdoOptionC";
            rdoOptionC.Size = new Size(73, 19);
            rdoOptionC.TabIndex = 8;
            rdoOptionC.Text = "Option C";
            rdoOptionC.UseVisualStyleBackColor = true;
            // 
            // rdoOptionB
            // 
            rdoOptionB.AutoSize = true;
            rdoOptionB.Location = new Point(200, 224);
            rdoOptionB.Name = "rdoOptionB";
            rdoOptionB.Size = new Size(72, 19);
            rdoOptionB.TabIndex = 7;
            rdoOptionB.Text = "Option B";
            rdoOptionB.UseVisualStyleBackColor = true;
            // 
            // rdoOptionA
            // 
            rdoOptionA.AutoSize = true;
            rdoOptionA.Checked = true;
            rdoOptionA.Location = new Point(200, 183);
            rdoOptionA.Name = "rdoOptionA";
            rdoOptionA.Size = new Size(73, 19);
            rdoOptionA.TabIndex = 6;
            rdoOptionA.TabStop = true;
            rdoOptionA.Text = "Option A";
            rdoOptionA.UseVisualStyleBackColor = true;
            // 
            // lblFinalScore
            // 
            lblFinalScore.AutoSize = true;
            lblFinalScore.Location = new Point(378, 489);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new Size(64, 15);
            lblFinalScore.TabIndex = 5;
            lblFinalScore.Text = "Final Score";
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.Location = new Point(533, 489);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(127, 15);
            lblFeedback.TabIndex = 4;
            lblFeedback.Text = "Feedback appears here";
            // 
            // lblQuizTitle
            // 
            lblQuizTitle.AutoSize = true;
            lblQuizTitle.Font = new Font("Segoe UI", 14F);
            lblQuizTitle.Location = new Point(169, 40);
            lblQuizTitle.Margin = new Padding(5, 0, 5, 0);
            lblQuizTitle.Name = "lblQuizTitle";
            lblQuizTitle.Size = new Size(223, 25);
            lblQuizTitle.TabIndex = 3;
            lblQuizTitle.Text = "Cybersecurity Mini Game";
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(369, 157);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(120, 15);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "Question appear here";
            // 
            // lblQuestionNumber
            // 
            lblQuestionNumber.AutoSize = true;
            lblQuestionNumber.Location = new Point(381, 126);
            lblQuestionNumber.Name = "lblQuestionNumber";
            lblQuestionNumber.Size = new Size(93, 15);
            lblQuestionNumber.TabIndex = 1;
            lblQuestionNumber.Text = "Question 1 of 15";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(612, 139);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(48, 15);
            lblScore.TabIndex = 0;
            lblScore.Text = "Score: 0";
            // 
            // tabLog
            // 
            tabLog.Location = new Point(4, 24);
            tabLog.Name = "tabLog";
            tabLog.Size = new Size(1259, 723);
            tabLog.TabIndex = 3;
            tabLog.Text = "Activity Log";
            tabLog.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1267, 751);
            Controls.Add(tabControl1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(button2);
            Controls.Add(txtUserInput);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Start!";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tabControl1.ResumeLayout(false);
            tabChat.ResumeLayout(false);
            tabChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            tabQuiz.ResumeLayout(false);
            tabQuiz.PerformLayout();
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
        private TabControl tabControl1;
        private TabPage tabChat;
        private TabPage tabTasks;
        private TabPage tabQuiz;
        private TabPage tabLog;
        private TextBox textBox3;
        private Button button4;
        private PictureBox pictureBox3;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox4;
        private TextBox textBox2;
        private Button button3;
        private Label lblQuizTitle;
        private Label lblQuestion;
        private Label lblQuestionNumber;
        private Label lblScore;
        private Label lblFinalScore;
        private Label lblFeedback;
        private Button btnSubmitAnswer_click;
        private Button btnStartQuiz_click;
        private RadioButton rdoOptionD;
        private RadioButton rdoOptionC;
        private RadioButton rdoOptionB;
        private RadioButton rdoOptionA;
        private Button btnNextQuestion_click;
    }
}
