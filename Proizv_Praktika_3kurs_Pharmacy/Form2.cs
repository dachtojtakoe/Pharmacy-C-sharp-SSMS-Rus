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

    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public enum Tables
    {
        Medicines,
        Arrival,
        Realization,
        Pharmacists,
        Manufacturers
    }


    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            hideTextBoxes();
            textBoxSearch.Visible = false;
            pictureBoxSearch2.Visible = false;
        }

        DataBase dataBase = new DataBase();
        int selectedRow;
        static Tables CurrentTable;

        static public Tables GetTable()
        {
            return CurrentTable;
        }


        private void CreateColumns()
        {
            if (CurrentTable == Tables.Medicines)
            {
                dataGrid.Columns.Add("MedID", "ID");
                dataGrid.Columns.Add("Name", "Наименование");
                dataGrid.Columns.Add("Annotation", "Аннотация");
                dataGrid.Columns.Add("Manufacturer", "Поставщик");
                dataGrid.Columns.Add("StorageLife", "Срок годности");
                dataGrid.Columns.Add("StorageLocation", "Место хранения");
                dataGrid.Columns.Add("IsNew", String.Empty);
            }
            else if (CurrentTable == Tables.Arrival)
            {
                dataGrid.Columns.Add("ArrID", "ID");
                dataGrid.Columns.Add("Medicine", "Лекарство");
                dataGrid.Columns.Add("ArrivalDate", "Дата поступления");
                dataGrid.Columns["ArrivalDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dataGrid.Columns.Add("BuyCount", "Кол-во куплено");
                dataGrid.Columns.Add("PriceForUnit", "Цена за единицу");
                dataGrid.Columns.Add("Pharmacist", "Фармацевт");
                dataGrid.Columns.Add("IsNew", String.Empty);
            }
            else if (CurrentTable == Tables.Realization)
            {
                dataGrid.Columns.Add("RealizID", "ID");
                dataGrid.Columns.Add("Medicine", "Лекарство");
                dataGrid.Columns.Add("RealizationDate", "Дата реализации");
                dataGrid.Columns["RealizationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dataGrid.Columns.Add("CellCount", "Кол-во продано");
                dataGrid.Columns.Add("PriceForUnit", "Цена за единицу");
                dataGrid.Columns.Add("Pharmacist", "Фармацевт");
                dataGrid.Columns.Add("IsNew", String.Empty);
            }
            else if (CurrentTable == Tables.Pharmacists)
            {
                dataGrid.Columns.Add("PharmstID", "ID");
                dataGrid.Columns.Add("Name", "Имя");
                dataGrid.Columns.Add("Surname", "Фамилия");
                dataGrid.Columns.Add("Patronymic", "Отчество");
                dataGrid.Columns.Add("Age", "Возраст");
                dataGrid.Columns.Add("IsNew", String.Empty);
                dataGrid.Columns[5].Visible = false;

            }
            else if (CurrentTable == Tables.Manufacturers)
            {
                dataGrid.Columns.Add("ManfID", "ID");
                dataGrid.Columns.Add("Name", "Наименование");
                dataGrid.Columns.Add("IsNew", String.Empty);
                dataGrid.Columns[2].Visible = false;
                dataGrid.Columns[1].Width = 200;

            }

            dataGrid.Columns[0].Width = 30;
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);



            if (CurrentTable == Tables.Medicines || CurrentTable == Tables.Arrival || CurrentTable == Tables.Realization)
            {
                dataGrid.Columns[6].Visible = false;
                dataGrid.Columns[6].Width = 10;
                dataGrid.Columns[1].Width = 130;
                dataGrid.Columns[2].Width = 249;

                label1.Text = dataGrid.Columns[1].HeaderCell.Value.ToString();
                label2.Text = dataGrid.Columns[2].HeaderCell.Value.ToString();
                label3.Text = dataGrid.Columns[3].HeaderCell.Value.ToString();
                label4.Text = dataGrid.Columns[4].HeaderCell.Value.ToString();
                label5.Text = dataGrid.Columns[5].HeaderCell.Value.ToString();
            }
        }


        private void RefreshDataGrid(DataGridView datagrid)
        {
  
            string querystr = $"select * from {CurrentTable}";

            SqlCommand command = new SqlCommand(querystr, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(datagrid, reader);
            }

            reader.Close();

            dataBase.closeConnection();
        }

        private void ReadSingleRow(DataGridView datagrid, IDataRecord record)
        {
            if (CurrentTable == Tables.Medicines)
                datagrid.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetString(4), record.GetString(5), RowState.ModifiedNew);
            else if (CurrentTable == Tables.Arrival)
                datagrid.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetDateTime(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), RowState.ModifiedNew);
            else if (CurrentTable == Tables.Realization)
                datagrid.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetDateTime(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), RowState.ModifiedNew);
            else if (CurrentTable == Tables.Pharmacists)
                datagrid.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), RowState.ModifiedNew);
            else if (CurrentTable == Tables.Manufacturers)
                datagrid.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }


        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentTable == Tables.Medicines || CurrentTable == Tables.Arrival || CurrentTable == Tables.Realization)

            {
                selectedRow = e.RowIndex;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGrid.Rows[selectedRow];

                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    textBox3.Text = row.Cells[3].Value.ToString();
                    textBox4.Text = row.Cells[4].Value.ToString();
                    textBox5.Text = row.Cells[5].Value.ToString();
                }
            }
        }

        private void медикаментыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridClear();

            CurrentTable = Tables.Medicines;
            CreateColumns();
            RefreshDataGrid(dataGrid);
            showTextBoxes();
        }

        private void поставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridClear();

            CurrentTable = Tables.Arrival;
            CreateColumns();
            RefreshDataGrid(dataGrid);
            showTextBoxes();
        }

        private void реализацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridClear();

            CurrentTable = Tables.Realization;
            CreateColumns();
            RefreshDataGrid(dataGrid);
            showTextBoxes();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridClear();

            CurrentTable = Tables.Pharmacists;
            CreateColumns();
            RefreshDataGrid(dataGrid);
            hideTextBoxes();
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridClear();

            CurrentTable = Tables.Manufacturers; 
            CreateColumns();
            RefreshDataGrid(dataGrid);
            hideTextBoxes();
        }


        private void showTextBoxes()
        {
            groupBoxNote.Visible = true;
            groupBoxActions.Visible = true;
            groupBoxControls.Visible = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            textBoxSearch.Text = "";
        }

        private void hideTextBoxes()
        {
            groupBoxNote.Visible = false;
            groupBoxActions.Visible = false;
            groupBoxControls.Visible = false;

            clearTextBoxes();
        }

        private void clearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            textBoxSearch.Text = "";
        }

        private void pictureBoxClear_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            dataGridClear();
            CreateColumns();
            RefreshDataGrid(dataGrid);
            clearTextBoxes();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Visible = true;
            pictureBoxSearch.Visible = false;
            pictureBoxSearch2.Visible = true;
        }

        private void pictureBoxSearch2_Click(object sender, EventArgs e)
        {
            textBoxSearch.Visible = false;
            textBoxSearch.Text = "";
            pictureBoxSearch.Visible = true;
            pictureBoxSearch2.Visible = false;

        }


        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (CurrentTable == Tables.Medicines || CurrentTable == Tables.Arrival || CurrentTable == Tables.Realization)
                Search(dataGrid);
        }

        private void Search(DataGridView dataGrid)
        {

            dataGrid.Rows.Clear();
            string query = string.Empty;

            if (CurrentTable == Tables.Medicines)
                query = $"select * from Medicines where concat (MedID, Name, Annotation, Manufacturer,StorageLife, StorageLocation) like '%" + textBoxSearch.Text + "%'";
            else if (CurrentTable == Tables.Arrival)
                query = $"select * from Arrival where concat (ArrID, Medicine, ArrivalDate, BuyCount, PriceForUnit, Pharmacist) like '%" + textBoxSearch.Text + "%'";
            else if (CurrentTable == Tables.Realization)
                query = $"select * from Realization where concat (RealizID, Medicine, RealizationDate, CellCount, PriceForUnit, Pharmacist) like '%" + textBoxSearch.Text + "%'";
        

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dataGrid, reader);
            }

            reader.Close();

        }


        private void dataGridClear()
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
        }





        private void buttonNew_Click(object sender, EventArgs e)
        {
            FormNew formAdd = new FormNew(this.label1, this.label2, this.label3, this.label4, this.label5);
            formAdd.Show();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            deleteRow();
            clearTextBoxes();
        }

        private void deleteRow()
        {
            int index = dataGrid.CurrentCell.RowIndex;

            dataGrid.Rows[index].Visible = false;

            if (dataGrid.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGrid.Rows[index].Cells[6].Value = RowState.Deleted;
                return;
            }
            dataGrid.Rows[index].Cells[6].Value = RowState.Deleted;
        }


        private void Update()
        {
            dataBase.openConnection();

            for(int index = 0; index < dataGrid.Rows.Count; index++)
            {
                var rowState = (RowState)dataGrid.Rows[index].Cells[6].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGrid.Rows[index].Cells[0].Value);


                    string curID = string.Empty;
                    if (CurrentTable == Tables.Medicines)
                        curID = "MedID";
                    else if (CurrentTable == Tables.Arrival)
                        curID = "ArrID";
                    else if (CurrentTable == Tables.Realization)
                        curID = "RealizId";


                    var delquery = $"delete from {CurrentTable} where {curID} = {id}";

                    
                    var command = new SqlCommand(delquery, dataBase.getConnection());

                    command.ExecuteNonQuery();
                }

                if(rowState == RowState.Modified)
                {
                    var id = dataGrid.Rows[index].Cells[0].Value.ToString();

                    var t1 = dataGrid.Rows[index].Cells[1].Value.ToString();
                    var t2 = dataGrid.Rows[index].Cells[2].Value.ToString();
                    var t3 = dataGrid.Rows[index].Cells[3].Value.ToString();
                    var t4 = dataGrid.Rows[index].Cells[4].Value.ToString();
                    var t5 = dataGrid.Rows[index].Cells[5].Value.ToString();

                    string changequery = string.Empty;

                    if (CurrentTable == Tables.Medicines)
                        changequery = $"update {CurrentTable} set Name = '{t1}', Annotation = '{t2}', Manufacturer = '{t3}', StorageLife = '{t4}', StorageLocation = '{t5}' where MedID = {id}";
                    else if (CurrentTable == Tables.Arrival)
                        changequery = $"update {CurrentTable} set Medicine = '{t1}', ArrivalDate = '{t2}', BuyCount = '{t3}', PriceForUnit = '{t4}', Pharmacist = '{t5}' where ArrID = {id}";
                    else if (CurrentTable == Tables.Realization)
                        changequery = $"update {CurrentTable} set Medicine = '{t1}', RealizationDate = '{t2}', CellCount = '{t3}', PriceForUnit = '{t4}', Pharmacist = '{t5}' where RealizID = {id}";


                    SqlCommand command = new SqlCommand(changequery, dataBase.getConnection());

                    command.ExecuteNonQuery();
                }
            }

            dataBase.closeConnection();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {

            var selectedRowIndex = dataGrid.CurrentCell.RowIndex;
            var id = dataGrid.Rows[selectedRowIndex].Cells[0].Value.ToString();



            if (CurrentTable == Tables.Medicines)
            {
                var t1 = textBox1.Text;
                var t2 = textBox2.Text;
                int t3 = Convert.ToInt32(textBox3.Text);
                var t4 = textBox4.Text;
                var t5 = textBox5.Text;

                dataGrid.Rows[selectedRowIndex].SetValues(id, t1, t2, t3, t4, t5);
                dataGrid.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;



            }
            else
            {
                int t1 = Convert.ToInt32(textBox1.Text);
                DateTime t2 = Convert.ToDateTime(textBox2.Text);
                int t3 = Convert.ToInt32(textBox3.Text);
                int t4 = Convert.ToInt32(textBox4.Text);
                int t5 = Convert.ToInt32(textBox5.Text);

                dataGrid.Rows[selectedRowIndex].SetValues(id, t1, t2, t3, t4, t5);
                dataGrid.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;

            }
        }
    }
}
