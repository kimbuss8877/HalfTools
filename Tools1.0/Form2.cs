using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools1._0
{
    public partial class Form2 : Form
    {

        private int MasterScret = 123456;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form1 newform1 = new Form1();
            newform1.ShowDialog();
            this.Close();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
         //   textBox2.Focus();
        }

      
    }
}
