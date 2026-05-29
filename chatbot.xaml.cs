using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;


namespace FRANK_CHATBOT_PART2
{
    /// <summary>
    /// Interaction logic for chatbot.xaml
    /// </summary>
    /// 

    public partial class chatbot : Window
    {
        public chatbot()
        {
            InitializeComponent();
            // Display personalized  welcome message when the program starts
            AddMessage($"Welcome {Session.UserName}, I'm CYBIEEE. Ask me about cybersecurity.", false);
        }
        //int count = 0;
        // MEMORY
        private string FavTopic = "";

        // RANDOM RESPONSES
        private static Random Random = new Random();
        // DELEGATE
        private delegate string ResponseDelegate(string input);

        // GENERIC COLLECTION
        List<string> chatsHistory = new List<string>();
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = txtbxMessage.Text;
            if (string.IsNullOrEmpty(userMessage))
            { MessageBox.Show("Please enter a message before sending.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning); }
            else
            {
                AddMessage(userMessage, true);
                // Save to history
                chatsHistory.Add("USER: " + userMessage);
                txtbxMessage.Clear();
                // Simulate bot response (you can replace this with actual chatbot logic)

                

                // Create delegate instance
                ResponseDelegate responseHandler = GetResponse;

                // Invoke delegate
                string botResponse = responseHandler(userMessage);
                // Add bot response
                AddMessage(botResponse, false);

            }

            //count++;
            //lblcount.Content = count.ToString();
        }


        private void AddMessage(string message, bool isUser)
        {
            Border bubble = new Border
            {
                //simple if statement to determine the background color of the message bubble based on whether it's a user message or a bot message
                Background = isUser ? Brushes.LightGray : Brushes.Green,
                CornerRadius = new CornerRadius(13),
                Padding = new Thickness(10),
                Margin = new Thickness(5),
                MaxWidth = 250,
                // if the message is from the user, align it to the right; otherwise, align it to the left
                HorizontalAlignment = isUser ? HorizontalAlignment.Right : HorizontalAlignment.Left
            };

            TextBlock text = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = isUser ? Brushes.Black : Brushes.Black
            };

            bubble.Child = text;

            pnlChat.Children.Add(bubble);

            // Auto scroll
            ChatScrollViewer.ScrollToEnd();
        }

        private string GetResponse(string input)
        {
            input = input.ToLower();

            // BASIC CONVERSATION =================

            if (input.Contains("how are you"))
            {
                return "I'm functioning perfectly! I'm here to help you stay safe online.";
            }

            else if (input.Contains("your purpose") || input.Contains("what do you do"))
            {
                return "My purpose is to educate users about cybersecurity and online safety.";
            }

            else if (input.Contains("what can i ask"))
            {
                return "You can ask me about phishing, scams, privacy, passwords, malware, and suspicious links.";
            }

            // SENTIMENT DETECTION =================

            else if (input.Contains("worried") || input.Contains("scared"))
            {
                return $"Do not worry {Session.UserName}, I can help you stay safe online.";
            }

            else if (input.Contains("happy"))
            {
                return "I am glad you are feeling positive today!";
            }

            else if (input.Contains("angry") || input.Contains("frustrated"))
            {
                return "Cybersecurity problems can be frustrating, but learning helps a lot.";
            }

            // MEMORY =================

            // store the user's favorite topic in the chatbot's memory and recall it when asked. 
            else if (input.Contains("my favorite topic is"))
            {
                string[] parts = input.Split("is");

                if (parts.Length > 1)
                {
                    FavTopic = parts[1];
                    // Store in memory
                    return $"Great! I will remember that your favorite topic is {FavTopic}.";
                }
            }

            else if (input.Contains("favorite topic"))
            {
                if (FavTopic != "")
                {
                    return $"Your favorite topic is {FavTopic}.";
                }

                else
                {
                    return "You have not told me your favorite topic yet.";
                }
            }

            // CYBERSECURITY KEYWORDS =================

            else if (input.Contains("phishing"))
            {
                string[] responses =
                {
                    "Phishing is when scammers trick users into revealing personal information.",

                    "Be careful of fake emails asking for passwords or banking information.",

                    "Always verify links before entering sensitive information."
                };

                return responses[Random.Next(responses.Length)];
            }

            else if (input.Contains("password"))
            {
                string[] responses =
                {
                    "Strong passwords should contain symbols, numbers, and uppercase letters.",

                    "Avoid weak passwords like 123456.",

                    "Using different passwords for each account improves security."
                 };

                return responses[Random.Next(responses.Length)];
            }
            // The chatbot can provide random responses from a predefined list of responses related to the keyword.
            
            else if (input.Contains("privacy"))
            {
                return "Privacy protects your personal information from unauthorized access online.";
            }

            else if (input.Contains("scam"))
            {
                return "Scammers often create urgency to trick victims into making mistakes.";
            }

            else if (input.Contains("malware"))
            {
                return "Malware is harmful software designed to damage systems or steal data.";
            }

            else if (input.Contains("link") || input.Contains("url"))
            {
                return "Be careful when clicking links. Always check if the source is trusted.";
            }

            //DEFAULT =================

            return "I am not sure I understand. Try asking about passwords, scams, phishing, malware, privacy, or suspicious links.";
        }
    }
}
