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
using System.Net;
using System.Net.Mail;

namespace hotel
{
    public partial class Form9 : Form
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable заявкиTable;
        public Form9()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SelectValues();
        }
        public void SelectValues()
        {
            string sqlzayavki = $"SELECT * FROM заявки";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            заявкиTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sqlzayavki;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(заявкиTable);
            dataGridView1.DataSource = заявкиTable.DefaultView;
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string sqlзаявки = $"DELETE FROM заявки WHERE id = {id}";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            заявкиTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sqlзаявки;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(заявкиTable);
            conn.Close();
            SelectValues();
            MessageBox.Show("Вы приняли заявку.");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string sqlzayavki = $"DELETE FROM заявки WHERE id = {id}";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            заявкиTable = new DataTable();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = sqlzayavki;
            adapter = new SqlDataAdapter(command);
            adapter.Fill(заявкиTable);
            conn.Close();
            SelectValues();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            string messageBody = textBox2.Text;
            string smtpAddress = "smtp.rambler.ru"; 
            int portNumber = 25; 
            bool enableSSL = true; 
            string emailFrom = "sokolovskaaarina21@rambler.ru"; 
            string password = "04i2005G!"; 
            string emailTo = "sokolovskaaarina22@rambler.ru"; 
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = "Статус заявки";
                mail.Body = messageBody;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;

                    try
                    {
                        await Task.Run(() => smtp.Send(mail));
                        labelStatus.Text = "успешно отправлено";
                    }
                    catch (Exception ex)
                    {
                        labelStatus.Text = $"Error: {ex.Message}";
                    }
                    button2.Enabled = false; 
                    try
                    {
                        await smtp.SendMailAsync(mail);
                        labelStatus.Text = "успешно отправлено";
                    }
                    catch (Exception ex)
                    {
                        labelStatus.Text = $"Error: {ex.Message}";
                    }
                    finally
                    {
                        button2.Enabled = true; 
                    }
                    
                        
                    }
            }
        }
    }
}
    
        

