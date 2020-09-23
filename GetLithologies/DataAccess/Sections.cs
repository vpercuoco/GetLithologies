using System;
using System.Collections.Generic;

namespace GetLithologies.DataAccess
{
    public partial class Sections
    {
        public Sections()
        {
            LithologicDescriptions = new HashSet<LithologicDescriptions>();
            LithologicSubintervals = new HashSet<LithologicSubintervals>();
        }

        public int Id { get; set; }
        public string Expedition { get; set; }
        public string Site { get; set; }
        public string Hole { get; set; }
        public string Core { get; set; }
        public string Type { get; set; }
        public string Section { get; set; }
        public string SampleId { get; set; }
        public string SectionTextId { get; set; }

        public virtual ICollection<LithologicDescriptions> LithologicDescriptions { get; set; }
        public virtual ICollection<LithologicSubintervals> LithologicSubintervals { get; set; }
    }
}
