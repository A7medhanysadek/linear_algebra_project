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
    public partial class equation_collector : Form
    {
        protected double[,] mtrx;
        protected int col = 0, row = 0, _checked;
        string colector = string.Empty, result;
        public equation_collector(int ch)
        {
            _checked = ch;
            InitializeComponent();
        }

        private void equation_collector_Load(object sender, EventArgs e)
        {

        }
        // بيعد عدد الصفوف والاعمده وبناء عليه بينشئ مصفوفة وبيبدأ يقرأ من كل صف قيم معاملات كل متغير ويخزنها في مكانها المناسب في المصفوفة وبعدها بينشئ اوبجكت من كلاس الحل وبيحدد طريقة الحل بناء على قيمة المتغير
        // اما 1(حل بطريقة جاوس) وا 2 (حل بطريقة المعكوس)وبيستقبل متغير فيه خطوات الحل والناتج وبعدها بيظهر آخر فورم وبيبعتله المتغير عشان يعرض الناتج
        private void btn_sbmt_Click(object sender, EventArgs e)
        {
            int checker = 0;
            for (int n = 0; n < richtxtbox_equations.Text.Length; n++)
            {
                if (((int)richtxtbox_equations.Text[n] >= 97 && (int)richtxtbox_equations.Text[n] <= 122) || ((int)richtxtbox_equations.Text[n] >= 65 && (int)richtxtbox_equations.Text[n] <= 90))
                {
                    if (checker == 0)
                        col++;
                }
                if (richtxtbox_equations.Text[n] == '\n')
                {
                    if (checker == 0)
                        col++;
                    checker++;
                    row++;
                }
            }
            row++;
            mtrx = new double[row, col];
            int i = 0, j = 0;
            for (int n = 0; n < richtxtbox_equations.Text.Length; n++)
            {
                if (richtxtbox_equations.Text[n] == '-' || richtxtbox_equations.Text[n] == '+' || ((int)richtxtbox_equations.Text[n] >= 48 && (int)richtxtbox_equations.Text[n] <= 57))
                    colector += richtxtbox_equations.Text[n];
                if (((int)richtxtbox_equations.Text[n] >= 97 && (int)richtxtbox_equations.Text[n] <= 122) || ((int)richtxtbox_equations.Text[n] >= 65 && (int)richtxtbox_equations.Text[n] <= 90))
                {
                    if (colector == string.Empty || (!(double.TryParse(colector, out double ignore1)) && colector[0] == '-') || (!(double.TryParse(colector, out double ignore2)) && colector[0] == '+'))
                    {
                        colector += "1";
                    }
                    mtrx[i, j] = double.Parse(colector);
                    colector = string.Empty;
                    j++;

                    continue;
                }
                if (richtxtbox_equations.Text[n] == '\n' || n == (richtxtbox_equations.Text.Length - 1))
                {
                    mtrx[i, j] = double.Parse(colector);
                    colector = string.Empty;
                    j = 0;
                    i++;
                }

            }
            if (_checked == 1)
            {
                linear_system_progress l = new linear_system_progress(mtrx, row, col);
                result = l.get_result();
                this.Hide();
                Form form = new result_form(result);
                form.Show();
            }
            else if (_checked == 2)
            {
                getting_solution_by_inverse g = new getting_solution_by_inverse(mtrx, row, col);
                result = g.get_result();
                this.Hide();
                Form form = new result_form(result);
                form.Show();

            }
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
