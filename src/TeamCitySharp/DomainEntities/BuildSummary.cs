using System;

namespace TeamCitySharp.DomainEntities
{
    public class BuildSummary
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string BuildTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }

        //When: locator=running:True
        public bool Running { get; set; }
        public int PercentageComplete { get; set; }

        //Not certain when these show up
        public string BranchName { get; set; }
        public bool? DefaultBranch { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}