using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    internal class Vector
    {
        BaseNode[] array; 
        public Vector(int size)
        { 
            array= new BaseNode[size];
        }

        public BaseNode[] GetArray()
        { 
            return array;
        }

        public void SetValue(int i, BaseNode value)
        {
            array[i] = value;
        }

        public BaseNode GetValue(int i)
        { 
            return GetArray()[i];
        }

        public void Print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].GetValue() + "\t");
            }
            Console.Write("\n");
        }
                
    }
}
