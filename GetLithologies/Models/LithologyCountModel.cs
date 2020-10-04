using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetLithologies.Models
{
    public class LithologyCountModel
    {
        public IEnumerable<string> LithologyIdentifiers { get; set; }
        public IEnumerable<string> CountOfLithologyIdentifiers { get; set; }

    }
}
