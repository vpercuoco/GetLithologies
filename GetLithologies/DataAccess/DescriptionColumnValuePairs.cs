using System;
using System.Collections.Generic;

namespace GetLithologies.DataAccess
{
    public partial class DescriptionColumnValuePairs
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string ColumnName { get; set; }
        public string LithologicDescriptionLithologicId { get; set; }
        public string CorrectedColumnNames { get; set; }

        public virtual LithologicDescriptions LithologicDescriptionLithologic { get; set; }
    }
}
