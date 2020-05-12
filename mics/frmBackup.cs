using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.ServiceProcess;

namespace MICS
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            

        }

        private void btnStartBackup_Click(object sender, EventArgs e)
        {
            ServiceController controller = new ServiceController();
            string status = "";
            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = 100;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                controller.MachineName = ".";
                controller.ServiceName = System.Configuration.ConfigurationManager.AppSettings["SqlServerServiceName"]; ;
                status = controller.Status.ToString();
                // Stop the service
                if (status == "Running")
                {
                    StatusLabel1.Text = "Stopping SQL SERVER SERVICE";
                    ProgressBar1.Value = 30;
                    statusStrip1.Refresh();
                    controller.Stop();
                }
                DateTime t = DateTime.Now;
                //waite 3 seconds
                DateTime t2 = t.AddSeconds(3);
                while (DateTime.Now < t2)
                {
                    continue;
                }
                StatusLabel1.Text = "Copying files";
                statusStrip1.Refresh();
                BackupDatabaseFiles();
                ProgressBar1.Value = 70;
                // statusStrip1.Text = controller.ServiceName = " Stopped";
                // Start the service
                controller.Start();
                ProgressBar1.Value = 100;
                StatusLabel1.Text = controller.ServiceName + " Started Successfully";
                StatusLabel1.Text = "Backup Successfull";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MICS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StatusLabel1.Text = "Backup Failed";
            }
            finally
            {
               Cursor.Current = Cursors.Default;
            }
        }
        private void BackupDatabaseFiles()
        {
            string DatabaseDir = System.Configuration.ConfigurationManager.AppSettings["DBFolder"];
            string destPath = txtFileName.Text;

            DirectoryInfo dir = new DirectoryInfo(DatabaseDir);
            //DirectoryInfo dir = DirectoryInfo DirectoryInfo(DatabaseDir);

            FileInfo[] files = dir.GetFiles("mics_server*");
           
            foreach (FileInfo file in files)
            {
                file.CopyTo(destPath + "\\" + file.Name,true);
            }
        }

        private void OpenFolderDialog()
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            // Set theFolderBrowser object's Description property to give the user instructions.
            fld.Description = "Please select a folder for the backup.";

            //Set theFolderBrowser object's ShowNewFolder property to false when the a FolderBrowserDialog is to be used only for selecting an existing folder.
            fld.ShowNewFolderButton = true;

            /* Optionally set the RootFolder and SelectedPath properties to

            '   control which folder will be selected when browsing begings

            '   and to make it the selected folder.

            ' For this example start browsing in the Desktop folder. */

            fld.RootFolder = System.Environment.SpecialFolder.Desktop;

            // Default theFolderBrowserDialog object's SelectedPath property to the path to the Desktop folder.

           //fld.SelectedPath =   My.Computer.FileSystem.SpecialDirectories.Desktop

     
            //if the user clicks theFolderBrowser's OK button..

            if(fld.ShowDialog() == DialogResult.OK)
            {
                //Set the FolderChoiceTextBox's Text to theFolderBrowserDialog's SelectedPath property.
                txtFileName.Text = fld.SelectedPath;
            }


        }
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFolderDialog();
            //Stream myStream;
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //saveFileDialog1.FilterIndex = 2;
            //saveFileDialog1.RestoreDirectory = true;

            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    if ((myStream = saveFileDialog1.OpenFile()) != null)
            //    {
            //        // Code to write the stream goes here.
            //        myStream.Close();
            //    }
            //}
        }
    }
}