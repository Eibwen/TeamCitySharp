using System;

namespace TeamCitySharp.DomainEntities
{
    public class BuildSummary
    {
        public string Id { get; set; }
        public string BuildTypeId { get; set; }
        public string Number { get; set; }
        //TODO this could be an enum
        public string Status { get; set; }
        //TODO this could be an enum
        public string State { get; set; }

        public string Href { get; set; }
        public string WebUrl { get; set; }

        //When: locator=running:True
        public bool Running { get; set; }
        public int PercentageComplete { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}