using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using WindowsFormsApp.Services;
using WindowsFormsApp.Services; 
using WindowsFormsApp.Models;   
using WindowsFormsApp.Data;     

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private ChatEngine chatEngine = new ChatEngine();
        private FlowLayoutPanel flowChat;

        // QUIZ VARIABLES
        private QuizService quizService = new QuizService();
        private List<QuizQuestion> quizQuestions;
        private int currentQuestionIndex = 0;
        private int quizScore = 0;
        private bool answerSubmitted = false;

        // TASK ASSISTANT - uses existing TaskRepository
        private TaskRepository taskRepository = new TaskRepository();
        private int selectedTaskId = -1;

        // Simple activity log for this project
        private List<string> activityLog = new List<string>();

        public Form1()
        {
            InitializeComponent();
            CreateChatPanel();
            // DO NOT wire buttons here - Designer already wires them
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
            flowChat.Location = richTextBox1.Location;
            flowChat.Size = richTextBox1.Size;
            flowChat.Anchor = richTextBox1.Anchor;
            richTextBox1.Visible = false;
            richTextBox1.Parent.Controls.Add(flowChat);
            flowChat.BringToFront();
            flowChat.SizeChanged += (s, e) => ResizeChatRows();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayLogo();
            AddMessage("Hello! I am your cybersecurity chatbot.", false);
            AddMessage("You can ask me about passwords, phishing, malware, firewalls, encryption, VPNs, 2FA and online safety.", false);
            AddMessage("Type 'help' to see what I can do. Try 'Add task', 'Start quiz' or 'Show log'.", false);
            LogActivity("App started");
            RefreshActivityLog();
            RefreshTaskList();
            CheckDueToday();
            textBox2.Focus();
            
        }

        private void DisplayLogo()
        {
            try
            {
                string path = System.IO.Path.Combine(Application.StartupPath, "logo.png");
                if (!System.IO.File.Exists(path))
                    path = @"C:\Users\Student\Pictures\Screenshots\logo.png";
                pictureBox3.Image = Image.FromFile(path);
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }

        private void AddMessage(string message, bool isUser)
        {
            int availableWidth = Math.Max(200, flowChat.ClientSize.Width - 40);
            int bubbleWidth = Math.Max(100, Math.Min(availableWidth * 3 / 4, 420));
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
            bubble.Text = (isUser ? "You" : "Bot") + Environment.NewLine + message;
            bubble.Padding = new Padding(12);
            bubble.BackColor = isUser ? Color.SeaGreen : Color.FromArgb(40, 40, 90);
            bubble.ForeColor = Color.White;

            Size textSize = TextRenderer.MeasureText(bubble.Text, bubble.Font, new Size(bubbleWidth - 24, 0), TextFormatFlags.WordBreak);
            bubble.Height = textSize.Height + 28;
            row.Height = bubble.Height;
            row.Controls.Add(bubble);
            bubble.Location = new Point(isUser ? Math.Max(0, row.Width - bubble.Width) : 0, 0);
            flowChat.Controls.Add(row);
            flowChat.ScrollControlIntoView(row);
        }

        private void ResizeChatRows()
        {
            if (flowChat == null) return;
            int availableWidth = Math.Max(200, flowChat.ClientSize.Width - 40);
            foreach (Control control in flowChat.Controls)
            {
                Panel row = control as Panel;
                if (row == null || row.Controls.Count == 0) continue;
                Label bubble = row.Controls[0] as Label;
                if (bubble == null) continue;
                bool isUser = row.Tag is bool && (bool)row.Tag;
                row.Width = availableWidth;
                bubble.Width = Math.Max(100, Math.Min(availableWidth * 3 / 4, 420));
                Size textSize = TextRenderer.MeasureText(bubble.Text, bubble.Font, new Size(bubble.Width - 24, 0), TextFormatFlags.WordBreak);
                bubble.Height = textSize.Height + 28;
                bubble.Location = new Point(isUser ? Math.Max(0, row.Width - bubble.Width) : 0, 0);
                row.Height = bubble.Height;
            }
        }

        // ==============================
        // CHAT BUTTONS
        // ==============================
        private void button3_Click(object sender, EventArgs e) { SendMessage(); }
        private void button2_Click_1(object sender, EventArgs e) { SendMessage(); }
        private void button1_Click_1(object sender, EventArgs e) { SendMessage(); }

        private void SendMessage()
        {
            string userMessage = textBox2.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage)) return;
            AddMessage(userMessage, true);
            textBox2.Clear();
            string response = chatEngine.GetResponse(userMessage);
            AddMessage(response, false);
            LogActivity("Chat: " + userMessage);
            RefreshActivityLog();
            textBox2.Focus();
        }

        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
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
        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            quizQuestions = quizService.GetShuffledQuestions();
            currentQuestionIndex = 0;
            quizScore = 0;
            answerSubmitted = false;
            lblScore.Text = "Score: 0";
            lblFinalScore.Text = "";
            lblFeedback.Text = "";
            btnStartQuiz.Text = "Restart Quiz";
            btnStartQuiz.Enabled = false;
            LogActivity("Quiz started");
            LoadQuizQuestion();
        }

        private void LoadQuizQuestion()
        {
            if (quizQuestions == null || currentQuestionIndex >= quizQuestions.Count) return;
            QuizQuestion question = quizQuestions[currentQuestionIndex];
            lblQuestion.Text = question.QuestionText;
            lblQuestionNumber.Text = "Question " + (currentQuestionIndex + 1) + " of " + quizQuestions.Count;
            lblScore.Text = "Score: " + quizScore;
            lblQuestion.Visible = true;
            lblQuestionNumber.Visible = true;
            lblScore.Visible = true;
            lblFeedback.Visible = true;
            lblFinalScore.Visible = true;

            RadioButton[] options = { rdoOptionA, rdoOptionB, rdoOptionC, rdoOptionD };
            foreach (RadioButton option in options)
            {
                option.Checked = false;
                option.Visible = false;
                option.Enabled = true;
            }
            for (int i = 0; i < question.Options.Count; i++)
            {
                options[i].Text = question.Options[i];
                options[i].Visible = true;
            }
            lblFeedback.Text = "";
            lblFinalScore.Text = "";
            answerSubmitted = false;
            btnSubmitAnswer.Enabled = true;
            btnNextQuestion.Enabled = false;
            btnNextQuestion.Text = "Next Question";
        }

        private void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            if (answerSubmitted) return;
            int selectedAnswer = -1;
            if (rdoOptionA.Checked) selectedAnswer = 0;
            else if (rdoOptionB.Checked) selectedAnswer = 1;
            else if (rdoOptionC.Checked) selectedAnswer = 2;
            else if (rdoOptionD.Checked) selectedAnswer = 3;

            if (selectedAnswer == -1)
            {
                MessageBox.Show("Please select an answer before submitting.", "No Answer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool correct = quizService.CheckAnswer(currentQuestionIndex, selectedAnswer);
            if (correct)
            {
                quizScore++;
                lblFeedback.Text = "Correct! Well done!\n" + quizService.GetExplanation(currentQuestionIndex);
                lblFeedback.ForeColor = Color.Green;
            }
            else
            {
                lblFeedback.Text = "Incorrect answer.\n" + quizService.GetExplanation(currentQuestionIndex);
                lblFeedback.ForeColor = Color.Red;
            }
            lblScore.Text = "Score: " + quizScore;
            answerSubmitted = true;
            btnSubmitAnswer.Enabled = false;
            btnNextQuestion.Enabled = true;
            rdoOptionA.Enabled = false;
            rdoOptionB.Enabled = false;
            rdoOptionC.Enabled = false;
            rdoOptionD.Enabled = false;
            if (currentQuestionIndex == quizQuestions.Count - 1)
                btnNextQuestion.Text = "View Results";
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            if (!answerSubmitted) return;
            currentQuestionIndex++;
            if (currentQuestionIndex < quizQuestions.Count) LoadQuizQuestion();
            else DisplayFinalScore();
        }

        private void DisplayFinalScore()
        {
            double percentage = (double)quizScore / quizQuestions.Count * 100;
            lblQuestion.Text = "Quiz Completed!";
            lblQuestionNumber.Text = "You have answered all " + quizQuestions.Count + " questions.";
            lblFinalScore.Text = "Final Score: " + quizScore + " / " + quizQuestions.Count + "\nPercentage: " + percentage.ToString("0") + "%";
            if (percentage >= 80) lblFeedback.Text = "Excellent work! You're a cybersecurity pro!";
            else if (percentage >= 50) lblFeedback.Text = "Good effort! Keep learning to improve your cybersecurity knowledge.";
            else lblFeedback.Text = "Keep practising! Continue learning how to stay safe online.";
            lblFeedback.ForeColor = Color.DarkBlue;
            rdoOptionA.Visible = false;
            rdoOptionB.Visible = false;
            rdoOptionC.Visible = false;
            rdoOptionD.Visible = false;
            btnSubmitAnswer.Enabled = false;
            btnNextQuestion.Enabled = false;
            btnStartQuiz.Enabled = true;
            btnStartQuiz.Text = "Play Again";
            LogActivity($"Quiz completed - Score: {quizScore}/{quizQuestions.Count}");
            RefreshActivityLog();
        }

        // ==============================
        // TASK ASSISTANT
        // ==============================

        private void RefreshTaskList()
        {
            if (lstTasks == null) return;
            lstTasks.Items.Clear();
            var list = taskRepository.GetAllTasks();
            foreach (var t in list)
            {
                lstTasks.Items.Add(t.ToString());
            }
            if (lblTaskCount != null)
                lblTaskCount.Text = $"Pending: {taskRepository.GetPendingCount()} / Total: {taskRepository.GetTotalCount()}";
            if (btnCompleteTask != null) btnCompleteTask.Enabled = false;
            if (btnDeleteTask != null) btnDeleteTask.Enabled = false;
            selectedTaskId = -1;
            if (lblTaskDetail != null) lblTaskDetail.Text = "Select a task to see details";
        }

        private void CheckDueToday()
        {
            var due = taskRepository.GetDueToday();
            var overdue = taskRepository.GetOverdue();
            if (overdue.Count > 0)
                AddMessage($"Reminder: You have {overdue.Count} overdue task(s). Go to Task Assistant to check them.", false);
            else if (due.Count > 0)
                AddMessage($"Reminder: You have {due.Count} task(s) due today. Go to Task Assistant tab.", false);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            string desc = txtTaskDescription.Text.Trim();
            DateTime due = dtpTaskDueDate.Value;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.", "Missing Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var added = taskRepository.AddTask(title, desc, due);
            if (added != null)
            {
                LogActivity("Task added: " + added.Title);
                RefreshActivityLog();
                RefreshTaskList();
                txtTaskTitle.Clear();
                txtTaskDescription.Clear();
                MessageBox.Show("Task added successfully!", "Task Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex < 0) return;
            string selected = lstTasks.SelectedItem.ToString();
            int start = selected.IndexOf('[') + 1;
            int end = selected.IndexOf(']');
            if (start > 0 && end > start && int.TryParse(selected.Substring(start, end - start), out int id))
            {
                selectedTaskId = id;
                var task = taskRepository.GetTaskById(id);
                if (task != null)
                {
                    lblTaskDetail.Text = $"Title: {task.Title}\nDescription: {task.Description}\nDue: {task.DueDate:yyyy-MM-dd}\nStatus: {task.StatusText}\nCreated: {task.CreatedAt:yyyy-MM-dd HH:mm}";
                    btnCompleteTask.Enabled = !task.IsCompleted;
                    btnDeleteTask.Enabled = true;
                }
            }
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            if (selectedTaskId == -1) return;
            if (taskRepository.MarkComplete(selectedTaskId))
            {
                var t = taskRepository.GetTaskById(selectedTaskId);
                LogActivity("Task completed: " + (t?.Title ?? ""));
                RefreshActivityLog();
                RefreshTaskList();
                MessageBox.Show("Task marked as completed!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (selectedTaskId == -1) return;
            var result = MessageBox.Show("Are you sure you want to delete this task?", "Delete Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (taskRepository.DeleteTask(selectedTaskId))
                {
                    LogActivity("Task deleted - ID: " + selectedTaskId);
                    RefreshActivityLog();
                    RefreshTaskList();
                }
            }
        }

        // Called from Chat when user types "Add task - ..."
        public void AddTaskFromChat(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return;
            var added = taskRepository.AddTask(title, "", DateTime.Now.AddDays(1));
            if (added != null)
            {
                LogActivity("Task added from Chat: " + added.Title);
                RefreshActivityLog();
                RefreshTaskList();
            }
        }

        // ==============================
        // ACTIVITY LOG
        // ==============================
        private void LogActivity(string action)
        {
            activityLog.Add($"{DateTime.Now:yyyy-MM-dd HH:mm} - {action}");
        }
        private void RefreshActivityLog()
        {
            if (lstActivityLog == null) return;
            lstActivityLog.Items.Clear();
            int start = Math.Max(0, activityLog.Count - 10);
            for (int i = start; i < activityLog.Count; i++)
                lstActivityLog.Items.Add(activityLog[i]);
        }
        private void btnShowMoreLog_Click(object sender, EventArgs e)
        {
            if (lstActivityLog == null) return;
            lstActivityLog.Items.Clear();
            foreach (var a in activityLog) lstActivityLog.Items.Add(a);
        }
        private string GetActivityLog()
        {
            if (activityLog.Count == 0) return "There are currently no activities recorded.";
            string result = "Here is a summary of your recent activities:\n\n";
            int start = Math.Max(0, activityLog.Count - 10);
            for (int i = start; i < activityLog.Count; i++)
                result += (i + 1) + ". " + activityLog[i] + "\n\n";
            return result;
        }

        // ==============================
        // OTHER HANDLERS
        // ==============================
        private void button1_Click(object sender, EventArgs e) { }
        private void txtUserInput_TextChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void txtLog_TextChanged(object sender, EventArgs e) { }
        private void button1_KeyDown(object sender, KeyEventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void tabChat_Click(object sender, EventArgs e) { }
        private void tabQuiz_Click(object sender, EventArgs e) { }
    }
}