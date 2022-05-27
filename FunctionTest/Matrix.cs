using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    internal class Matrix
    {
        protected int size;
        protected BaseNode[] array;

        public Matrix(int size)
        {
            this.size = size;

            array=new BaseNode[size*size];
            for (int i = 0; i < size * size; i++)
            {
                array[i] = new ZeroNode();
            }
        }

        public void SetValue(int row, int col, BaseNode value)
        { 
            array[(row*size) + col] = value;
        }

        static Matrix GetLaplaceSubMatrix(Matrix m, int row, int col)
        {
            Matrix mat = new Matrix(m.size - 1);

            int counter = 0;
            for (int j = 0; j < m.size; j++)
            {
                for (int i = 0; i < m.size; i++)
                {
                    if (i != col && j != row)
                    {                        
                        mat.array[counter++] = m.array[i + j * m.size];
                    }
                }
            }             
            return mat;
        }

        public static Matrix GetCoFactorMatrix(Matrix m)
        {
            Matrix mat=new Matrix(m.size);
            for (int j = 0; j < m.size; j++)
            {
                for (int i = 0; i < m.size; i++)
                {
                    if (IsSignPositive(i, j))
                    {
                        mat.array[(j * m.size) + i] = Det(GetLaplaceSubMatrix(m, j, i));
                    }
                    else
                    {
                        mat.array[(j * m.size) + i] = new ZeroNode()-Det(GetLaplaceSubMatrix(m, j, i));
                    } 
                }
            }
            return mat;
        }

        public static Matrix GetAdjugateMatrix(Matrix m)  // same as getCofactorMatrix but transposed i<>j swapped when getting submatrix
        {
            Matrix mat = new Matrix(m.size);
            for (int j = 0; j < m.size; j++)
            {
                for (int i = 0; i < m.size; i++)
                {
                    if (IsSignPositive(i, j))
                    {
                        mat.array[(j * m.size) + i] = Det(GetLaplaceSubMatrix(m, i, j));
                    }
                    else
                    {
                        mat.array[(j * m.size) + i] = new ZeroNode() - Det(GetLaplaceSubMatrix(m, i, j));
                    }
                }
            }
            return mat;
        }



        public static Matrix Transpose(Matrix m)
        {
            Matrix mat = new Matrix(m.size);
            for (int j = 0; j < m.size; j++)
            {
                for (int i = 0; i < m.size; i++)
                {
                    mat.array[(j * m.size) + i] = m.array[(i * m.size) + j];
                }
            }

            return mat;
        }

        static bool IsSignPositive(int row, int col)
        {
            return (col + row) % 2 == 0;            
        }

        public static Matrix Inverse(Matrix m)
        {
            Matrix mat = GetAdjugateMatrix(m);
            BaseNode det = Det(m);
            
            for (int i = 0; i < mat.size*mat.size; i++)
            {
                mat.array[i] /= det;
            }
            

            return mat;
        }


        public void Print()
        {
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write(array[i+j*size].GetValue() + "\t");
                }
                Console.Write("\n");
            }
        }


        public Vector Mult(Vector v)
        {
            Vector vec = new Vector(size);

            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    if (i == 0)
                    {
                        vec.GetArray()[j] = array[i + j * size] * v.GetArray()[i];
                    }
                    else
                    {
                        vec.GetArray()[j] += array[i + j * size] * v.GetArray()[i];
                    }
                    //Console.Write(array[i + j * size].GetValue());
                    //Console.Write(v.GetArray()[i].GetValue());
                }
                //Console.Write("\n");
            }
            
            return vec;
        }


        public static BaseNode Det(Matrix m)
        {
            //ad-bc
            if (m.size == 2)
            {
                Console.WriteLine("Matrix is 2x2");
                return m.array[0] * m.array[3] - m.array[1] * m.array[2];                

            }

            int j = 0;

            BaseNode n=new ZeroNode();
            for (int i = 0; i+1<= m.size; i++)  // todo choose best row or col
            {
                Matrix mat = GetLaplaceSubMatrix(m, j, i);
                Console.WriteLine("---------");
                mat.Print();

                if (Matrix.IsSignPositive(i, j))
                {
                    n += m.array[i + j * m.size] * Det(mat);
                }
                else
                {
                    n -= m.array[i + j * m.size] * Det(mat);
                }
                
                Console.WriteLine(n.GetValue());
                
            }


            return n;
        }


    }
}
