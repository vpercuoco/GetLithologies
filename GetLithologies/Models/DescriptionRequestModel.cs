using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace GetLithologies.Models
{
    public class DescriptionRequestModel
    {
        public string SectionTextIDs { get; set; } = string.Empty;
        public string Expeditions { get; set; } = string.Empty;
        public string Sites { get; set; } = string.Empty;
        public string Holes { get; set; } = string.Empty;
        public string Cores { get; set; } = string.Empty;
        public string CoreTypes { get; set; } = string.Empty;


        public ICollection<string> SectionTextIDsCollection
        {
            get { return SplitString(SectionTextIDs); }
            set {; }
        }

        public ICollection<string> ExpeditionsCollection
        {
            get { return SplitString(Expeditions); }
            set {; }
        }
        public ICollection<string> SitesCollection
        {
            get { return SplitString(Sites); }
            set {; }
        }
        public ICollection<string> HolesCollection
        {
            get { return SplitString(Holes); }
            set {; }
        }
        public ICollection<string> CoresCollection
        {
            get { return SplitString(Cores); }
            set {; }
        }
        public ICollection<string> CoreTypesCollection
        {
            get { return SplitString(CoreTypes); }
            set {; }
        }

        //   public ICollection<string> Expeditions { get; set; }


        public DescriptionRequestModel()
        {
            SectionTextIDsCollection = new HashSet<string>();
            ExpeditionsCollection = new HashSet<string>();
            SitesCollection = new HashSet<string>();
            HolesCollection = new HashSet<string>();
            CoresCollection = new HashSet<string>();
            CoreTypesCollection = new HashSet<string>();
        }

        private ICollection<string> SplitString(string inputString)
        {
            var returnCollection = new HashSet<string>();

            foreach (string entry in inputString.Split(new[] { " ", ",", Environment.NewLine, "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                returnCollection.Add(entry);
            }
            return returnCollection;
        }

        //TODO: Use a regular expression to check input string for correct TextID formats.
        /*
        private HashSet<string> SplitInputString(string inputString)
        {
            var textIds = new HashSet<string>();
            var y = inputString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // ^[a - zA - Z]{ 7}$/
            int numberOfIntsInTestCode = 7;

            var x = y[0].Remove(y[0].Length - numberOfIntsInTestCode);

                  MatchCollection mc = Regex.Match(y.First(),@"")
        }
        */
    }
}
