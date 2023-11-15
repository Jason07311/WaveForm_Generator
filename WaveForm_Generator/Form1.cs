using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WaveForm_Generator
{
    public partial class Form1 : Form
    {

        string selectedInputFile = "Select a file";

        public Form1()
        {
            InitializeComponent();
            label3.Text = selectedInputFile;
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = "TabPage " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            Data_Input dataInput = new Data_Input();
            dataInput.ShowDialog();
            string path = dataInput.SendData().Split('\\').Last();
            selectedInputFile = path;
            label3.Text = selectedInputFile;
        }


    }
}