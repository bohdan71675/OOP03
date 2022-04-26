using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Spotrebic spotrebic = new Spotrebic("Ab-002C-K9", 2);
        private void button1_Click(object sender, EventArgs e)
        {
            spotrebic.Zapni();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            spotrebic.Vypni();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(spotrebic.ToString());
        }
    }
}
