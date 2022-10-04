using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            button2.Text = Resource1.Export_to_file;
            button3.Text = Resource1.Delete;
        }

        BindingList<User> users = new BindingList<User>();

        private void button1_Click(object sender, EventArgs e)
        {
            User u = new User();            
            u.FullName = textBox1.Text;
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);
                foreach ( var u in users)
                {
                    sw.WriteLine($"{u.FullName};{u.ID}");
                }
                sw.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var torlendo = (Guid)listBox1.SelectedValue;
            var eredmeny = from x in users
                           where x.ID == torlendo
                           select x;
            users.Remove(eredmeny.FirstOrDefault());
            
        }
    }
}
