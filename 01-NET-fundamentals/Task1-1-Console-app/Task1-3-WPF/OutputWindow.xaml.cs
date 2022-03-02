using System.Windows;
using Task2_Class_library;

namespace Task1_3_WPF
{
    /// <summary>
    /// Interaction logic for OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        public OutputWindow()
        {
            InitializeComponent();
        }

        private void labelOuput_Loaded(object sender, RoutedEventArgs e)
        {
            var userName = DataInterface.userName;
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Mr.Unknown";
            }
            labelOuput.Content = $"Hello, {userName}!";
            var greetingsFromClassLibrary = TextProcessing.CreateGreeting(userName);
            labelGreetingsFromClassLibrary.Content = $"Result from the class library: {greetingsFromClassLibrary}";
        }
    }
}
