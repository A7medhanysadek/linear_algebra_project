using Microsoft.VisualBasic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace linear_algebra_project
{


    public partial class Form1 : Form
    {
        double[,] mtrx;
        int row, col, p1 = 40, p2 = 50, _checked;
        TextBox txtbox;
        TextBox[,] txtboxs;
        string result;
        public Form1(int ch)
        {
            _checked = ch;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //ÈíÊÃßÏ ÇæáÇ ãä ÔÑæØ ÇÏÎÇá ÚÏÏ ÇÚãÏÉ æÕÝæÝ ÇáãÕÝæÝÉ áÇä ÇÐÇ ßÇäÊ ÚÏÏ ÇáÕÝæÝ(ÇáãÚÇÏáÇÊ) ÇÞá ãä ÚÏÏ ÇáÇÚãÏÉ(ÇáãÊÛíÑÇÊ) åíÈÞì Ýíå ÚÏÏ áÇ åäÇÆí ãä ÇáÍáæá
        //æÈÚÏ ãÇ íÊÃßÏ ÈíÈÏÃ íäÔÆ ãÌãæÚå ãä ÇáÎÇäÇÊ Úáì ÍÓÈ ÚÏÏ ÇáÇÚãÏå ÚÔÇä ÇáãÓÊÎÏã íÍØ ÝíåÇ Þíã ÇáãÕÝæÝÉ
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (!(int.TryParse(txt_row.Text, out int ignore1) && int.TryParse(txt_col.Text, out int ignore2)))
                MessageBox.Show("Enter valid data");
            else if (int.Parse(txt_col.Text) == 2)
                MessageBox.Show("this system will have only one solution \nso you should enter another number > 2");
            else if (int.Parse(txt_row.Text) < (int.Parse(txt_col.Text) - 1))
                MessageBox.Show("system has many infintly solutions");
            else if (int.Parse(txt_row.Text) > 40 || int.Parse(txt_col.Text) > 40)
                MessageBox.Show("Max Number of rows and cols =40");
            else
            {
                label1.Location = new Point(-500, 0);
                label2.Location = new Point(-500, 0);
                txt_row.Location = new Point(-500, 0);
                txt_col.Location = new Point(-500, 0);
                btn_Next.Location = new Point(-500, 0);
                row = int.Parse(txt_row.Text); col = int.Parse(txt_col.Text);
                mtrx = new double[row, col];
                txtboxs = new TextBox[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        txtbox = new TextBox();
                        txtbox.Size = new Size(30, 30);
                        txtbox.Location = new Point(p1, p2);
                        this.Controls.Add(txtbox);
                        p1 += 50;
                        txtbox.Text = "0";
                        txtboxs[i, j] = txtbox;
                        if (i == (row - 1) && j == 0)
                        {
                            btn_sbmt.Location = new Point(p1 - 50, p2 + 40);
                            btn_Reset.Location = new Point((p1 - 50) + 66, p2 + 40);
                        }
                    }
                    p2 += 50;
                    p1 = 40;
                }
            }
        }
        //ÈíÈÏÃ íÌãÚ Þíã ÇáãÕÝæÝÉ ÈÚÏ ãÇ ÇáãÓÊÎÏã ÏÎáåÇ æÈíÈÚÊ ÇáÈíÇäÇÊ áßáÇÓ ÇáÍá æÈíÍÏÏ ØÑíÞÉ ÇáÍá ÈäÇÁ Úáì ÞíãÉ ãÊÛíÑ ãÎÒä Ýíå
        // ÇãÇ 1 (Íá ÈØÑíÞÉ ÌÇæÓ) æÇ 2(Íá ÈØÑíÞÉ ÇáãÚßæÓ)æÈÚÏåÇ ÈíÇÎÏ ãÊÛíÑ ãä ÇáßáÇÓ Ýíå ßá ÎØæÇÊ ÇáÍá ãÚ ÇáäÇÊÌ ÇáäåÇÆí
        // æÈíÙåÑ ÂÎÑ ÝæÑã Çááí åíÙåÑ Ýíå ÇáÍá æåíÈÚÊáå ÇáãÊÛíÑ Çááí Ýíå ÎØæÇÊ ÇáÍá
        private void btn_sbmt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to submit the matrix?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        mtrx[i, j] = double.Parse(txtboxs[i, j].Text);
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
        }
        //ÈíÚãá ÑíÓíÊ áßá ÇáÎÇäÇÊ Çááí ÇÊÖÇÝÊ æÈíÑÌÚ ÇáÝæÑã ááÇæá
        private void btn_Restart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    this.Controls.Remove(txtboxs[i, j]);
                }
            }
            btn_Reset.Location = new Point(-500, 0);
            btn_sbmt.Location = new Point(-500, 0);
            p1 = 40;
            p2 = 50;
            label1.Location = new Point(40, 50);
            label2.Location = new Point(40, 100);
            txt_row.Location = new Point(200, 50);
            txt_row.Text = "";
            txt_col.Location = new Point(200, 100);
            txt_col.Text = "";
            btn_Next.Location = new Point(200, 150);
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}