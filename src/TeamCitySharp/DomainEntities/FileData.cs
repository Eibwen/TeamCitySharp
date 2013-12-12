namespace TeamCitySharp.DomainEntities
{
    public class FileData
    {
        public string BeforeRevision { get; set; }
        public string AfterRevision { get; set; }
        public string File { get; set; }
        public string RelativeFile { get; set; }
    }
}