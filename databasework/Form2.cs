using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace databasework
{
    public partial class FormEditor : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = auto.accdb";
        OleDbConnection connection;
        private OleDbCommandBuilder oleDbCommandBuilder = null;
        private OleDbDataAdapter oleDbDataAdapter = null;
        private DataSet dataSet = null;
        private bool newRowAdding = false;
        public FormEditor()
        {
            InitializeComponent();
        }
        private void FormEditor_Load(object sender, EventArgs e)
        {
            textBoxEdit.Text = StaticData.DataBuffer;
            connection = new OleDbConnection(connectionString);
            connection.Open();
            LoadData();
        }



        private void FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
        private void LoadData()
        {
            try
            {
                oleDbDataAdapter = new OleDbDataAdapter($"SELECT *, 'Delete' AS [Command] FROM {textBoxEdit.Text}", connection);
                oleDbCommandBuilder = new OleDbCommandBuilder(oleDbDataAdapter);
                oleDbCommandBuilder.GetInsertCommand();
                oleDbCommandBuilder.GetDeleteCommand();
                oleDbCommandBuilder.GetUpdateCommand();
                dataSet = new DataSet();
                oleDbDataAdapter.Fill(dataSet, $"{textBoxEdit.Text}");
                dataGridViewEdit.DataSource = dataSet.Tables[$"{textBoxEdit.Text}"];
                for (int i = 0; i < dataGridViewEdit.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewEdit[0, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReloadData()
        {
            try
            {
            dataSet.Tables[$"{textBoxEdit.Text}"].Clear();
            oleDbDataAdapter.Fill(dataSet, $"{textBoxEdit.Text}");
            dataGridViewEdit.DataSource = dataSet.Tables[$"{textBoxEdit.Text}"];
            for (int i = 0; i < dataGridViewEdit.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridViewEdit[0, i] = linkCell;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            ReloadData();
        }


        private void dataGridViewEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string task = dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridViewEdit.Rows.RemoveAt(rowIndex);
                            dataSet.Tables[$"{textBoxEdit.Text}"].Rows[rowIndex].Delete();
                            oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridViewEdit.Rows.Count - 2;
                        DataRow row = dataSet.Tables[$"{textBoxEdit.Text}"].NewRow();
                        switch ($"{textBoxEdit.Text}")
                        {
                            case "Клиенты":
                                {
                                    row["ФИО"] = dataGridViewEdit.Rows[rowIndex].Cells["ФИО"].Value;
                                    row["Телефон"] = dataGridViewEdit.Rows[rowIndex].Cells["Телефон"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows.Add(row);
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows.RemoveAt(dataSet.Tables[$"{textBoxEdit.Text}"].Rows.Count - 1);
                                    dataGridViewEdit.Rows.RemoveAt(dataGridViewEdit.Rows.Count - 2);
                                    dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value = "Delete";
                                    oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                                    newRowAdding = false;
                                    break;
                                }
                            case "Сотрудники":
                                {
                                    row["ФИО"] = dataGridViewEdit.Rows[rowIndex].Cells["ФИО"].Value;
                                    row["Телефон"] = dataGridViewEdit.Rows[rowIndex].Cells["Телефон"].Value;
                                    row["Должность"] = dataGridViewEdit.Rows[rowIndex].Cells["Должность"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows.Add(row);
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows.RemoveAt(dataSet.Tables[$"{textBoxEdit.Text}"].Rows.Count - 1);
                                    dataGridViewEdit.Rows.RemoveAt(dataGridViewEdit.Rows.Count - 2);
                                    dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value = "Delete";
                                    oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                                    newRowAdding = false;
                                    break;
                                }
                            case "Услуги":
                                {
                                    row["Тип работ"] = dataGridViewEdit.Rows[rowIndex].Cells["Тип работ"].Value;
                                    row["Цена"] = dataGridViewEdit.Rows[rowIndex].Cells["Цена"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows.Add(row);
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows.RemoveAt(dataSet.Tables[$"{textBoxEdit.Text}"].Rows.Count - 1);
                                    dataGridViewEdit.Rows.RemoveAt(dataGridViewEdit.Rows.Count - 2);
                                    dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value = "Delete";
                                    oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                                    newRowAdding = false;
                                    break;
                                }
                            case "Расчеты":
                                {
                                    row["Дата оказания"] = dataGridViewEdit.Rows[rowIndex].Cells["Дата оказания"].Value;
                                    row["Клиент"] = dataGridViewEdit.Rows[rowIndex].Cells["Клиент"].Value;
                                    row["Тип услуги"] = dataGridViewEdit.Rows[rowIndex].Cells["Тип услуги"].Value;
                                    row["Стоимость работ"] = dataGridViewEdit.Rows[rowIndex].Cells["Стоимость работ"].Value;
                                    row["Сотрудник"] = dataGridViewEdit.Rows[rowIndex].Cells["Сотрудник"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows.Add(row);
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows.RemoveAt(dataSet.Tables[$"{textBoxEdit.Text}"].Rows.Count - 1);
                                    dataGridViewEdit.Rows.RemoveAt(dataGridViewEdit.Rows.Count - 2);
                                    dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value = "Delete";
                                    oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                                    newRowAdding = false;
                                    break;
                                }
                        }
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        switch ($"{textBoxEdit.Text}")
                        {
                            case "Клиенты":
                                {
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["ФИО"] = dataGridViewEdit.Rows[r].Cells["ФИО"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Телефон"] = dataGridViewEdit.Rows[r].Cells["Телефон"].Value;
                                    dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value = "Delete";
                                    oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                                    break;
                                }
                            case "Сотрудники":
                                {
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["ФИО"] = dataGridViewEdit.Rows[r].Cells["ФИО"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Телефон"] = dataGridViewEdit.Rows[r].Cells["Телефон"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Должность"] = dataGridViewEdit.Rows[r].Cells["Должность"].Value;
                                    dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value = "Delete";
                                    oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                                    break;
                                }
                            case "Услуги":
                                {
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Тип работ"] = dataGridViewEdit.Rows[r].Cells["ФИО"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Цена"] = dataGridViewEdit.Rows[r].Cells["Цена"].Value;
                                    dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value = "Delete";
                                    oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                                    break;
                                }
                            case "Расчеты":
                                {
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Дата оказания"] = dataGridViewEdit.Rows[r].Cells["ФИО"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Клиент"] = dataGridViewEdit.Rows[r].Cells["Телефон"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Тип услуги"] = dataGridViewEdit.Rows[r].Cells["ФИО"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Стоимость работ"] = dataGridViewEdit.Rows[r].Cells["Телефон"].Value;
                                    dataSet.Tables[$"{textBoxEdit.Text}"].Rows[r]["Сотрудник"] = dataGridViewEdit.Rows[r].Cells["Телефон"].Value;
                                    dataGridViewEdit.Rows[e.RowIndex].Cells[0].Value = "Delete";
                                    oleDbDataAdapter.Update(dataSet, $"{textBoxEdit.Text}");
                                    break;
                                }
                        }
                    }
                    ReloadData();

                }
            }
            catch
            {

            }
        }
        private void dataGridViewEdit_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridViewEdit.Rows.Count - 2;
                    DataGridViewRow row = dataGridViewEdit.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewEdit[0, lastRow] = linkCell;
                    row.Cells["Command"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewEdit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridViewEdit.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridViewEdit.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridViewEdit[0, rowIndex] = linkCell;
                    editingRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}