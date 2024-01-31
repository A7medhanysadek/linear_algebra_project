namespace linear_algebra_project
{
    partial class equation_collector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(equation_collector));
            richtxtbox_equations = new RichTextBox();
            btn_sbmt = new Button();
            SuspendLayout();
            // 
            // richtxtbox_equations
            // 
            richtxtbox_equations.Location = new Point(0, 0);
            richtxtbox_equations.Name = "richtxtbox_equations";
            richtxtbox_equations.Size = new Size(788, 417);
            richtxtbox_equations.TabIndex = 0;
            richtxtbox_equations.Text = resources.GetString("richtxtbox_equations.Text");
            // 
            // btn_sbmt
            // 
            btn_sbmt.Location = new Point(348, 423);
            btn_sbmt.Name = "btn_sbmt";
            btn_sbmt.Size = new Size(94, 29);
            btn_sbmt.TabIndex = 1;
            btn_sbmt.Text = "submit";
            btn_sbmt.UseVisualStyleBackColor = true;
            btn_sbmt.Click += btn_sbmt_Click;
            // 
            // equation_collector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_sbmt);
            Controls.Add(richtxtbox_equations);
            Name = "equation_collector";
            Text = "equation collecting";
            FormClosing += closing;
            Load += equation_collector_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richtxtbox_equations;
        private Button btn_sbmt;
    }
}