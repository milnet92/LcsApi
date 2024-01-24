namespace LcsApi.Model
{
	public class OneVersionUpdateView
    {
		public OneVersionViewVersion HotfixPackage { get; set; }
		public OneVersionViewVersion ServiceUpdates { get; set; }
		public OneVersionViewVersion UpcomingServiceUpdates { get; set; }
		public string CurrentVersionDisplay { get; set; }
		public bool HotfixPackageVisible { get; set; }
		public bool ServiceUpdatesVisible { get; set; }
		public bool UpcomingServiceUpdatesVisible { get; set; }
		public bool ShowEnvironmentUpToDateMessage { get; set; }
		public bool ShowMyVersionNoUpdatesMessage { get; set; }
    }
}