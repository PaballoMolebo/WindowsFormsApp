namespace WindowsFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            lblTaskInfo = new Label();
            lblTaskTitle = new Label();
            txtTaskTitle = new TextBox();
            lblTaskDesc = new Label();
            txtTaskDescription = new TextBox();
            lblTaskDue = new Label();
            dtpTaskDueDate = new DateTimePicker();
            btnAddTask = new Button();
            lstTasks = new ListBox();
            lblTaskDetail = new Label();
            lblTaskCount = new Label();
            btnCompleteTask = new Button();
            btnDeleteTask = new Button();
            tabQuiz = new TabPage();
            btnNextQuestion = new Button();
            btnSubmitAnswer = new Button();
            btnStartQuiz = new Button();
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
            lstActivityLog = new ListBox();
            btnShowMoreLog = new Button();
            tabControl1.SuspendLayout();
            tabChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            tabTasks.SuspendLayout();
            tabQuiz.SuspendLayout();
            tabLog.SuspendLayout();
            SuspendLayout();
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
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
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
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
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
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
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
            tabTasks.BackColor = Color.CadetBlue;
            tabTasks.Controls.Add(lblTaskInfo);
            tabTasks.Controls.Add(lblTaskTitle);
            tabTasks.Controls.Add(txtTaskTitle);
            tabTasks.Controls.Add(lblTaskDesc);
            tabTasks.Controls.Add(txtTaskDescription);
            tabTasks.Controls.Add(lblTaskDue);
            tabTasks.Controls.Add(dtpTaskDueDate);
            tabTasks.Controls.Add(btnAddTask);
            tabTasks.Controls.Add(lstTasks);
            tabTasks.Controls.Add(lblTaskDetail);
            tabTasks.Controls.Add(lblTaskCount);
            tabTasks.Controls.Add(btnCompleteTask);
            tabTasks.Controls.Add(btnDeleteTask);
            tabTasks.Location = new Point(4, 24);
            tabTasks.Name = "tabTasks";
            tabTasks.Padding = new Padding(3);
            tabTasks.Size = new Size(1259, 723);
            tabTasks.TabIndex = 1;
            tabTasks.Text = "Task Assistant";
            // 
            // lblTaskInfo
            // 
            lblTaskInfo.Location = new Point(20, 20);
            lblTaskInfo.Name = "lblTaskInfo";
            lblTaskInfo.Size = new Size(600, 40);
            lblTaskInfo.TabIndex = 0;
            lblTaskInfo.Text = "Use Chat to add tasks: type 'Add task - Review privacy settings'";
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.Location = new Point(20, 70);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(100, 20);
            lblTaskTitle.TabIndex = 1;
            lblTaskTitle.Text = "Task Title:";
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(130, 70);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(400, 23);
            txtTaskTitle.TabIndex = 2;
            // 
            // lblTaskDesc
            // 
            lblTaskDesc.Location = new Point(20, 110);
            lblTaskDesc.Name = "lblTaskDesc";
            lblTaskDesc.Size = new Size(100, 20);
            lblTaskDesc.TabIndex = 3;
            lblTaskDesc.Text = "Description:";
            // 
            // txtTaskDescription
            // 
            txtTaskDescription.Location = new Point(130, 110);
            txtTaskDescription.Multiline = true;
            txtTaskDescription.Name = "txtTaskDescription";
            txtTaskDescription.Size = new Size(400, 60);
            txtTaskDescription.TabIndex = 4;
            // 
            // lblTaskDue
            // 
            lblTaskDue.Location = new Point(20, 185);
            lblTaskDue.Name = "lblTaskDue";
            lblTaskDue.Size = new Size(100, 20);
            lblTaskDue.TabIndex = 5;
            lblTaskDue.Text = "Due Date:";
            // 
            // dtpTaskDueDate
            // 
            dtpTaskDueDate.Location = new Point(130, 185);
            dtpTaskDueDate.Name = "dtpTaskDueDate";
            dtpTaskDueDate.Size = new Size(200, 23);
            dtpTaskDueDate.TabIndex = 6;
            dtpTaskDueDate.Value = new DateTime(2026, 11, 15, 11, 55, 7, 317);
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(130, 225);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(120, 30);
            btnAddTask.TabIndex = 7;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // lstTasks
            // 
            lstTasks.ItemHeight = 15;
            lstTasks.Location = new Point(20, 280);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(600, 199);
            lstTasks.TabIndex = 8;
            lstTasks.SelectedIndexChanged += lstTasks_SelectedIndexChanged;
            // 
            // lblTaskDetail
            // 
            lblTaskDetail.Location = new Point(650, 280);
            lblTaskDetail.Name = "lblTaskDetail";
            lblTaskDetail.Size = new Size(400, 120);
            lblTaskDetail.TabIndex = 9;
            lblTaskDetail.Text = "Select a task to see details";
            // 
            // lblTaskCount
            // 
            lblTaskCount.Location = new Point(20, 490);
            lblTaskCount.Name = "lblTaskCount";
            lblTaskCount.Size = new Size(300, 20);
            lblTaskCount.TabIndex = 10;
            lblTaskCount.Text = "Pending: 0 / Total: 0";
            // 
            // btnCompleteTask
            // 
            btnCompleteTask.Location = new Point(20, 520);
            btnCompleteTask.Name = "btnCompleteTask";
            btnCompleteTask.Size = new Size(140, 30);
            btnCompleteTask.TabIndex = 11;
            btnCompleteTask.Text = "Mark Complete";
            btnCompleteTask.UseVisualStyleBackColor = true;
            btnCompleteTask.Click += btnCompleteTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(180, 520);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(120, 30);
            btnDeleteTask.TabIndex = 12;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // tabQuiz
            // 
            tabQuiz.BackColor = Color.SkyBlue;
            tabQuiz.Controls.Add(btnNextQuestion);
            tabQuiz.Controls.Add(btnSubmitAnswer);
            tabQuiz.Controls.Add(btnStartQuiz);
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
            tabQuiz.Location = new Point(4, 24);
            tabQuiz.Name = "tabQuiz";
            tabQuiz.Size = new Size(1259, 723);
            tabQuiz.TabIndex = 2;
            tabQuiz.Text = "Quiz";
            tabQuiz.Click += tabQuiz_Click;
            // 
            // btnNextQuestion
            // 
            btnNextQuestion.Location = new Point(533, 392);
            btnNextQuestion.Name = "btnNextQuestion";
            btnNextQuestion.Size = new Size(129, 23);
            btnNextQuestion.TabIndex = 12;
            btnNextQuestion.Text = "Next Question";
            btnNextQuestion.UseVisualStyleBackColor = true;
            btnNextQuestion.Click += btnNextQuestion_Click;
            // 
            // btnSubmitAnswer
            // 
            btnSubmitAnswer.Location = new Point(381, 392);
            btnSubmitAnswer.Name = "btnSubmitAnswer";
            btnSubmitAnswer.Size = new Size(110, 23);
            btnSubmitAnswer.TabIndex = 11;
            btnSubmitAnswer.Text = "Submit Answer";
            btnSubmitAnswer.UseVisualStyleBackColor = true;
            btnSubmitAnswer.Click += btnSubmitAnswer_Click;
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.Location = new Point(396, 90);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(110, 23);
            btnStartQuiz.TabIndex = 10;
            btnStartQuiz.Text = "Start Quiz";
            btnStartQuiz.UseVisualStyleBackColor = true;
            btnStartQuiz.Click += btnStartQuiz_Click;
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
            rdoOptionA.Location = new Point(200, 183);
            rdoOptionA.Name = "rdoOptionA";
            rdoOptionA.Size = new Size(73, 19);
            rdoOptionA.TabIndex = 6;
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
            tabLog.BackColor = SystemColors.ActiveCaption;
            tabLog.Controls.Add(lstActivityLog);
            tabLog.Controls.Add(btnShowMoreLog);
            tabLog.Location = new Point(4, 24);
            tabLog.Name = "tabLog";
            tabLog.Size = new Size(1259, 723);
            tabLog.TabIndex = 3;
            tabLog.Text = "Activity Log";
            // 
            // lstActivityLog
            // 
            lstActivityLog.ItemHeight = 15;
            lstActivityLog.Location = new Point(20, 20);
            lstActivityLog.Name = "lstActivityLog";
            lstActivityLog.Size = new Size(800, 394);
            lstActivityLog.TabIndex = 0;
            // 
            // btnShowMoreLog
            // 
            btnShowMoreLog.Location = new Point(20, 440);
            btnShowMoreLog.Name = "btnShowMoreLog";
            btnShowMoreLog.Size = new Size(150, 30);
            btnShowMoreLog.TabIndex = 1;
            btnShowMoreLog.Text = "Show More";
            btnShowMoreLog.Click += btnShowMoreLog_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1267, 751);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Cybersecurity Chatbot";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabChat.ResumeLayout(false);
            tabChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            tabTasks.ResumeLayout(false);
            tabTasks.PerformLayout();
            tabQuiz.ResumeLayout(false);
            tabQuiz.PerformLayout();
            tabLog.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

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
        private Label lblTaskInfo;
        private Label lblQuizTitle;
        private Label lblQuestion;
        private Label lblQuestionNumber;
        private Label lblScore;
        private Label lblFinalScore;
        private Label lblFeedback;
        private Button btnSubmitAnswer;
        private Button btnStartQuiz;
        private RadioButton rdoOptionD;
        private RadioButton rdoOptionC;
        private RadioButton rdoOptionB;
        private RadioButton rdoOptionA;
        private Button btnNextQuestion;
        private ListBox lstActivityLog;
        private Button btnShowMoreLog;
        private Label lblTaskTitle;
        private TextBox txtTaskTitle;
        private Label lblTaskDesc;
        private TextBox txtTaskDescription;
        private Label lblTaskDue;
        private DateTimePicker dtpTaskDueDate;
        private Button btnAddTask;
        private ListBox lstTasks;
        private Label lblTaskDetail;
        private Label lblTaskCount;
        private Button btnCompleteTask;
        private Button btnDeleteTask;
    }
}