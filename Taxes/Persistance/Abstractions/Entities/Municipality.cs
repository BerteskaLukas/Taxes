using System.Collections.Generic;

namespace Abstractions.Entities
{
    public class Municipality : BaseEntity
    {
        public Municipality()
        {
            this.Taxes = new HashSet<Taxe>();
        }

        public string Name { get; set; }

        public virtual ICollection<Taxe> Taxes { get; set; }
    }
}
