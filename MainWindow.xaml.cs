using System.Media;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace FRANK_CHATBOT_PART2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnstart_Click(object sender, RoutedEventArgs e)
        {
            // get the name from the text box
            string name = txtName.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            // Store name (like my static variable in Part 1)
            Session.UserName = name;

            // Play greeting audio
            PlayGreeting();

            // Show welcome message (like Console.WriteLine)
            //MessageBox.Show($"Welcome {name}, I'm FRANK your cybersecurity assistant!");

            // Open next window (your chatbot UI)
            chatbot chat = new  chatbot();
            chat.Show();

            // Close start window
            this.Close();
        }

        // audio player method
        private void PlayGreeting()
        {
            try
            {
                // Note: Update the path to your audio file as needed
                SoundPlayer player = new SoundPlayer(@"C:\Users\Sanele\source\repos\FRANK_CHATBOT_PART2\cybeeaudio.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio error: " + ex.Message);
            }
        }
    }
}