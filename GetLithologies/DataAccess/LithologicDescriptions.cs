using System;
using System.Collections.Generic;

namespace GetLithologies.DataAccess
{
    public partial class LithologicDescriptions
    {
        public LithologicDescriptions()
        {
            DescriptionColumnValuePairs = new HashSet<DescriptionColumnValuePairs>();
            LithologicSubintervals = new HashSet<LithologicSubintervals>();
        }

        public string LithologicId { get; set; }
        public int? SectionInfoId { get; set; }
        public string DescriptionReport { get; set; }
        public string DescriptionTab { get; set; }
        public string DescriptionGroup { get; set; }
        public string DescriptionType { get; set; }

        public virtual Sections SectionInfo { get; set; }
        public virtual LithologyTable LithologyTable { get; set; }
        public virtual ICollection<DescriptionColumnValuePairs> DescriptionColumnValuePairs { get; set; }
        public virtual ICollection<LithologicSubintervals> LithologicSubintervals { get; set; }
    }
}
