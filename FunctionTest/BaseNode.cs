using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    internal abstract class BaseNode
    {
        public abstract double GetValue();        

        public static BaseNode operator +(BaseNode a, BaseNode b)
        {
            return new AdditionNode(a, b);
        }

        public static BaseNode operator -(BaseNode a, BaseNode b)
        { 
            return new SubtractionNode(a, b);
        }

        public static BaseNode operator *(BaseNode a, BaseNode b)
        { 
            return new MultiplicationNode(a, b);
        }

        public static BaseNode operator /(BaseNode a, BaseNode b)
        { 
            return new DivisionNode(a, b);
        }
    }
}
