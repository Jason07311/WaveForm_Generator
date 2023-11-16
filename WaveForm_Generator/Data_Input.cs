using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveForm_Generator
{
    public partial class Data_Input : Form
    {
        public Data_Input()
        {
            InitializeComponent();
        }

        public string SendData()
        {
            return label4.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string path = Application.StartupPath + @"~\graphData\";

            dialog.InitialDirectory = path;

            dialog.ShowDialog();

            var fileName = System.IO.Path.GetFileName(dialog.FileName);

            label3.Text = fileName;

            label4.Text = path + fileName;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.Combine(@"~\graphData");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var fileName = System.IO.Path.GetFileName(dialog.FileName);
                    label3.Text = fileName;

                    path = path + "\\" + fileName;

                    label4.Text = path;
                    if (!File.Exists(path))
                    {
                        File.Copy(dialog.FileName, path);
                    }
                    else
                    {
                        throw new Exception("File exists!");
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
