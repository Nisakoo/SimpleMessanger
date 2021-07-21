using ChatLib.Chats;
using System;
using System.Windows;
using System.Windows.Input;

namespace MessangerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IChat chat;
        public MainWindow()
        {
            InitializeComponent();
            chat = new Chat();
            chat.Start();

            messagesList.ItemsSource = chat.GetHistory();
        }

        private void SendMessage()
        {
            string content = messageTextBox.Text;
            string username = usernameTextBox.Text;

            if (String.IsNullOrEmpty(username))
            {
                MessageBox.Show(
                    "Username is empty",
                    "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            if (String.IsNullOrEmpty(content))
                return;

            chat.SendMessage(username, content);

            messageTextBox.Text = String.Empty;
        }

        private void sendButton_Click(object sender, RoutedEventArgs args)
        {
            SendMessage();
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Enter)
                SendMessage();
        }
    }
}
