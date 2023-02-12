using System;

namespace Contracts
{
    public class AddTaxeModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Value { get; set; }
        public Guid MunicipalityId { get; set; }
        public Guid TaxeTypeId { get; set; }
    }
}
