using ScottPlot;
using ScottPlot.Plottable;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Xml.Linq;

namespace WaveForm_Generator
{
    public partial class Form1 : Form
    {

        string selectedInputFile = "Select a file";
        string selectedFunction = "Select Function";
        private bool isAnimationRunning = false;

        // For real-time data
        List<double> dataX = new List<double>();
        List<double> dataY = new List<double>();
        List<List<double>> multiDataY = new List<List<double>>();
        int k = 0;



        // x-label, y-label
        string xLabel = "";
        string yLabel = "";

        public Form1()
        {
            InitializeComponent();
            label3.Text = selectedInputFile;
            comboBox1.Text = selectedFunction;
            formsPlot1.Plot.Style(Style.Blue1);
            checkedListBox1.Visible = false;
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            //formsPlot1.Plot.Style(Style.Blue1);
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
            if (selectedFunction == "Function 1")
            {
                checkedListBox1.Visible = true;
            }
            else
            {
                checkedListBox1.Visible = false;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
            }

        }

        private void closeTab_Click(object sender, MouseEventArgs e)
        {
            var tabs = tabControl1.TabPages;

            if (e.Button == MouseButtons.Middle && tabControl1.TabCount > 1)
            {
                tabControl1.TabPages.Remove(tabs.Cast<TabPage>()
                    .Where((t, i) => tabControl1.GetTabRect(i).Contains(e.Location))
                    .First());
            }
        }

        private void generateWaveBtn_Click(object sender, EventArgs e)
        {
            // Clear the plot and stop timer if any is running when start generate wave
            formsPlot1.Plot.Clear();
            timer1.Stop();

            // Redefine all global variable when start generate wave
            dataX = new List<double>();
            dataY = new List<double>();
            multiDataY = new List<List<double>>();
            xLabel = "";
            yLabel = "";

            if (comboBox1.Text.ToString() == "Function 1")
            {
                plotFunc1();
            }
            else if (comboBox1.Text.ToString() == "Function 2")
            {
                plotFunc2();
            }
            else if (comboBox1.Text.ToString() == "Real-Time Reading Demo")
            {
                plotRealTimeReadingDemo();
            }
            else
            {
                MessageBox.Show("Function not Selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stopWaveGen_Click(object sender, EventArgs e)
        {
            // formsPlot1.Plot.Clear();
            timer1.Stop();

            // Stop the continuous update function
            stopAnimation();
            
        }


        // Main Features of the Waveform_Generator


        // Functions to plot graphs

        private void plotFunc1()
        {
            var plt = formsPlot1.Plot;

            // Read file
            var datas = ReadCsvCurrent(selectedInputFile);

            try
            {
                // Check if any functions selected
                if (checkedListBox1.CheckedItems.Count <= 0)
                {
                    throw new Exception("Please select functions to be plotted!");
                }

                // For update y label to be written in file
                string temp = yLabel;
                yLabel = yLabel + "(" + checkedListBox1.CheckedItems[0].ToString() + ")";
                int index = 0;

                foreach (var function in checkedListBox1.CheckedItems)
                {
                    List<double> ydata = new List<double>();

                    switch (function.ToString())
                    {
                        case "DC":
                            // y = constant value
                            datas[0].ForEach(y => ydata.Add(6));
                            plt.AddScatter(datas[0].ToArray(), ydata.ToArray()).Label = "DC";
                            break;
                        case "Sine":
                            // y = A sin (wt), w = 2*PI*f, f = frequency
                            datas[0].ForEach(y => ydata.Add(4.0 * Math.Sin(2 * Math.PI * 1.0 * y)));
                            plt.AddScatter(datas[0].ToArray(), ydata.ToArray()).Label = "Sine";
                            break;
                        case "Cosine":
                            // y = A cos (wt)
                            datas[0].ForEach(y => ydata.Add(2.0 * Math.Cos(2 * Math.PI * 1.0 * y)));
                            plt.AddScatter(datas[0].ToArray(), ydata.ToArray()).Label = "Cosine";
                            break;
                        case "Square":
                            // y[k] = Math.Sin(freq * k)>=0?A:-1*A;
                            datas[0].ForEach(y => ydata.Add(Math.Sin(1.0 * y) >= 0 ? 3.0 : -1 * 3.0));
                            plt.AddScatter(datas[0].ToArray(), ydata.ToArray()).Label = "Square";
                            break;
                        case "Triangle":
                            // y = (A/P) * (P - abs(x % (2*P) - P) )  
                            datas[0].ForEach(y => ydata.Add((1 / 1) * (1 - Math.Abs(y % (2 * 1) - 1))));
                            plt.AddScatter(datas[0].ToArray(), ydata.ToArray()).Label = "Triangle";
                            break;
                        case "Normal Plot":
                            // y taken from original data input file y-data points
                            datas[1].ForEach(y => ydata.Add(y));
                            plt.AddScatter(datas[0].ToArray(), datas[1].ToArray()).Label = "Normal Plot";
                            break;
                    }

                    // Keep track of y datas for each function
                    multiDataY.Add(ydata);

                    // Update on y label by adding function name                    
                    if (index <= 0)
                    {
                        index++;
                    }
                    else
                    {
                        yLabel = yLabel + "," + temp + "(" + function.ToString() + ")";
                    }



                }

                // Keep track of x datas for all function
                dataX.AddRange(datas[0]);


                // Customize the axis labels
                plt.Title(yLabel + " against " + xLabel);
                plt.XLabel(xLabel);
                plt.YLabel(yLabel);

                plt.Legend();

                formsPlot1.Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void plotRealTimeReadingDemo()
        {
            timer1.Start();
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
            xLabel = "X";
            yLabel = "Demo Real-Time Reading Y";

            k++;
            double newValue = genRandNum();
            dataX.Add(k);
            dataY.Add(newValue);
            formsPlot1.Plot.XLabel(xLabel);
            formsPlot1.Plot.YLabel(yLabel);
            formsPlot1.Plot.Title($"{yLabel} against {xLabel}");
            formsPlot1.Plot.AddScatter(dataX.ToArray(), dataY.ToArray(), color: Color.Orange);
            formsPlot1.Plot.AxisAuto();
            formsPlot1.Refresh();
        }


        // Read from and Write to CSV files

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
                else
                {
                    throw new Exception("File not exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datas;
        }

        private void WriteToCsv(string filepath)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                // Write the first line which is the Labels

                // If graph is a multiplotting graph...
                if (comboBox1.SelectedItem.ToString() == "Function 1")
                {
                    var yLabels = yLabel.Split(",");
                    string combineYLabels = "";

                    for (int i = 0; i < yLabels.Length; i++)
                    {
                        combineYLabels = combineYLabels + "," + yLabels[i].ToString();
                    }

                    sw.WriteLine($"{xLabel}{combineYLabels}");
                }
                else
                {
                    sw.WriteLine($"{xLabel},{yLabel}");
                }

                // Writing the rest of the data 
                for (int i = 0; i < dataX.Count; i++)
                {
                    // If graph is a multiplotting graph...
                    if (comboBox1.SelectedItem.ToString() == "Function 1")
                    {

                        string combineYDatas = "";

                        for (int j = 0; j < multiDataY.Count; j++)
                        {
                            combineYDatas = combineYDatas + "," + multiDataY[j][i].ToString("0.#########");
                        }

                        sw.WriteLine($"{dataX[i]}{combineYDatas}");
                    }
                    else
                    {
                        sw.WriteLine($"{dataX[i]},{dataY[i]}");
                    }
                }

                sw.Close();
            }

        }



        // Select input file and upload to local system folder
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
                            // MessageBox.Show("File exist!");
                        }

                    }

                    selectedInputFile = openFileDialog.FileName;
                    label3.Text = fileName;
                }


            }

        }

