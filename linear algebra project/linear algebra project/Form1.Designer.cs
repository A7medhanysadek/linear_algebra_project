namespace linear_algebra_project
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
            btn_Next = new Button();
            label1 = new Label();
            label2 = new Label();
            txt_row = new TextBox();
            txt_col = new TextBox();
            btn_sbmt = new Button();
            btn_Reset = new Button();
            SuspendLayout();
            // 
            // btn_Next
            // 
            btn_Next.Location = new Point(200, 150);
            btn_Next.Name = "btn_Next";
            btn_Next.Size = new Size(150, 30);
            btn_Next.TabIndex = 0;
            btn_Next.Text = "Next";
            btn_Next.UseVisualStyleBackColor = true;
            btn_Next.Click += btn_Next_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(40, 50);
            label1.Name = "label1";
            label1.Size = new Size(157, 28);
            label1.TabIndex = 1;
            label1.Text = "Number of rows:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(40, 100);
            label2.Name = "label2";
            label2.Size = new Size(150, 28);
            label2.TabIndex = 2;
            label2.Text = "Number of cols:";
            // 
            // txt_row
            // 
            txt_row.Location = new Point(200, 50);
            txt_row.Name = "txt_row";
            txt_row.Size = new Size(150, 27);
            txt_row.TabIndex = 3;
            // 
            // txt_col
            // 
            txt_col.Location = new Point(200, 100);
            txt_col.Name = "txt_col";
            txt_col.Size = new Size(150, 27);
            txt_col.TabIndex = 4;
            // 
            // btn_sbmt
            // 
            btn_sbmt.Location = new Point(-500, 0);
            btn_sbmt.Name = "btn_sbmt";
            btn_sbmt.Size = new Size(65, 30);
            btn_sbmt.TabIndex = 8;
            btn_sbmt.Text = "submit";
            btn_sbmt.UseVisualStyleBackColor = true;
            btn_sbmt.Click += btn_sbmt_Click;
            // 
            // btn_Reset
            // 
            btn_Reset.Location = new Point(-500, 0);
            btn_Reset.Name = "btn_Reset";
            btn_Reset.Size = new Size(65, 30);
            btn_Reset.TabIndex = 9;
            btn_Reset.Text = "Reset";
            btn_Reset.UseVisualStyleBackColor = true;
            btn_Reset.Click += btn_Restart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 603);
            Controls.Add(btn_Reset);
            Controls.Add(btn_sbmt);
            Controls.Add(txt_col);
            Controls.Add(txt_row);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Next);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            Text = "linear system solving program";
            WindowState = FormWindowState.Maximized;
            FormClosing += closing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Next;
        private Label label1;
        private Label label2;
        private TextBox txt_row;
        private TextBox txt_col;
        private Button btn_sbmt;
        private Button btn_Reset;
    }
}