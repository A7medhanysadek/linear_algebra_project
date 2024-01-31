using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linear_algebra_project
{
    internal class getting_solution_by_inverse
    {
        double[,] mtrx,A_pls_I,A_inverse;
        double[] b_mtrx,x_mtrx;
        int row, col,num_of_row_del=0, ignore=0;
        string result;
        //الكونستراكتور اللي بيتحكم في كل الكلاس اولا بيجزأ المصفوفة لمصفوفة نواتج ومعاملات وبينشئ بعدها مصفوفة الوحدة وعلى
        //اساسها بيطلع المعكوس ليه وكل خطوه بتحصل بتتخزن في متغير سترينج هيطبع كل خطوات الحل في آخر فورم
        public getting_solution_by_inverse( double[,] matrix,int r,int c)
        {
            row = r;
            col = c-1;
            mtrx = matrix;
            b_mtrx=new double[row];
            x_mtrx=new double[row];
            A_pls_I=new double[row, (col * 2)];
            get_matrices();
            creating_A_pls_I();
            get_inverse();
            if (ignore==0)
            {
                final_result();
            }
        }
        //بتخزن المصفوفه في متغير هنستخدمه بعدين في الفورم الاخير عشان نعرض طريقة الحل 
        private void print()
        {
            for (int i = 0; i < row; i++)
            {
                result += "[ ";
                for (int j = 0; j < (col*2); j++)
                {
                    result += A_pls_I[i, j] + " ";
                    if (j==(col-1))
                    {
                        result += ": ";
                    }
                }
                result += "]\n";
            }
            result += "===================================\n";
        }
        //بتضيف مصفوفة الوحدة على المصفوفة الرئيسية في مصفوفة جديدة
        void creating_A_pls_I()
        {
            for(int i = 0;i < row;i++)
            {
                for (int j = 0; j < (col*2); j++)
                {
                    if (j>(col-1))
                    {
                        if((i+col)==j)
                            A_pls_I[i, j] = 1;
                        else
                            A_pls_I[i, j] = 0;
                    }
                    else
                        A_pls_I[i, j] = mtrx[i,j];
                }
            }
        }
        //بتجزء مصفوفة المعاملات والنواتج لمصفوفة خاصة بالمعاملات ومصفوفة خاصه بالنواتج
        void get_matrices()
        {
            for(int i = 0; i < row; i++) 
            {
                for (int j = 0; j < col; j++)
                {
                    A_pls_I[i, j] = mtrx[i,j];
                }
            }
            for (int i = 0; i < row; i++)
            {
                b_mtrx[i] = mtrx[i, col];
            }
        }
        //بتخزن الناتج النهائي في المتغير اللي هنستخدمه بعدين في آخر فورم
        void final_result()
        {
            result += "X = A^-1 . b :\n";
            for(int i =0; i<row; i++)
            {
                result += "[ ";
                for (int j = col; j < (col*2); j++)
                {
                    x_mtrx[i] += A_pls_I[i, j] * b_mtrx[j-col];
                    result += A_pls_I[i, j] + " ";
                }
                result += "] [ " + b_mtrx[i] + " ]";
                if (i==(row/2))
                    result += " =\n";
                else
                    result += "\n";
            }
            result += "\n";
            for(int i = 0;i<row; i++)
            {
                if (i==0)
                    result += "x= [ " + x_mtrx[i] + " ]\n";
                else
                    result += "     [ " + x_mtrx[i] + " ]\n";
            }
            for (int i = 0; i < row; i++)
            {
                result += "X" + (i + 1) + " = " + x_mtrx[i] + "\n";
            }
        }
        //بتطلع معكوس المصفوفة 
        void get_inverse()
        {
            print();
            for (int j = num_of_row_del; j < col; j++)
            {
                for (int i = num_of_row_del; i < row; i++)
                {
                    if (A_pls_I[i, j] != 0 && num_of_row_del < col)
                    {
                        if (A_pls_I[num_of_row_del, j] == 0)
                            row_swicher(j, i);
                        if (A_pls_I[num_of_row_del, j] == 1 && num_of_row_del != row - 1)
                        {
                            process2(j);
                        }
                        else
                        {
                            process1(j);
                            if (num_of_row_del != row - 1)
                                process2(j);
                        }
                        num_of_row_del++;
                        break;
                    }
                }
            }
            num_of_row_del = 0;

            for (int i = row - 1; i >= 0; i--)
            {
                int row_checker = 0;
                for (int j = 0; j < col; j++)
                {
                    if (A_pls_I[i, j] == 0)
                        row_checker++;
                }
                if (row_checker == col)
                    num_of_row_del++;
                
                row_checker = 0;
            }
            if ((row - num_of_row_del) < col)
            {
                result += "the last "+num_of_row_del+" rows are zeros so det(A)=0\n";
                ignore++;
            }
            if (ignore==0)
            {
                for (int i = row - 1; i >= 0; i--)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (A_pls_I[i, j] == 1 && num_of_row_del < row - 1)
                        {
                            process3(j);
                            break;
                        }
                    }
                }

            }

        }
        //بتستخدم اذا كان في عمود غير صفري وفي نفس الوقت اول قيمه فيه بتساوي الصفر فبنبدل الصفوف عشان يبقى في ليدينج
        private void row_swicher(int c, int r)
        {
            int count = 0;
            for (int i = num_of_row_del; i < row; i++)
            {
                if (A_pls_I[i, c] == 1)
                {
                    count++;
                    for (int j = 0; j < (col*2); j++)
                    {
                        double swicher;
                        swicher = A_pls_I[i, j];
                        A_pls_I[i, j] = A_pls_I[num_of_row_del, j];
                        A_pls_I[num_of_row_del, j] = swicher;
                    }
                    result += "R" + (i + 1) + " <--> R" + (num_of_row_del + 1) + "\n";
                    print();
                    break;
                }
            }
            if (count == 0)
            {
                for (int j = 0; j < (col*2); j++)
                {
                    double swicher;
                    swicher = A_pls_I[r, j];
                    A_pls_I[r, j] = A_pls_I[num_of_row_del, j];
                    A_pls_I[num_of_row_del, j] = swicher;
                }
                result += "R" + (r + 1) + " <--> R" + (num_of_row_del + 1) + "\n";
                print();
            }
        }
        //بتقسم الصف على اول رقم في الصف من على الشمال عشان يبقى 1
        private void process1(int c)
        {
            double x = A_pls_I[num_of_row_del, c];
            for (int i = num_of_row_del; i < (col*2); i++)
            {
                A_pls_I[num_of_row_del, i] /= x;
            }
            result += "R" + (num_of_row_del + 1) + "/" + x + " --> R" + (num_of_row_del + 1) + "\n";
            print();
        }
        //بتخلي كل اللي تحت الليدينج ب 0
        private void process2(int c)
        {
            double x = 0;
            for (int i = num_of_row_del + 1; i < row; i++)
            {
                if (A_pls_I[i, c] != 0)
                {
                    x = A_pls_I[i, c];
                    for (int j = 0; j < (col*2); j++)
                    {
                        A_pls_I[i, j] = ((-1 * x) * A_pls_I[num_of_row_del, j]) + A_pls_I[i, j];
                    }
                    result += "-" + x + "R" + (num_of_row_del + 1) + " + R" + (i + 1) + " --> R" + (i + 1) + "\n";
                    print();
                }
            }
        }
        //بتخلي كل اللي فوق الليدنج ب 0
        private void process3(int c)
        {
            for (int i = row - (num_of_row_del + 2); i >= 0; i--)
            {
                if (A_pls_I[i, c] != 0)
                {
                    double x = A_pls_I[i, c];
                    for (int j = 0; j < (col*2); j++)
                    {
                        A_pls_I[i, j] = (-1 * x * A_pls_I[(row - (num_of_row_del + 1)), j]) + A_pls_I[i, j];
                    }
                    result += "-" + x + "R" + (row - num_of_row_del) + " + R" + (i + 1) + " --> R" + (i + 1) + "\n";
                    print();
                }
            }
            num_of_row_del++;
        }
        //هنستخدمها في الفورم اللي انشأ اوبجكت من الكلاس ده عشان نجيب المتغير اللي فيه خطوات الحل
        public string get_result()
        {
            return result;
        }

    }
}
