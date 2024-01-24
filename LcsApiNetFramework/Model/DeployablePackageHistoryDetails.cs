using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class DeployablePackageHistoryDetails
    {
        public string ActionStatus { get; set; }
        public string CreatedBy { get; set; }
        public string CompletionTime { get; set; }
        public string PackageDescription { get; set; }
        public bool PackageReleaseCandidate { get; set; }
        public string ActivityId { get; set; }
        public bool IsInProcessingState { get; set; }
        public bool IsInProgress { get; set; }
        public bool IsEnvironmentUpgradeInProgress { get; set; }
        public bool IsAutomatedRunInProgress { get; set; }
        public bool CanSignOffAction { get; set; }
        public int CompletedStepCount { get; set; }
        public int TotalStepCount { get; set; }
        public int FailedStepCount { get; set; }
        public int QueuedStepCount { get; set; }
        public bool IsParallelExecution { get; set; }
        public string IsMicrosoftUpdateText { get; set; }
        public object WarningMessage { get; set; }
        public bool ShowRollbackSteps { get; set; }
        public bool ShowStepErrorDetails { get; set; }
        public bool CanDownloadRunbook { get; set; }
        public bool OnPremShowRetryButton { get; set; }
        public bool OnPremShowRollbackButton { get; set; }
        public bool OnPremShowAbortButton { get; set; }
        public bool OnPremShowDownloadLogsButton { get; set; }
        public bool DeploymentStepsEnabled { get; set; }
        public bool IsMicrosoftUpdate { get; set; }
        public bool OnPremShowUpdateEnvironmentButton { get; set; }
        public bool SignOffEnabled { get; set; }
        public bool AbortResumeEnvUpdatesEnabled { get; set; }
        public bool IsUpgradeEnvironmentServicingInProgress { get; set; }
        public bool ServicingActionAllowedOnProduction { get; set; }
        public object[] StepDetails { get; set; }
        public object[] StepErrorDetails { get; set; }
    }
}
