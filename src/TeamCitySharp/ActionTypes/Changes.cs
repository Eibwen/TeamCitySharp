using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class Changes : IChanges
    {
        private readonly TeamCityCaller _caller;

        internal Changes(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<ChangeSummary> All()
        {
            var changeWrapper = _caller.Get<ChangeWrapper>("/app/rest/changes");

            return changeWrapper.Change;
        }

        public Change FillInChangeData(ChangeSummary build)
        {
            return _caller.Get<Change>(build.Href);
        }

        public Change ByChangeId(string id)
        {
            var change = _caller.GetFormat<Change>("/app/rest/changes/id:{0}", id);

            return change;
        }

        public List<ChangeSummary> ByBuildConfigId(string buildConfigId)
        {
            var changeWrapper = _caller.GetFormat<ChangeWrapper>("/app/rest/changes?buildType={0}", buildConfigId);

            return changeWrapper.Change;
        }

        public List<ChangeSummary> GetChanges(Build build)
        {
            if (build.Changes.Count == 0) return new List<ChangeSummary>();

            var changeWrapper = _caller.GetFormat<ChangeWrapper>(build.Changes.Href);

            return changeWrapper.Change;
        }

        public ChangeSummary LastChangeDetailByBuildConfigId(string buildConfigId)
        {
            var changes = ByBuildConfigId(buildConfigId);

            return changes.FirstOrDefault();
        }

    }
}