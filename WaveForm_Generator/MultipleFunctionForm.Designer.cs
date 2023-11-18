namespace WaveForm_Generator
{
    partial class MultipleFunctionForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button2 = new Button();
            checkedListBox1 = new CheckedListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(231, 25);
            label1.TabIndex = 2;
            label1.Text = "Select Functions to Plot: ";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(365, 306);
            button2.Name = "button2";
            button2.Size = new Size(120, 35);
            button2.TabIndex = 5;
            button2.Text = "Confirm";
            button2.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "DC", "Sine", "Cosine", "Square", "Triangle" });
            checkedListBox1.Location = new Point(12, 76);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(473, 194);
            checkedListBox1.TabIndex = 6;
            // 
            // MultipleFunctionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 372);
            Controls.Add(checkedListBox1);
            Controls.Add(button2);
            Controls.Add(label1);
            Name = "MultipleFunctionForm";
            Text = "MultipleFunctionForm";
            Load += MultipleFunctionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button2;
        private CheckedListBox checkedListBox1;
    }
}