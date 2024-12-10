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

namespace hotel
{
    public partial class Form3 : Form
    {
        private string connectionString = "Server=SQL9001.site4now.net;Database=db_aafe1c_sokolovskaa;User Id=db_aafe1c_sokolovskaa_admin;Password=04i2005G;";
        public Form3()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 previousForm = new Form1();
            Form currentForm = this;
            currentForm.Hide();
            previousForm.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM сотрудники"; 
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

