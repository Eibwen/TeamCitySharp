using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class ChangeWrapper
    {
        public int Count { get; set; }
        public string Href { get; set; }
        public List<ChangeSummary> Change { get; set; }
    }
}