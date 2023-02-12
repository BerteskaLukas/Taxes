using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class UpdateTaxeOrderModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
    }
}
