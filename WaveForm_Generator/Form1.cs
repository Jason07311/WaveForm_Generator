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
        private bool isAnimationRunning = false;

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

        private void plotRealTimeReadingDemo()
        {
            timer1.Start();
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

                // Plot the initial data
                plt.AddScatter(time, voltage, label: "Function 2 Data");

                // Customize the axis labels
                plt.Title("Function 2 Graph");
                plt.XLabel("Time");
                plt.YLabel("Voltage");

                // Set the axis limits based on the initial data
                plt.AxisAuto();
                double initialXMax = plt.GetAxisLimits().XMax;

                // Refresh the plot
                formsPlot1.Render();

                // Define the continuous update function
                Action updateFunction = () =>
                {
                    double xIncrement = 0.1; // x-increment size

                    while (isAnimationRunning)
                    {
                        // Increment x values
                        time = time.Select(t => t + xIncrement).ToArray();

                        // Calculate corresponding y values using sine function
                        voltage = time.Select(t => Math.Sin(t)).ToArray();

                        // Plot the updated data
                        Invoke((MethodInvoker)delegate //Updates UI from a background thread
                        {
                            plt.Clear();
                            plt.AddScatter(time, voltage, label: "Function 2 Data");
                            plt.AxisAuto();
                            formsPlot1.Render();
                        });

                        // Pause for a short duration 
                        System.Threading.Thread.Sleep(100);
                    }
                };


                // Run the continuous update function in a background thread
                isAnimationRunning = true;
                Task.Run(updateFunction);
            }
            else
            {
                MessageBox.Show("Selected CSV file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stopAnimation()
        {
            isAnimationRunning = false;
        }


        private void plotSine()
        {

        }

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


        // Generate random data to replace device reading
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedInputFile = openFileDialog.FileName;
                    label3.Text = selectedInputFile;
                }
            }
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
                timer1.Start();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFunction = comboBox1.SelectedItem.ToString();
            chgFunc = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            timer1.Stop();

            // Stop the continuous update function
            stopAnimation();

            // Optionally, reset the data arrays if needed
            dataX = new double[0];
            dataY = new double[0];
        }
    }
}