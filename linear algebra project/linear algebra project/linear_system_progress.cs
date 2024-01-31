using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.DirectoryServices;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Cryptography;

namespace linear_algebra_project
{
    internal class linear_system_progress
    {
        private double[,] mtrx;
        private int num_of_row_del = 0, row, col, ignore_reduced_row_echelon=0;
        private string result;
        // الكونستراكتور اللي بيتحكم في كل الكلاس اولا بياخد المصفوفة من الفورم اللي عمل منه ابوجكت وبيطبق عليها خطوات رو اشلون وبعدها بيتأكد من ان مفيش حل او فيه عدد لا نهائي من الحلول وعلى اساسه بيقرر اذا هيكمل في البرنامج او هيوقف اذا هيكمل هيطبق خطوات الريديوسد على المصفوفة ويخزن الحل
        public linear_system_progress(double[,] m, int r, int c)
        {
            mtrx = m;
            row = r; col = c;
            row_echelon();
            if(ignore_reduced_row_echelon ==0)
            {
                reduced_row_echelon();
                final_result();
            }
        }
        //بتبدل صف مكان صف اذا في عمود غير صفري واول قيمه فيه ب 0 
        private void row_swicher(int c, int r)
        {
            int count = 0;
            for (int i = num_of_row_del; i < row; i++)
            {
                if (mtrx[i, c] == 1)
                {
                    count++;
                    for (int j = 0; j < col; j++)
                    {
                        double swicher;
                        swicher = mtrx[i, j];
                        mtrx[i, j] = mtrx[num_of_row_del, j];
                        mtrx[num_of_row_del, j] = swicher;
                    }
                    result += "R" + (i + 1) + " <--> R" + (num_of_row_del + 1) + "\n";
                    print();
                    break;
                }
            }
            if (count == 0)
            {
                for (int j = 0; j < col; j++)
                {
                    double swicher;
                    swicher = mtrx[r, j];
                    mtrx[r, j] = mtrx[num_of_row_del, j];
                    mtrx[num_of_row_del, j] = swicher;
                }
                result += "R" + (r + 1) + " <--> R" + (num_of_row_del + 1) + "\n";
                print();
            }
        }
        //بتخزن المصفوفة في متغير هيظهر خطوات الحل في آخر فورم
        private void print()
        {
            for (int i = 0; i < row; i++)
            {
                result += "[ ";
                for (int j = 0; j < col; j++)
                {
                    result += mtrx[i, j]+" ";
                }
                result += "]\n";
            }
                result += "===================================\n";
        }
        //بتقسم الصف على اول رقم في الصف من على الشمال عشان يبقى 1 او ليدينج
        private void process1(int c)
        {
                double x = mtrx[num_of_row_del, c];
                for (int i = num_of_row_del; i < col; i++)
                {
                    mtrx[num_of_row_del, i] /= x;
                }
                result += "R" + (num_of_row_del + 1) + "/" + x + " --> R"+(num_of_row_del+1)+"\n";
                print() ;
        }
        //بتغير قيم كل العناصر اللي تحت الليدينج ل 0
        private void process2(int c)
        {
            double x=0;
            for (int i = num_of_row_del+1;i < row;i++)
            {
                if (mtrx[i, c] != 0)
                {
                    x = mtrx[i, c];
                    for (int j = 0; j < col; j++)
                    {
                        mtrx[i, j] = ((-1 * x) * mtrx[num_of_row_del, j]) + mtrx[i, j];
                    }
                    result += "-" + x + "R" + (num_of_row_del + 1) + " + R" + (i + 1) + " --> R" + (i + 1) + "\n";
                    print();
                }
            }
        }
        //بتطبق خطوات رو اشلون على المصفوفة وبتتحقق بعدها اذا السيستم ملوش حل او ليه عدد لا نهائي من الحلول
        private void row_echelon()
        {
            print();
            for (int j = num_of_row_del; j < col; j++)
            {
                for (int i = num_of_row_del; i < row; i++)
                {
                    if (mtrx[i, j] != 0&&num_of_row_del<col-1)
                    {
                        if (mtrx[num_of_row_del, j] == 0)
                            row_swicher(j,i);
                        if (mtrx[num_of_row_del, j] == 1&&num_of_row_del!=row-1)
                        {
                            process2(j);
                        }
                        else
                        {
                            process1 (j);
                            if (num_of_row_del!=row-1)
                                process2(j);
                        }
                        num_of_row_del++;
                        break;
                    }
                }
            }
            num_of_row_del = 0;

            for (int i = row-1; i >= 0; i--)
            {
                int row_checker = 0;
                for (int j = 0; j < col-1; j++)
                {
                    if (mtrx[i,j]==0)
                        row_checker++;
                }
                if (row_checker==col-1)
                {
                    if (mtrx[i,col-1]==0)
                    {
                        num_of_row_del++;
                    }
                    else if (mtrx[i,col-1]!=0)
                    {
                        result += "system has no solution\n";
                        ignore_reduced_row_echelon++;
                        break;
                    }
                }
                row_checker = 0;
            }
            if ((row - num_of_row_del) < (col - 1))
            {
                result += "system has many infintly solutions\n";
                ignore_reduced_row_echelon++;
            }

        }
        //بتخلي كل العناصر اللي فوق الليدنج ب 0
        private void process3(int c)
        {
            for (int i = row-(num_of_row_del+2); i >=0; i--)
            {
                if (mtrx[i,c]!=0)
                {
                    double x = mtrx[i, c];
                    for (int j = 0; j < col; j++)
                    {
                        mtrx[i, j] = (-1 * x * mtrx[(row - (num_of_row_del + 1)), j]) + mtrx[i, j];
                    }
                    result += "-" + x + "R" + (row - num_of_row_del) + " + R" + (i+1) + " --> R" + (i+1) + "\n";
                    print();
                }
            }
            num_of_row_del++;
        }
        //بتطبق خطوات الريديوسد على المصفوفة
        private void reduced_row_echelon()
        {
            for (int i = row-1; i >= 0; i--)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mtrx[i,j]==1&&num_of_row_del<row-1)
                    {
                        process3(j);
                        break;
                    }
                }
            }
        }
        //بتخزن الحل النهائي في متغير هيظهر خطوات الحل في آخر فورم
        private void final_result()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mtrx[i,j]==1)
                    {
                        result += "X" + (j + 1) +" = "+ mtrx[i, col - 1]+"\n";
                        break;
                    }
                }
            }
        }
        //هنستخدمها في الفورم اللي عمل اوبجكت من الكلاس ده عشان نستخدم المتغير اللي فيه خطوات الحل
        public string get_result()
        {
            return result;
        }
        
    }
}
