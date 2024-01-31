using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace linear_algebra_project
{
    public partial class result_form : Form
    {
        FileStream f;
        int index = 0;
        //بيستقبل المتغير اللي فيه خطوات الحل وبيعرضه على الفورم
        public result_form(string result)
        {
            InitializeComponent();
            lbl_final_result.Text = result;
            btn_save.Location = new Point((lbl_final_result.Location.X), (lbl_final_result.Location.Y + lbl_final_result.Size.Height));
            txtbox_filename.Location = new Point(btn_save.Location.X + 100, btn_save.Location.Y);
        }
        //بينشئ ملف بي دي اف بيخزن فيه خطوات الحل اذا المستخدم ضغط على حفظ
        private void creating_pdf(string p)
        {
            string path = p;
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            Paragraph p1 = new Paragraph();
            p1.Add(lbl_final_result.Text);
            doc.Add(p1);
            doc.Close();
            MessageBox.Show("pdf file has been created.");
        }
        private void result_form_Load(object sender, EventArgs e)
        {

        }
        //اذا المستخدم ضغط على حفظ بياخد اسم الملف من المستخدم وبيخزن خطوات الحل في ملف بي دي اف
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txtbox_filename.Text == "Enter file name here if you want to save it then click save button:" || txtbox_filename.Text == "")
                MessageBox.Show("Enter a valid name for example : My Answer ");
            else
            {
                if (MessageBox.Show("are you sure you want to save answer in pdf file?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string file_name = txtbox_filename.Text + ".pdf";
                    creating_pdf(file_name);
                    Application.Exit();
                }
            }
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
