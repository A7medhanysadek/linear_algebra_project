using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linear_algebra_project
{
    public partial class main : Form
    {
        int _checked = 0;
        public main()
        {
            InitializeComponent();
        }
        //بينشئ فورم بيجمع المعادلات
        private void btn_op1_Click(object sender, EventArgs e)
        {
            Form f2 = new equation_collector(_checked);
            this.Hide();
            f2.Show();
        }
        //بينشئ فورم بيجمع معاملات المصفوفة وعدد صفوفها واعمدتها
        private void btn_op2_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1(_checked);
            this.Hide();
            f1.Show();

        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void main_Load(object sender, EventArgs e)
        {
            btn_op1.Visible = false;
            btn_op2.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _checked = 1;
                btn_op1.Visible = true;
                btn_op2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
            }
        }
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                _checked = 2;
                btn_op1.Visible = true;
                btn_op2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
            }
        }

    }
}
