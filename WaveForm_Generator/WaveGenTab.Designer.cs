namespace WaveForm_Generator
{
    partial class WaveGenTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Button button2;
            timer2 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            checkedListBox1 = new CheckedListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            label4 = new Label();
            comboBox2 = new ComboBox();
            panel5 = new Panel();
            label5 = new Label();
            label6 = new Label();
            button3 = new Button();
            panel2 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button1 = new Button();
            formsPlot1 = new ScottPlot.FormsPlot();
            button2 = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Purple;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(15, 145);
            button2.Margin = new Padding(15);
            button2.Name = "button2";
            button2.Size = new Size(262, 35);
            button2.TabIndex = 10;
            button2.Text = "Select Data Input";
            button2.UseVisualStyleBackColor = false;
            button2.Click += selectDataInput_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkedListBox1);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(310, 342);
            panel1.TabIndex = 9;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.MediumVioletRed;
            checkedListBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkedListBox1.ForeColor = Color.White;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "DC", "Sine", "Cosine", "Square", "Triangle", "Normal Plot" });
            checkedListBox1.Location = new Point(24, 272);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(265, 70);
            checkedListBox1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 3);
            tableLayoutPanel1.Controls.Add(panel5, 0, 1);
            tableLayoutPanel1.Controls.Add(button2, 0, 2);
            tableLayoutPanel1.Controls.Add(button3, 0, 0);
            tableLayoutPanel1.Location = new Point(9, 9);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(292, 260);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Controls.Add(comboBox2);
            panel4.Location = new Point(0, 195);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(15);
            panel4.Size = new Size(292, 58);
            panel4.TabIndex = 6;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(15, 15);
            label4.Name = "label4";
            label4.Size = new Size(98, 30);
            label4.TabIndex = 4;
            label4.Text = "Function:";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.BackColor = Color.MediumVioletRed;
            comboBox2.ForeColor = Color.White;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Function 1", "Function 2", "Real-Time Reading Demo" });
            comboBox2.Location = new Point(119, 21);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(161, 23);
            comboBox2.TabIndex = 2;
            comboBox2.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // panel5
            // 
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(15, 80);
            panel5.Margin = new Padding(15);
            panel5.Name = "panel5";
            panel5.Size = new Size(262, 35);
            panel5.TabIndex = 2;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 4);
            label5.Name = "label5";
            label5.Size = new Size(49, 30);
            label5.TabIndex = 6;
            label5.Text = "File:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Maroon;
            label6.Location = new Point(58, 4);
            label6.MaximumSize = new Size(500, 0);
            label6.Name = "label6";
            label6.Size = new Size(109, 30);
            label6.TabIndex = 7;
            label6.Text = "file name..";
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.BackColor = Color.Purple;
            button3.FlatAppearance.BorderColor = Color.Red;
            button3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(15, 15);
            button3.Margin = new Padding(15);
            button3.Name = "button3";
            button3.Size = new Size(262, 35);
            button3.TabIndex = 2;
            button3.Text = "Add New Tab";
            button3.UseVisualStyleBackColor = false;
            button3.Click += addTab_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(6, 354);
            panel2.Name = "panel2";
            panel2.Size = new Size(310, 169);
            panel2.TabIndex = 10;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button5.BackColor = Color.DarkMagenta;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(9, 125);
            button5.Name = "button5";
            button5.Size = new Size(292, 41);
            button5.TabIndex = 9;
            button5.Text = "Save";
            button5.UseVisualStyleBackColor = false;
            button5.Click += save_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.BackColor = Color.DarkMagenta;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(9, 66);
            button4.Name = "button4";
            button4.Size = new Size(292, 41);
            button4.TabIndex = 8;
            button4.Text = "Stop";
            button4.UseVisualStyleBackColor = false;
            button4.Click += stopWaveGen_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.DarkMagenta;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(9, 8);
            button1.Margin = new Padding(30, 100, 30, 30);
            button1.Name = "button1";
            button1.Size = new Size(292, 41);
            button1.TabIndex = 6;
            button1.Text = "Generate Wave";
            button1.UseVisualStyleBackColor = false;
            button1.Click += generateWaveBtn_Click;
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.BackColor = Color.Magenta;
            formsPlot1.Location = new Point(323, 29);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(740, 494);
            formsPlot1.TabIndex = 11;
            // 
            // WaveGenTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            Controls.Add(formsPlot1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlLightLight;
            Name = "WaveGenTab";
            Size = new Size(1080, 543);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer2;
        private Panel panel1;
        private CheckedListBox checkedListBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Label label4;
        private ComboBox comboBox2;
        private Panel panel5;
        private Label label5;
        private Label label6;
        private Button button3;
        private Panel panel2;
        private Button button1;
        private Button button4;
        private Button button5;
        private ScottPlot.FormsPlot formsPlot1;
    }
}
