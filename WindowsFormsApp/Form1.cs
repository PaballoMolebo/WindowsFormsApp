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
            SoundPlayer player = new SoundPlayer("greeting.wav");
            player.Play();
        }

        private void DisplayLogo()
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\User\\Pictures\\image.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        
    }
}
