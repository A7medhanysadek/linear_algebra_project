namespace linear_algebra_project
{
    partial class result_form
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
            lbl_final_result = new Label();
            btn_save = new Button();
            txtbox_filename = new TextBox();
            SuspendLayout();
            // 
            // lbl_final_result
            // 
            lbl_final_result.AutoSize = true;
            lbl_final_result.Font = new Font("Arial Narrow", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_final_result.Location = new Point(3, 9);
            lbl_final_result.Name = "lbl_final_result";
            lbl_final_result.Size = new Size(0, 40);
            lbl_final_result.TabIndex = 0;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(-500, 0);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(94, 29);
            btn_save.TabIndex = 1;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // txtbox_filename
            // 
            txtbox_filename.Location = new Point(-1000, 0);
            txtbox_filename.Name = "txtbox_filename";
            txtbox_filename.Size = new Size(651, 27);
            txtbox_filename.TabIndex = 2;
            txtbox_filename.Text = "Enter file name here if you want to save it then click save button:";
            // 
            // result_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(txtbox_filename);
            Controls.Add(btn_save);
            Controls.Add(lbl_final_result);
            Name = "result_form";
            Text = "Result Form";
            WindowState = FormWindowState.Maximized;
            FormClosing += closing;
            Load += result_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_final_result;
        private Button btn_save;
        private TextBox txtbox_filename;
    }
}