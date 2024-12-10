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
    public partial class Form8 : Form
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable заявкиTable;
        public Form8()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string имя = textBox1.Text.ToString();
            string номер = textBox2.Text.ToString();
            string тип = textBox3.Text.ToString();
            DateTime date = dateTimePicker1.Value;
            string sql = $"INSERT INTO заявки(имя, номер, тип, date) VALUES ('{имя}', '{номер}', '{тип}', '{date}')";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            заявкиTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(заявкиTable);
            conn.Close();
            MessageBox.Show("Успешная запись", "Заголовок сообщения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
