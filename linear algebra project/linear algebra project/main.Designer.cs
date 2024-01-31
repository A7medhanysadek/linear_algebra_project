namespace linear_algebra_project
{
    partial class main
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
            label2 = new Label();
            label3 = new Label();
            btn_op1 = new Button();
            btn_op2 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(189, 9);
            label1.Name = "label1";
            label1.Size = new Size(403, 40);
            label1.TabIndex = 0;
            label1.Text = "Linear System solver";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 305);
            label2.Name = "label2";
            label2.Size = new Size(203, 20);
            label2.TabIndex = 1;
            label2.Text = "Write your equations to solve";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(502, 305);
            label3.Name = "label3";
            label3.Size = new Size(178, 20);
            label3.TabIndex = 2;
            label3.Text = "Enter your matrix to solve";
            // 
            // btn_op1
            // 
            btn_op1.Location = new Point(72, 356);
            btn_op1.Name = "btn_op1";
            btn_op1.Size = new Size(203, 82);
            btn_op1.TabIndex = 3;
            btn_op1.Text = "Option1";
            btn_op1.UseVisualStyleBackColor = true;
            btn_op1.Click += btn_op1_Click;
            // 
            // btn_op2
            // 
            btn_op2.Location = new Point(502, 356);
            btn_op2.Name = "btn_op2";
            btn_op2.Size = new Size(178, 82);
            btn_op2.TabIndex = 4;
            btn_op2.Text = "Option2";
            btn_op2.UseVisualStyleBackColor = true;
            btn_op2.Click += btn_op2_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(299, 152);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(178, 24);
            radioButton1.TabIndex = 5;
            radioButton1.Text = "Solve by Gauss-Jordan";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged_1;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(299, 205);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(182, 24);
            radioButton2.TabIndex = 6;
            radioButton2.Text = "Solve by matrix inverse";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged_1;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Location = new Point(-500, 0);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(117, 24);
            radioButton3.TabIndex = 7;
            radioButton3.TabStop = true;
            radioButton3.Text = "radioButton3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 98);
            label4.Name = "label4";
            label4.Size = new Size(591, 20);
            label4.TabIndex = 8;
            label4.Text = "Could you please choose the solve method then the way the program receive cofactors :";
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(btn_op2);
            Controls.Add(btn_op1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "main";
            Text = "main";
            FormClosing += closing;
            Load += main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_op1;
        private Button btn_op2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Label label4;
    }
}