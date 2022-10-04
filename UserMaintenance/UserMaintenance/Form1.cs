﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            
            button1.Text = Resource1.Add;

            listBox1.DataSource = users;
            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "ID";
        }

        BindingList<User> users = new BindingList<User>();

        private void button1_Click(object sender, EventArgs e)
        {
            User u = new User();            
            u.FullName = textBox1.Text;
            users.Add(u);
        }
    }
}
