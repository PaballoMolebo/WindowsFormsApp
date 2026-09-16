using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        // Chatbot engine
        private ChatEngine chatEngine = new ChatEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlayGreeting();
            DisplayLogo();

            // Welcome message in the conversation log
            txtLog.AppendText(
                "Bot: Hello! I am your cybersecurity chatbot." +
                Environment.NewLine);

            txtLog.AppendText(
                "Bot: You can ask me about passwords, phishing, malware, " +
                "firewalls, encryption, VPNs, 2FA and online safety." +
                Environment.NewLine +
                Environment.NewLine);

            // Put cursor in the input box
            txtUserInput.Focus();
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer(
                    "C:\\Users\\Student\\source\\repos\\ConsoleApp1\\ConsoleApp1\\Voice\\aisound.wav");

                player.Play();
            }
            catch (Exception)
            {
                // If the sound file cannot be found,
                // the chatbot can still work normally.
            }
        }

        private void DisplayLogo()
        {
            try
            {
                pictureBox1.Image = Image.FromFile(
                    "C:\\Users\\Student\\Pictures\\Screenshots\\logo.png");
            }
            catch (Exception)
            {
                // If the logo cannot be found,
                // the rest of the application will still run.
            }
        }

        // SEND BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        // If your actual Send button uses button2_Click_1,
        // this will also make it work.
        private void button2_Click_1(object sender, EventArgs e)
        {
            SendMessage();
        }

        // Main method for sending a message
        private void SendMessage()
        {
            string userMessage = txtUserInput.Text.Trim();

            // Don't send an empty message
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            // Display the user's message
            txtLog.AppendText(
                "You: " + userMessage +
                Environment.NewLine);

            // Get response from ChatEngine
            string response = chatEngine.GetResponse(userMessage);

            // Display chatbot response
            txtLog.AppendText(
                "Bot: " + response +
                Environment.NewLine +
                Environment.NewLine);

            // Clear input box
            txtUserInput.Clear();

            // Put cursor back in input box
            txtUserInput.Focus();
        }

        // Allows the user to press ENTER to send
        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                SendMessage();
            }
        }

        // Existing events from your form
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void txtUserInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
