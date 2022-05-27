using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    internal class DivisionNode : BaseNode
    {
        BaseNode childA;
        BaseNode childB;
        public DivisionNode(BaseNode a, BaseNode b)
        { 
            this.childA = a;
            this.childB = b;
        }
        public override double GetValue()
        {
            return childA.GetValue()/childB.GetValue();
        }
    }
}