        private void save_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openFolderDialog = new FolderBrowserDialog())
            {
                string initialPath = "C:\\Users\\USER_NAME\\Downloads".Replace("USER_NAME", Environment.UserName);

                openFolderDialog.InitialDirectory = initialPath;

                if (openFolderDialog.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        // Name for file to be saved
                        string function = comboBox1.SelectedItem.ToString() == "Function 1" ? "MultiPlot " : "";

                        // Path for file
                        string saveImgPath = openFolderDialog.SelectedPath + "\\" + function + yLabel + " against " + xLabel + ".png";
                        string saveCsvPath = openFolderDialog.SelectedPath + "\\" + function + yLabel + " against " + xLabel + ".csv";

                        // Auto generate file name if repeated file name found
                        bool flag = true;
                        int index = 1;
                        do
                        {
                            if (!File.Exists(saveImgPath))
                            {
                                // Save Image file
                                formsPlot1.Plot.SaveFig(saveImgPath);

                                // Save CSV file
                                WriteToCsv(saveCsvPath);

                                flag = false;
                            }
                            else
                            {
                                // Increment of file version index, if same file name found
                                saveImgPath = openFolderDialog.SelectedPath + "\\" + function + yLabel + " against " + xLabel + "(" + index.ToString() + ")" + ".png";
                                saveCsvPath = openFolderDialog.SelectedPath + "\\" + function + yLabel + " against " + xLabel + "(" + index.ToString() + ")" + ".csv";

                                index++;
                            }
                        }
                        while (flag);

                        MessageBox.Show("File saved under " + openFolderDialog.SelectedPath + " .", "Saving Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File save failed!", "Saving status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


            }
        }
    }
}