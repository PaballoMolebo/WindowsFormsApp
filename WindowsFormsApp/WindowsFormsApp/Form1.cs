using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private ChatEngine chatEngine = new ChatEngine();
        private FlowLayoutPanel flowChat;

        // UNDER IMAGE DISPLAY - NO QUESTION MARK
        private Panel panelUnderLogo;
        private Label lblConnected;
        private Label lblVersion;

        public Form1()
        {
            InitializeComponent();
            CreateChatPanel();
        }

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

        // Displaying the connected image

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayLogo();
            AddMessage("Hello! I am your cybersecurity chatbot.", false);
            AddMessage("You can ask me about passwords, phishing, malware, firewalls, encryption, VPNs, 2FA and online safety.", false);
            txtUserInput.Focus();
        }

        private void DisplayLogo()
        {
            try
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\Student\Pictures\Screenshots\logo.png");
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
            bubble.BackColor = isUser ? Color.SeaGreen : Color.Navy;
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

        private void button2_Click(object sender, EventArgs e) { SendMessage(); }
        private void button2_Click_1(object sender, EventArgs e) { SendMessage(); }

        private void SendMessage()
        {
            string userMessage = txtUserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage)) return;
            AddMessage(userMessage, true);
            txtUserInput.Clear();
            string response = chatEngine.GetResponse(userMessage);
            AddMessage(response, false);
            txtUserInput.Focus();
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

        private void button1_Click(object sender, EventArgs e) { }
        private void txtUserInput_TextChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void txtLog_TextChanged(object sender, EventArgs e) { }
        private void button1_KeyDown(object sender, KeyEventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}