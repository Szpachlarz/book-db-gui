﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projekt
{
    public partial class paneladmina : Form
    {
        logowanie wyjdz;
        dodajksiazke dodajK;
        dodajautora dodajA;
        dodajwydawnictwo dodajW;
        dodajkategorie dodajKa;
        Form10 edytujK;
        Form11 edytujA;
        Form12 edytujW;
        Form13 edytujKa;
        Form14 usunK;
        Form15 usunA;
        Form16 usunW;
        Form17 usunKa;
        //panel administratora
        
        public paneladmina()
        {
            InitializeComponent();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            //powrót do panelu logowania po zamknięciu
            logowanie logForm = new logowanie();
            logForm.Show();
        }

        //wypełnienie tabeli danymi z bazy danych przy załadowaniu formularza
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            dodajK = new dodajksiazke();
            dodajK.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            dodajK.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            edytujK = new Form10();
            edytujK.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            edytujK.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wyjdz = new logowanie();
            wyjdz.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            wyjdz.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dodajA = new dodajautora();
            dodajA.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            dodajA.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dodajW = new dodajwydawnictwo();
            dodajW.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            dodajW.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dodajKa = new dodajkategorie();
            dodajKa.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            dodajKa.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            edytujA = new Form11();
            edytujA.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            edytujA.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            edytujW = new Form12();
            edytujW.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            edytujW.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            edytujKa = new Form13();
            edytujKa.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            edytujKa.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usunK = new Form14();
            usunK.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            usunK.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            usunA = new Form15();
            usunA.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            usunA.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            usunW = new Form16();
            usunW.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            usunW.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            usunKa = new Form17();
            usunKa.FormClosing += new FormClosingEventHandler(this.Form4_FormClosing);
            this.Hide();
            usunKa.ShowDialog();
        }
    }
}
