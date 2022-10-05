using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proizv_Praktika_3kurs_Pharmacy
{
    public partial class Form1 : Form
    {

        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void ExitBut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EnterBut_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Dispose();

        }
    }
}
