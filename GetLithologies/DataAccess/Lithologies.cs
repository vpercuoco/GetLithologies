﻿using System;
using System.Collections.Generic;

namespace GetLithologies.DataAccess
{
    public partial class Lithologies
    {
        public string LithologicDescriptionLithologicId { get; set; }
        public string PrefixLithology { get; set; }
        public string PrincipalLithology { get; set; }
        public string SuffixLithology { get; set; }
        public string TopOffsetCm { get; set; }
        public string BottomOffsetCm { get; set; }
    }
}
