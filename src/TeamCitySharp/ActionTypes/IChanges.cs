using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IChanges
    {
        List<ChangeSummary> All();
        Change ByChangeId(string id);
        ChangeSummary LastChangeDetailByBuildConfigId(string buildConfigId);
        List<ChangeSummary> ByBuildConfigId(string buildConfigId);
    }
}