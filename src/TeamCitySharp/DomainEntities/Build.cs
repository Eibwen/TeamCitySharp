using System;

namespace TeamCitySharp.DomainEntities
{
    public class Build
    {
        public string Id { get; set; }
        public string BuildTypeId { get; set; }
        public string Number { get; set; }
        //TODO this could be an enum
        public string Status { get; set; }
        //TODO this could be an enum
        public string State { get; set; }

        public bool Running { get; set; }
        public int PercentageComplete { get; set; }

        public string Href { get; set; }
        public string WebUrl { get; set; }

        //  These do not exist in guestAuth anyway...
        ////public bool Personal { get; set; }
        ////public bool History { get; set; }
        ////public bool Pinned { get; set; }
        public string StatusText { get; set; }
        public BuildConfig BuildType { get; set; }
        public object Tags { get; set; }
        public RunningInfo RunningInfo { get; set; }

        public DateTime QueuedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        //TODO Create objects for all these commented ones
        //public Triggered Triggered { get; set; }
        //public LastChanges LastChanges { get; set; }
        public ChangeWrapper Changes { get; set; }
        //public Revisions Revisions { get; set; }
        public Agent Agent { get; set; }
        //public Artifacts Artifacts { get; set; }
        //public RelatedIssues RelatedIssues { get; set; }
        public Properties Properties { get; set; }
        //public Statistics Statistics { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}