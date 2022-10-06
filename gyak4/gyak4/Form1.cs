﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace gyak4
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();

        List<Flat> flats;

        Excel.Application xlApp;
        Excel.Workbook xlWb;
        Excel.Worksheet xlSheet;

             

        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        private void LoadData()
        {
            flats = context.Flats.ToList();
        }
        
        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();

                xlWb = xlApp.Workbooks.Add(Missing.Value);

                xlSheet = xlWb.ActiveSheet;

                //CreateTable()

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {

                string errMsg= string.Format("Error: {0}\nLine: {1}", ex.Message,ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWb.Close();
                xlApp.Quit();
                xlWb = null;
                xlApp = null;
            }
        }

        
        

    }
}
