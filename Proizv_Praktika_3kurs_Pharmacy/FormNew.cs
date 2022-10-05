using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Proizv_Praktika_3kurs_Pharmacy
{
    public partial class FormNew : Form
    {
        DataBase dataBase = new DataBase();

        string[] strs = new string[5];

        string curTable = Form2.GetTable().ToString();


        public FormNew(Label lab1, Label lab2, Label lab3, Label lab4, Label lab5)
        {
            InitializeComponent();

            strs[0] = lab1.Text.ToString();
            strs[1] = lab2.Text.ToString();
            strs[2] = lab3.Text.ToString();
            strs[3] = lab4.Text.ToString();
            strs[4] = lab5.Text.ToString();
       

        }

        private void FormNew_Load(object sender, EventArgs e)
        {


            if (curTable == "Medicines")
                labelTable.Text += "Медикаменты";
            else if (curTable == "Arrival")
                labelTable.Text += "Поставки";
            else if (curTable == "Realization")
                labelTable.Text += "Реализация";


            label1.Text = strs[0];
            label2.Text = strs[1];
            label3.Text = strs[2];
            label4.Text = strs[3];
            label5.Text = strs[4];

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            string query = string.Empty;

            if (curTable == "Medicines")
            {
                var t1 = textBox1.Text;
                var t2 = textBox2.Text;
                int t3 = Convert.ToInt32(textBox3.Text);
                var t4 = textBox4.Text;
                var t5 = textBox5.Text;

                query = $"insert into Medicines (Name, Annotation, Manufacturer, StorageLife, StorageLocation) values ('{t1}','{t2}','{t3}','{t4}','{t5}')";


            }
            else 
            {
                int t1 = Convert.ToInt32(textBox1.Text);
                DateTime t2 = Convert.ToDateTime(textBox2.Text);
                int t3 = Convert.ToInt32(textBox3.Text);
                int t4 = Convert.ToInt32(textBox4.Text);
                int t5 = Convert.ToInt32(textBox5.Text);

                if (curTable == "Arrival")
                {
                    query = $"insert into Arrival (Medicine, ArrivalDate, BuyCount, PriceForUnit, Pharmacist) values ('{t1}','{t2}','{t3}','{t4}','{t5}')";
                }
                else
                {
                    query = $"insert into Realization (Medicine, RealizationDate, CellCount, PriceForUnit, Pharmacist) values ('{t1}','{t2}','{t3}','{t4}','{t5}')";
                }
            }

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запись успешно добавлена!");
            this.Dispose();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
