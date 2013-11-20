using System;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    internal class Builds : IBuilds
    {
        private readonly TeamCityCaller _caller;

        internal Builds(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<BuildSummary> ByBuildLocator(BuildLocator locator)
        {
            var buildWrapper = _caller.GetFormat<BuildWrapper>("/app/rest/builds?locator={0}", locator);
            if (int.Parse(buildWrapper.Count) > 0)
            {
                return buildWrapper.Build;
            }
            return new List<BuildSummary>();
        }

        public BuildSummary LastBuildByAgent(string agentName)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(
                agentName: agentName,
                maxResults: 1
                                            )).SingleOrDefault();
        }

        public void Add2QueueBuildByBuildConfigId(string buildConfigId)
        {
            _caller.GetFormat("/action.html?add2Queue={0}", buildConfigId);
        }

        public List<BuildSummary> SuccessfulBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.SUCCESS
                                            ));
        }

        public BuildSummary LastSuccessfulBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.SUCCESS,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new BuildSummary();
        }

        public List<BuildSummary> FailedBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.FAILURE
                                            ));
        }

        public BuildSummary LastFailedBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.FAILURE,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new BuildSummary();
        }

        public BuildSummary LastBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new BuildSummary();
        }

        public List<BuildSummary> ErrorBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.ERROR
                                            ));
        }

        public BuildSummary LastErrorBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.ERROR,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new BuildSummary();
        }

        public List<BuildSummary> ByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId)
                                            ));
        }

        public List<BuildSummary> ByConfigIdAndTag(string buildConfigId, string tag)
        {
            return ByConfigIdAndTag(buildConfigId, new[] { tag });
        }

        public List<BuildSummary> ByConfigIdAndTag(string buildConfigId, string[] tags)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    tags: tags
                                            ));
        }

        public List<BuildSummary> ByUserName(string userName)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(
                user: UserLocator.WithUserName(userName)
                                            ));
        }

        public List<BuildSummary> AllSinceDate(DateTime date)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(sinceDate: date));
        }

        public List<BuildSummary> ByBranch(string branchName)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(branch: branchName));
        } 

        public List<BuildSummary> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(sinceDate: date, status: buildStatus));
        }

        public List<BuildSummary> NonSuccessfulBuildsForUser(string userName)
        {
            var builds = ByUserName(userName);
            if (builds == null)
            {
                return null;
            }

            return builds.Where(b => b.Status != "SUCCESS").ToList();
        }
    }
}