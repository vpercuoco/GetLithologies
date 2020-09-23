using System;
using System.Collections.Generic;

namespace GetLithologies.DataAccess
{
    public partial class LithologicSubintervals
    {
        public int Id { get; set; }
        public int? SectionInfoId { get; set; }
        public int? LithologicSubId { get; set; }
        public string LithologicDescriptionLithologicId { get; set; }

        public virtual LithologicDescriptions LithologicDescriptionLithologic { get; set; }
        public virtual Sections SectionInfo { get; set; }
    }
}
