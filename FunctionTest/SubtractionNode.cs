using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    internal class SubtractionNode : BaseNode
    {
        BaseNode childA;
        BaseNode childB;

        public SubtractionNode(BaseNode a, BaseNode b)
        {
            this.childA = a;
            this.childB = b;
        }
        public override double GetValue()
        {
            return childA.GetValue() - childB.GetValue();
        }
    }
}
