﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            form.ShowDialog();
        }
    }
}
