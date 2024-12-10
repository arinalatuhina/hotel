using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        public Form7(string kategori, string sum, string zaezd, string viezd, string usluga)
        {
            InitializeComponent();
            label1.Text = "Ваш номер: " + kategori;
            label2.Text = "Сумма к оплате: " + sum;
            label3.Text = "Дата заезда: " + zaezd;
            label4.Text = "Дата выезда: " + viezd;
            label5.Text = "Дополнительная услуга: " + usluga;
        }
    }
}
