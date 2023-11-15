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
        string selectedFunction = "Select Function";

        public Form1()
        {
            InitializeComponent();
            label3.Text = selectedInputFile;
            comboBox1.Text = selectedFunction;
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            double[] dataX = new double[] { 1, 2, 3, 4, 5 };
            double[] dataY = new double[] { 1, 4, 9, 16, 25 };

            formsPlot1.Plot.AddScatter(dataX, dataY);
            formsPlot1.Refresh();

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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void tab_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void generateWaveBtn_Click(object sender, EventArgs e)
        {
            if (selectedFunction == "Function 1")
            {

            }
            else if (selectedFunction == "Function 2")
            {

            }
            else if (selectedFunction == "Sine")
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => selectedFunction = comboBox1.SelectedItem.ToString();


    }
}