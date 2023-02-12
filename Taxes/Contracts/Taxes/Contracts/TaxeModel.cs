using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class TaxeModel
    {
        public string Municipality { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}
