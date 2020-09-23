using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetLithologies.DataAccess;

namespace GetLithologies.Models
{
    public class LithologySectionInfoModel
    {
        public string Expedition { get; set; }
        public string Site { get; set; }
        public string Hole { get; set; }
        public string Core { get; set; }
        public string Type { get; set; }
        public string Section { get; set; }
        public string TopOffset { get; set; }
        public string BottomOffset { get; set; }
        public string SampleId { get; set; }
        public string SectionTextId { get; set; }
        public string LithologicDescriptionLithologicId { get; set; }
        public string PrefixLithology { get; set; }
        public string PrincipalLithology { get; set; }
        public string SuffixLithology { get; set; }


        public LithologySectionInfoModel(LithologyTable lithologyTable, Sections sectionInfo)
        {

            PrefixLithology = lithologyTable.PrefixLithology;
            PrincipalLithology = lithologyTable.PrincipalLithology;
            SuffixLithology = lithologyTable.SuffixLithology;
            TopOffset = lithologyTable.TopOffsetCm;
            BottomOffset = lithologyTable.BottomOffsetCm;

            Expedition = sectionInfo.Expedition;
            Site = sectionInfo.Site;
            Hole = sectionInfo.Hole;
            Core = sectionInfo.Core;
            Type = sectionInfo.Type;
            Section = sectionInfo.Section;
            SampleId = sectionInfo.SampleId;
            SectionTextId = sectionInfo.SectionTextId;
        }
    }
}
