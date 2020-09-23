using System;
using System.Collections.Generic;

namespace GetLithologies.DataAccess
{
    public partial class AllSections
    {
        public string Exp { get; set; }
        public string Site { get; set; }
        public string Hole { get; set; }
        public string Core { get; set; }
        public string Type { get; set; }
        public string Sect { get; set; }
        public string RecoveredLengthM { get; set; }
        public string CuratedLengthM { get; set; }
        public string TopDepthCsfAM { get; set; }
        public string BottomDepthCsfAM { get; set; }
        public string TopDepthCsfBM { get; set; }
        public string BottomDepthCsfBM { get; set; }
        public string TextIdOfSection { get; set; }
        public string TextIdOfArchiveHalf { get; set; }
        public string TextIdOfWorkingHalf { get; set; }
        public string CatwalkSamplesNo { get; set; }
        public string SectionHalfSamplesNo { get; set; }
        public string Comments { get; set; }
    }
}
