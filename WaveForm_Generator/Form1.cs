using ScottPlot;
using ScottPlot.Plottable;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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

        // Current Funciton on Plot
        bool chgFunc = false;

        // x-label, y-label
        string xLabel = "";
        string yLabel = "";

        public Form1()
        {
            InitializeComponent();
            label3.Text = selectedInputFile;
            comboBox1.Text = selectedFunction;
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            formsPlot1.Plot.Style(Style.Blue2);

        }


        // GUI 

        private void addTab_Click(object sender, EventArgs e)
        {
            string title = "WaveGen " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFunction = comboBox1.SelectedItem.ToString();
            chgFunc = true;
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
            formsPlot1.Plot.Clear();
            timer1.Stop();


            if (comboBox1.Text.ToString() == "Function 1")
            {
                plotFunc1();
            }
            else if (comboBox1.Text.ToString() == "Function 2")
            {
                plotFunc2();
            }
            else if (comboBox1.Text.ToString() == "Sine")
            {
                plotSine();
            }
            else if (comboBox1.Text.ToString() == "Real-Time Reading Demo")
            {
                plotRealTimeReadingDemo();
            }
            else
            {
                MessageBox.Show("Function not Selected!");
            }
        }

        private void stopWaveGen_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            timer1.Stop();
        }


        // Main Features of the Waveform_Generator


        // Functions to plot graphs

        private void plotFunc1()
        {
            var plt = formsPlot1.Plot;
            
            try
            {
                var datas = ReadCsvCurrent(selectedInputFile);
                

                // Plot Graph
                plt.AddScatter(datas[0].ToArray(), datas[1].ToArray());
                

                // Customize the axis labels
                plt.Title(yLabel + " against " + xLabel);
                plt.XLabel(xLabel);
                plt.YLabel(yLabel);

                formsPlot1.Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void plotFunc2()
        {
            if (File.Exists(selectedInputFile))
            {
                var plt = formsPlot1.Plot;

                // Read data from the CSV file
                var csvData = ReadCsvVoltage(selectedInputFile);


                // Extract time and voltage data
                double[] time = csvData.Select(row => row[0]).ToArray();
                double[] voltage = csvData.Select(row => row[1]).ToArray();


                // Plot the data
                plt.AddScatter(time, voltage, label: "Function 2 Data");

                // Customize the axis labels
                plt.Title("Function 2 Graph");
                plt.XLabel("Time");
                plt.YLabel("Voltage");

                // Refresh the plot
                formsPlot1.Render();
            }
            else
            {
                MessageBox.Show("Selected CSV file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void plotSine()
        {
            var plt = formsPlot1.Plot;

            // sample data
            double[] xs = DataGen.Consecutive(51);
            double[] sin = DataGen.Sin(51);
            // double[] cos = DataGen.Cos(51);

            // plot the data
            plt.AddScatter(xs, sin);
            // plt.AddScatter(xs, cos);

            // customize the axis labels
            plt.Title("ScottPlot Quickstart");
            plt.XLabel("Horizontal Axis");
            plt.YLabel("Vertical Axis");

            // Save the Plotted Graph
            // MessageBox.Show("Saved in: " + plt.SaveFig("quickstart_scatter.png"));

            formsPlot1.Refresh();
        }

        private void plotRealTimeReadingDemo()
        {
            timer1.Start();
        }


        // Read CSV files

        private List<double[]> ReadCsvVoltage(string filePath)
        {
            var data = new List<double[]>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        // Skip empty lines
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        // Attempt to parse values
                        try
                        {
                            var values = line.Split(',').Select(double.Parse).ToArray();
                            data.Add(values);
                        }
                        catch (FormatException)
                        {
                            // Log or ignore lines that cannot be parsed
                            Console.WriteLine($"Skipping line: {line}. Unable to parse values.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return data;
        }

        private List<List<double>> ReadCsvCurrent(string filePath)
        {
            List<List<double>> datas = new List<List<double>>();

            List<double> xData = new List<double>();

            List<double> yData = new List<double>();

            try
            {
                if (File.Exists(selectedInputFile))
                {

                    using (StreamReader rd = new StreamReader(selectedInputFile))
                    {
                        string firstLine = rd.ReadLine();

                        xLabel = firstLine.Split(",")[0];
                        yLabel = firstLine.Split(",")[1];

                        string line = "";

                        while ((line = rd.ReadLine()) != null)
                        {
                            var arr = line.Split(",");
                            xData.Add(Double.Parse(arr[0]));
                            yData.Add(Double.Parse(arr[1]));
                        }

                    }

                    datas.Add(xData);
                    datas.Add(yData);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            return datas;
        }



        // Generate random data to replace device reading

        private double genRandNum()
        {
            Random rand = new Random();
            double sensorValue = rand.NextDouble() * 10; //Random Value between 20 and 30
            return sensorValue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateChart();
        }

        // Update chart for each time it is called
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



        // Select and upload CSV file to system, local directory

        private void selectDataInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string path = Application.StartupPath + @"~\graphData";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                openFileDialog.InitialDirectory = path;
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                    path = path + "\\" + fileName;
                    if (!File.Exists(path))
                    {
                        try
                        {
                            File.Copy(openFileDialog.FileName, path);
                            MessageBox.Show("Selected file uploaded to system local directory: " + fileName);
                        }
                        catch (Exception ex)
                        {
                            /*MessageBox.Show("File exist!");*/
                        }

                    }

                    selectedInputFile = openFileDialog.FileName;
                    label3.Text = fileName;
                }


            }

        }


    }
}