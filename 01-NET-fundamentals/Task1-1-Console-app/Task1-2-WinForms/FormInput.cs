using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1_2_WinForms
{
    public partial class FormInput : Form
    {
        public string userName;
        public FormInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userName = textBoxName.Text;
            var outputForm = new FormOutput();
            outputForm.Show();
        }
    }
}
