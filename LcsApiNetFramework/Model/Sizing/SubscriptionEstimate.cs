namespace LcsApi.Model.Sizing
{
    public class SubscriptionEstimate
    {
        public bool IsActiveEstimateLocked { get; set; }
        public bool HasMultiProjectBetaFeature { get; set; }
        public SubmittedEstimation[] NonActiveEstimates { get; set; }
        public SubmittedEstimation ActiveEstimate { get; set; }
    }
}