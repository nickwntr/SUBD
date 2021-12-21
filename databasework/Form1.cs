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
using LiveCharts;
using LiveCharts.Wpf;

namespace databasework
{
    public partial class FormMain : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = auto.accdb";
        OleDbConnection connection;
        ChartValues<double> revenue = new ChartValues<double>();
        List<string> dates = new List<string>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            //try
            //{
                string commandString = $"SELECT * FROM [{listBoxTables.SelectedItem.ToString()}]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(commandString, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridViewShow.DataSource = table;
                if (listBoxTables.SelectedItem.ToString() == "Расчеты")
                {
                    for (int i = 0; i < dataGridViewShow.Rows.Count - 1; i++)
                    {
                        revenue.Add(double.Parse(dataGridViewShow.Rows[i].Cells["Стоимость работ"].Value.ToString()));
                    }
                    cartesianChartSales.Series = new SeriesCollection
                    {
                        new LineSeries
                            {
                                Title = "Продажи",
                                Values = revenue
                            }
                    };
                    for (int i = 0; i < dataGridViewShow.Rows.Count - 1; i++)
                    {
                        dates.Add(dataGridViewShow.Rows[i].Cells["Дата оказания"].Value.ToString());
                    }
                    cartesianChartSales.AxisX.Add(new Axis
                    {
                        Title = "Дата",
                        Labels = dates
                    });

                    cartesianChartSales.AxisY.Add(new Axis
                    {
                        Title = "Sales",
                        LabelFormatter = value => value.ToString("C")
                    });
                    cartesianChartSales.Visible = true;
                }    
            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                StaticData.DataBuffer = listBoxTables.SelectedItem.ToString();
                FormEditor form = new FormEditor();
                form.ShowDialog(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
