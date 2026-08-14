using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System.Media;
namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlayGreeting();
            DisplayLogo();
        }

        private void PlayGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\Student\\source\\repos\\ConsoleApp1\\ConsoleApp1\\Voice\\aisound.wav");
            player.Play();
        }

        private void DisplayLogo()
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\Student\\Pictures\\Screenshots\\logo.png");
        }

  
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
