using System;

namespace TeamCitySharp.DomainEntities
{
    public class Build
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }
        public bool Personal { get; set; }
        public bool History { get; set; }
        public bool Pinned { get; set; }
        public bool Running { get; set; }
        public RunningInfo RunningInfo { get; set; }
        public string StatusText { get; set; }
        public BuildConfig BuildType { get; set; }
        public DateTime StartDate { get; set; }
        public Agent Agent { get; set; }
        public object Tags { get; set; }
        public Properties Properties { get; set; }
        public object SnapshotDependencies { get; set; }
        public object ArtifactDependencies { get; set; }
        public object Revisions { get; set; }
        //public Triggered Triggered { get; set; }
        public ChangeWrapper Changes { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}