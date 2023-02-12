using System;

namespace Abstractions.Entities
{
    public class TaxeOrder : BaseEntity
    {
        public Guid? ParentId { get; set; }
        public Guid MunicipalityId { get; set; }
        public Guid TaxeTypeId { get; set; }

        public TaxeOrder Parent { get; set; }
        public Municipality Municipality { get; set; }
        public TaxeType TaxeType { get; set; }
    }
}
