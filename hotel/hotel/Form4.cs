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
using System.Configuration;

namespace hotel
{
    public partial class Form4 : Form
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable adminTable;
        Form9 admin = new Form9();
        public Form4()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•'; 
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string login = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();

            string sql = $"SELECT * FROM admin WHERE login = '{login}' and password = '{password}'";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            adminTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(adminTable);

            if (adminTable.Rows.Count > 0)
            {
                this.Hide();
                admin.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }

            conn.Close();
        }
    }
    }

