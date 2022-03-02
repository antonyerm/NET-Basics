using System;
using System.Windows.Forms;
using Task2_Class_library;


namespace Task1_2_WinForms
{
    public partial class FormOutput : Form
    {
        public FormOutput()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var userName = Program.formInput.userName;
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Mr.Unknown";
            }

            labelOutput.Text = $"Hello, {userName}!";
            var greetingsFromClassLibrary = TextProcessing.CreateGreeting(userName);
            labelGreetingsFromLibrary.Text = $"Result from the class library: {greetingsFromClassLibrary}";
        }
    }
}
