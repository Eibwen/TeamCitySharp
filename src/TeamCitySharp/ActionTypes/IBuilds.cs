using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuilds
    {
        List<BuildSummary> SuccessfulBuildsByBuildConfigId(string buildConfigId);
        BuildSummary LastSuccessfulBuildByBuildConfigId(string buildConfigId);
        List<BuildSummary> FailedBuildsByBuildConfigId(string buildConfigId);
        BuildSummary LastFailedBuildByBuildConfigId(string buildConfigId);
        BuildSummary LastBuildByBuildConfigId(string buildConfigId);
        List<BuildSummary> ErrorBuildsByBuildConfigId(string buildConfigId);
        BuildSummary LastErrorBuildByBuildConfigId(string buildConfigId);
        List<BuildSummary> ByBuildConfigId(string buildConfigId);
        List<BuildSummary> ByConfigIdAndTag(string buildConfigId, string tag);
        List<BuildSummary> ByUserName(string userName);
        List<BuildSummary> ByBuildLocator(BuildLocator locator);
        List<BuildSummary> AllSinceDate(DateTime date);
        List<BuildSummary> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus);
        List<BuildSummary> NonSuccessfulBuildsForUser(string userName);
        List<BuildSummary> ByBranch(string branchName);
        BuildSummary LastBuildByAgent(string agentName);
        void Add2QueueBuildByBuildConfigId(string buildConfigId);
    }
}