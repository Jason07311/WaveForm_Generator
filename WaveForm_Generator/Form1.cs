using ScottPlot;
using ScottPlot.Plottable;
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

        // For real-time data
        double[] dataX = new double[0];
        double[] dataY = new double[0];
        int k = 0;

        // Current Plot
        bool chgFunc = false;

        public Form1()
        {
            InitializeComponent();
            label3.Text = selectedInputFile;
            comboBox1.Text = selectedFunction;
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void plotFunc1()
        {
            var plt = formsPlot1.Plot;

            // sample data
            double[] xs = DataGen.Consecutive(51);
            double[] sin = DataGen.Sin(51);
            double[] cos = DataGen.Cos(51);

            // plot the data
            plt.AddScatter(xs, sin);
            plt.AddScatter(xs, cos);

            // customize the axis labels
            plt.Title("ScottPlot Quickstart");
            plt.XLabel("Horizontal Axis");
            plt.YLabel("Vertical Axis");

            // Save the Plotted Graph
            // MessageBox.Show("Saved in: " + plt.SaveFig("quickstart_scatter.png"));

            formsPlot1.Refresh();
        }

        private void plotFunc2()
        {

        }

        private void plotSine()
        {

        }

        private double genRandNum()
        {
            Random rand = new Random();
            double sensorValue = rand.NextDouble() * 10 + 20; //Random Value between 20 and 30
            return sensorValue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void UpdateChart()
        {
            k++;
            double newValue = genRandNum();
            dataX = dataX.Append(k).ToArray();
            dataY = dataY.Append(newValue).ToArray();
            formsPlot1.Plot.AddScatter(dataX, dataY, color: Color.Orange);
            formsPlot1.Plot.AxisAuto();
            formsPlot1.Render();
        }

        private void addTab_Click(object sender, EventArgs e)
        {
            string title = "TabPage " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
        }

        private void selectDataInput_Click(object sender, EventArgs e)
        {
            Data_Input dataInput = new Data_Input();
            dataInput.ShowDialog();
            string path = dataInput.SendData().Split('\\').Last();
            selectedInputFile = path;
            label3.Text = selectedInputFile;
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
            Console.WriteLine(comboBox1.Text.ToString());
            formsPlot1.Plot.Clear();
            timer1.Stop();
            if (comboBox1.Text.ToString() == "Function 1")
            {
                plotFunc1();
            }
            else if (comboBox1.Text.ToString() == "Function 2")
            {

            }
            else if (comboBox1.Text.ToString() == "Sine")
            {
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Function not Selected !");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFunction = comboBox1.SelectedItem.ToString();
            chgFunc = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            timer1.Stop();
        }
    }
}