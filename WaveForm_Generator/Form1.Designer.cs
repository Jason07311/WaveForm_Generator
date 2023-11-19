namespace WaveForm_Generator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Button button5;
            formsPlot1 = new ScottPlot.FormsPlot();
            panel2 = new Panel();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel4 = new Panel();
            button4 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            checkedListBox1 = new CheckedListBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel3 = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            button5 = new Button();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = Color.WhiteSmoke;
            button5.Location = new Point(15, 145);
            button5.Margin = new Padding(15);
            button5.Name = "button5";
            button5.Size = new Size(262, 35);
            button5.TabIndex = 10;
            button5.Text = "Select Data Input";
            button5.UseVisualStyleBackColor = false;
            button5.Click += selectDataInput_Click;
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.BackColor = Color.Transparent;
            formsPlot1.Location = new Point(323, 29);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(740, 494);
            formsPlot1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(15, 80);
            panel2.Margin = new Padding(15);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 35);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(49, 30);
            label2.TabIndex = 6;
            label2.Text = "File:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(58, 4);
            label3.MaximumSize = new Size(500, 0);
            label3.Name = "label3";
            label3.Size = new Size(109, 30);
            label3.TabIndex = 7;
            label3.Text = "file name..";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.BackColor = Color.Red;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(9, 8);
            button2.Margin = new Padding(30, 100, 30, 30);
            button2.Name = "button2";
            button2.Size = new Size(292, 41);
            button2.TabIndex = 5;
            button2.Text = "Generate Wave";
            button2.UseVisualStyleBackColor = false;
            button2.Click += generateWaveBtn_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.BackColor = Color.White;
            comboBox1.ForeColor = Color.Black;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Function 1", "Function 2", "Real-Time Reading Demo" });
            comboBox1.Location = new Point(119, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(161, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(98, 30);
            label1.TabIndex = 4;
            label1.Text = "Function:";
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.MidnightBlue;
            button1.FlatAppearance.BorderColor = Color.Red;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(15, 15);
            button1.Margin = new Padding(15);
            button1.Name = "button1";
            button1.Size = new Size(262, 35);
            button1.TabIndex = 2;
            button1.Text = "Add New Tab";
            button1.UseVisualStyleBackColor = false;
            button1.Click += addTab_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 50);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1088, 571);
            tabControl1.TabIndex = 2;
            tabControl1.MouseClick += closeTab_Click;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(0, 0, 64);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(formsPlot1);
            tabPage1.ForeColor = Color.Transparent;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1080, 543);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "WaveGen 1";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel4.Controls.Add(button4);
            panel4.Controls.Add(button3);
            panel4.Controls.Add(button2);
            panel4.Location = new Point(6, 354);
            panel4.Name = "panel4";
            panel4.Size = new Size(310, 169);
            panel4.TabIndex = 6;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.BackColor = Color.Navy;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(9, 125);
            button4.Name = "button4";
            button4.Size = new Size(292, 41);
            button4.TabIndex = 8;
            button4.Text = "Save";
            button4.UseVisualStyleBackColor = false;
            button4.Click += save_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.BackColor = Color.Navy;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(9, 66);
            button3.Name = "button3";
            button3.Size = new Size(292, 41);
            button3.TabIndex = 7;
            button3.Text = "Stop";
            button3.UseVisualStyleBackColor = false;
            button3.Click += stopWaveGen_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(checkedListBox1);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(310, 342);
            panel1.TabIndex = 3;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.White;
            checkedListBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkedListBox1.ForeColor = Color.Black;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "DC", "Sine", "Cosine", "Square", "Triangle", "Normal Plot" });
            checkedListBox1.Location = new Point(24, 272);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(265, 70);
            checkedListBox1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel3, 0, 3);
            tableLayoutPanel2.Controls.Add(panel2, 0, 1);
            tableLayoutPanel2.Controls.Add(button5, 0, 2);
            tableLayoutPanel2.Controls.Add(button1, 0, 0);
            tableLayoutPanel2.Location = new Point(9, 9);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(292, 260);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(comboBox1);
            panel3.Location = new Point(0, 195);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15);
            panel3.Size = new Size(292, 58);
            panel3.TabIndex = 6;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(16, 9);
            label4.Name = "label4";
            label4.Size = new Size(302, 27);
            label4.TabIndex = 3;
            label4.Text = "WaveForm Generator v1.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1112, 661);
            Controls.Add(label4);
            Controls.Add(tabControl1);
            ForeColor = Color.Transparent;
            Name = "Form1";
            Text = "WaveForm Generator v1.0";
            Shown += Form1_Shown;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label1;
        private ComboBox comboBox1;
        private Button button2;
        private Label label3;
        private Label label2;
        private Button button5;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel4;
        private System.Windows.Forms.Timer timer1;
        private Button button3;
        private Button button4;
        private CheckedListBox checkedListBox1;
        private Label label4;
    }
}