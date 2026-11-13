
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using WindowsFormsApp.Services;


namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private ChatEngine chatEngine = new ChatEngine();
        private FlowLayoutPanel flowChat;

        // UNDER IMAGE DISPLAY
        private Panel panelUnderLogo;
        private Label lblConnected;
        private Label lblVersion;

        // QUIZ VARIABLES
        private QuizService quizService = new QuizService();
        private List<QuizQuestion> quizQuestions;

        private int currentQuestionIndex = 0;
        private int quizScore = 0;
        private bool answerSubmitted = false;

        public Form1()
        {
            InitializeComponent();
            CreateChatPanel();

            // CONNECT QUIZ BUTTONS
            btnStartQuiz_Click.Click -= btnStartQuiz_Click;
            btnStartQuiz_Click.Click += btnStartQuiz_Click;

            btnSubmitAnswer_Click.Click -= btnSubmitAnswer_Click;
            btnSubmitAnswer_Click.Click += btnSubmitAnswer_Click;

            btnNextQuestion_Click.Click -= btnNextQuestion_Click;
            btnNextQuestion_Click.Click += btnNextQuestion_Click;
        }

        // ==============================
        // CHAT PANEL
        // ==============================

        private void CreateChatPanel()
        {
            flowChat = new FlowLayoutPanel();

            flowChat.Name = "flowChat";
            flowChat.FlowDirection = FlowDirection.TopDown;
            flowChat.WrapContents = false;
            flowChat.AutoScroll = true;
            flowChat.Padding = new Padding(10);
            flowChat.BackColor = Color.Navy;

            flowChat.Location = txtLog.Location;
            flowChat.Size = txtLog.Size;
            flowChat.Anchor = txtLog.Anchor;

            txtLog.Visible = false;
            txtLog.Parent.Controls.Add(flowChat);

            flowChat.BringToFront();

            flowChat.SizeChanged += (s, e) => ResizeChatRows();
        }

        // ==============================
        // FORM LOAD
        // ==============================

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayLogo();

            AddMessage(
                "Hello! I am your cybersecurity chatbot.",
                false);

            AddMessage(
                "You can ask me about passwords, phishing, malware, firewalls, encryption, VPNs, 2FA and online safety.",
                false);

            txtUserInput.Focus();
        }

        // ==============================
        // DISPLAY LOGO
        // ==============================

        private void DisplayLogo()
        {
            try
            {
                pictureBox1.Image = Image.FromFile(
                    @"C:\Users\Student\Pictures\Screenshots\logo.png");
            }
            catch
            {
            }
        }

        // ==============================
        // CHAT MESSAGES
        // ==============================

        private void AddMessage(string message, bool isUser)
        {
            int availableWidth = Math.Max(
                200, flowChat.ClientSize.Width - 40);

            int bubbleWidth = Math.Max(
                100, Math.Min(availableWidth * 3 / 4, 420));

            Panel row = new Panel();

            row.Width = availableWidth;
            row.Height = 60;
            row.Margin = new Padding(0, 0, 0, 10);
            row.BackColor = flowChat.BackColor;
            row.Tag = isUser;

            Label bubble = new Label();

            bubble.AutoSize = false;
            bubble.Width = bubbleWidth;
            bubble.Font = new Font("Segoe UI", 10F);

            bubble.Text =
                (isUser ? "You" : "Bot") +
                Environment.NewLine + message;

            bubble.Padding = new Padding(12);
            bubble.BackColor =
                isUser ? Color.SeaGreen : Color.Navy;

            bubble.ForeColor = Color.White;

            Size textSize = TextRenderer.MeasureText(
                bubble.Text,
                bubble.Font,
                new Size(bubbleWidth - 24, 0),
                TextFormatFlags.WordBreak);

            bubble.Height = textSize.Height + 28;

            row.Height = bubble.Height;

            row.Controls.Add(bubble);

            bubble.Location = new Point(
                isUser ? Math.Max(0, row.Width - bubble.Width) : 0,
                0);

            flowChat.Controls.Add(row);
            flowChat.ScrollControlIntoView(row);
        }

        private void ResizeChatRows()
        {
            if (flowChat == null)
                return;

            int availableWidth = Math.Max(
                200, flowChat.ClientSize.Width - 40);

            foreach (Control control in flowChat.Controls)
            {
                Panel row = control as Panel;

                if (row == null || row.Controls.Count == 0)
                    continue;

                Label bubble = row.Controls[0] as Label;

                if (bubble == null)
                    continue;

                bool isUser = row.Tag is bool &&
                              (bool)row.Tag;

                row.Width = availableWidth;

                bubble.Width = Math.Max(
                    100, Math.Min(availableWidth * 3 / 4, 420));

                Size textSize = TextRenderer.MeasureText(
                    bubble.Text,
                    bubble.Font,
                    new Size(bubble.Width - 24, 0),
                    TextFormatFlags.WordBreak);

                bubble.Height = textSize.Height + 28;

                bubble.Location = new Point(
                    isUser ? Math.Max(0, row.Width - bubble.Width) : 0,
                    0);

                row.Height = bubble.Height;
            }
        }

        // ==============================
        // CHAT BUTTONS
        // ==============================

        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            string userMessage = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            AddMessage(userMessage, true);

            txtUserInput.Clear();

            string response =
                chatEngine.GetResponse(userMessage);

            AddMessage(response, false);

            txtUserInput.Focus();
        }

        private void txtUserInput_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                SendMessage();
            }
        }

        // ==============================
        // QUIZ: START GAME
        // ==============================

        private void btnStartQuiz_Click(
            object sender, EventArgs e)
        {
            quizQuestions = quizService.GetQuestions();
            MessageBox.Show("Start Quiz button is working!");

            currentQuestionIndex = 0;
            quizScore = 0;
            answerSubmitted = false;

            lblScore.Text = "Score: 0";
            lblFinalScore.Text = "";
            lblFeedback.Text = "";

            btnStartQuiz_Click.Text = "Restart Quiz";
            btnStartQuiz_Click.Enabled = false;

            LoadQuizQuestion();
        }

        // ==============================
        // QUIZ: LOAD QUESTION
        // ==============================


        private void LoadQuizQuestion()
        {
            // Check that questions are available
            if (quizQuestions == null ||
                currentQuestionIndex >= quizQuestions.Count)
                return;

            // Get the current question
            QuizQuestion question =
                quizQuestions[currentQuestionIndex];

            // Display question information
            lblQuestion.Text = question.QuestionText;

            lblQuestionNumber.Text =
                "Question " + (currentQuestionIndex + 1) +
                " of " + quizQuestions.Count;

            lblScore.Text = "Score: " + quizScore;

            // Make labels visible
            lblQuestion.Visible = true;
            lblQuestionNumber.Visible = true;
            lblScore.Visible = true;
            lblFeedback.Visible = true;
            lblFinalScore.Visible = true;

            // Prepare answer options
            RadioButton[] options =
            {
        rdoOptionA,
        rdoOptionB,
        rdoOptionC,
        rdoOptionD
    };

            // Reset all options
            foreach (RadioButton option in options)
            {
                option.Checked = false;
                option.Visible = false;
                option.Enabled = true;
            }

            // Display the available answers
            for (int i = 0; i < question.Options.Count; i++)
            {
                options[i].Text = question.Options[i];
                options[i].Visible = true;
            }

            // Reset feedback
            lblFeedback.Text = "";
            lblFinalScore.Text = "";

            answerSubmitted = false;

            // Enable buttons
            
        }


        // ==============================
        // QUIZ: SUBMIT ANSWER
        // ==============================

        private void btnSubmitAnswer_Click(
            object sender, EventArgs e)
        {
            if (answerSubmitted)
                return;

            int selectedAnswer = -1;

            if (rdoOptionA.Checked)
                selectedAnswer = 0;

            else if (rdoOptionB.Checked)
                selectedAnswer = 1;

            else if (rdoOptionC.Checked)
                selectedAnswer = 2;

            else if (rdoOptionD.Checked)
                selectedAnswer = 3;

            if (selectedAnswer == -1)
            {
                MessageBox.Show(
                    "Please select an answer before submitting.",
                    "No Answer Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            bool correct = quizService.CheckAnswer(
                currentQuestionIndex,
                selectedAnswer);

            if (correct)
            {
                quizScore++;

                lblFeedback.Text =
                    "Correct! Well done!\n" +
                    quizService.GetExplanation(
                        currentQuestionIndex);

                lblFeedback.ForeColor = Color.Green;
            }
            else
            {
                lblFeedback.Text =
                    "Incorrect answer.\n" +
                    quizService.GetExplanation(
                        currentQuestionIndex);

                lblFeedback.ForeColor = Color.Red;
            }

            // UPDATE SCORE
            lblScore.Text = "Score: " + quizScore;

            answerSubmitted = true;

            btnSubmitAnswer_Click.Enabled = false;
            btnNextQuestion_Click.Enabled = true;

            // PREVENT CHANGING ANSWERS
            rdoOptionA.Enabled = false;
            rdoOptionB.Enabled = false;
            rdoOptionC.Enabled = false;
            rdoOptionD.Enabled = false;

            if (currentQuestionIndex ==
                quizQuestions.Count - 1)
            {
                btnNextQuestion_Click.Text = "View Results";
            }
        }

        // ==============================
        // QUIZ: NEXT QUESTION
        // ==============================

        private void btnNextQuestion_Click(
            object sender, EventArgs e)
        {
            if (!answerSubmitted)
                return;

            currentQuestionIndex++;

            if (currentQuestionIndex <
                quizQuestions.Count)
            {
                LoadQuizQuestion();
            }
            else
            {
                DisplayFinalScore();
            }
        }

        // ==============================
        // QUIZ: FINAL RESULTS
        // ==============================

        private void DisplayFinalScore()
        {
            double percentage =
                (double)quizScore /
                quizQuestions.Count * 100;

            lblQuestion.Text = "Quiz Completed!";

            lblQuestionNumber.Text =
                "You have answered all " +
                quizQuestions.Count + " questions.";

            lblFinalScore.Text =
                "Final Score: " + quizScore +
                " / " + quizQuestions.Count +
                "\nPercentage: " +
                percentage.ToString("0") + "%";

            if (percentage >= 80)
            {
                lblFeedback.Text =
                    "Excellent work! You're a cybersecurity pro!";
            }
            else if (percentage >= 50)
            {
                lblFeedback.Text =
                    "Good effort! Keep learning to improve your cybersecurity knowledge.";
            }
            else
            {
                lblFeedback.Text =
                    "Keep practising! Continue learning how to stay safe online.";
            }

            lblFeedback.ForeColor = Color.DarkBlue;

            // HIDE ANSWER OPTIONS
            rdoOptionA.Visible = false;
            rdoOptionB.Visible = false;
            rdoOptionC.Visible = false;
            rdoOptionD.Visible = false;

            btnSubmitAnswer_Click.Enabled = false;
            btnNextQuestion_Click.Enabled = false;

            // ALLOW RESTART
            btnStartQuiz_Click.Enabled = true;
            btnStartQuiz_Click.Text = "Play Again";
        }


        private string GetActivityLog()
        {
            List<string> recentActivities =
                ActivityLogger.GetRecentActivities();

            if (recentActivities.Count == 0)
            {
                return "There are currently no activities recorded.";
            }

            string result = "Here is a summary of your recent activities:\n\n";

            for (int i = 0; i < recentActivities.Count; i++)
            {
                result += (i + 1) + ". "
                    + recentActivities[i]
                    + "\n\n";
            }

            return result;
        }


        // ==============================
        // OTHER EXISTING EVENT HANDLERS
        // ==============================

        private void button1_Click(
            object sender, EventArgs e)
        { }

        private void txtUserInput_TextChanged(
            object sender, EventArgs e)
        { }

        private void pictureBox1_Click(
            object sender, EventArgs e)
        { }

        private void txtLog_TextChanged(
            object sender, EventArgs e)
        { }

        private void button1_KeyDown(
            object sender, KeyEventArgs e)
        { }

        private void pictureBox2_Click(
            object sender, EventArgs e)
        { }

        private void textBox1_TextChanged(
            object sender, EventArgs e)
        { }

        private void button1_Click_1(
            object sender, EventArgs e)
        { }

        private void tabChat_Click(
            object sender, EventArgs e)
        { }

        private void tabQuiz_Click(
            object sender, EventArgs e)
        { }

        private void btnSubmitAnswer_Click_1(object sender, EventArgs e)
        {

        }
    }
}
