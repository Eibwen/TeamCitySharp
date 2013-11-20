﻿namespace TeamCitySharp.DomainEntities
{
    public class RunningInfo
    {
        public int PercentageComplete { get; set; }
        public int ElapsedSeconds { get; set; }
        public int EstimatedTotalSeconds { get; set; }
        public string CurrentStageText { get; set; }
        public bool Outdated { get; set; }
        public bool ProbablyHanging { get; set; }
    }
}