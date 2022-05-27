using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTest
{
    internal class ConstantNode : BaseNode
    {
        double value;

        public ConstantNode(double value)
        {
            this.value = value;
        }
        public override double GetValue()
        {
            return value;
        }
    }
}
