using System;

namespace TeamCitySharp.DomainEntities
{
    public class Change : ChangeSummary
    {
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public FileWrapper Files { get; set; }
    }
}