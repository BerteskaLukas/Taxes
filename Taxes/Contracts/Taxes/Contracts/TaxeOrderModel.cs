using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class TaxeOrderModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string TypeName { get; set; }
    }
}
