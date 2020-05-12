using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MICS
{
    public partial class frmModal : Form
    {
        public frmModal()
        {
            InitializeComponent();
            
        }

        private void frmModal_Load(object sender, EventArgs e)
        {

            
            
        }

        private void frmModal_Activated(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            this.Close();
        }
    }
}