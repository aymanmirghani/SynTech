using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MICS.BLL;
namespace MICS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Address add = new Address();
            add.AddressLine1 = "3255 Sexton Drive";
            add.AddressLine2 = "";
            add.City = "Green Cove Springs";
            add.StateProvince = "FL";
            add.PostalCode = "32043";
            add.AddAddress(add);
            


        }
       
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowData();

        }

        private void ShowData()
        {
            DataSet ds = new DataSet();
            Address address = new Address();
            //address.AddressID = 1;
            ds = address.GetAllAddresssDataSet();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Address address = new Address();
            Address add = new Address();
            add = address.GetAddresss(2);
            
            
            add.AddressLine1 = "7901 Baymeadows Cir";
            address.UpdateAddress(add);
            ShowData();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Address address = new Address();
            address.RemoveAddress(1);
            ShowData();
        }
    }
}