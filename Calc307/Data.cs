using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Calc307
{
    enum Operation{
        Plus,
        Minus,
        Times,
        Div

    }
    class Data
    {
        
        public double Number {  get; set; }
        public Operation? Operation { get; set; }
        public bool IsNew { get; set; } = true;
    }
}
