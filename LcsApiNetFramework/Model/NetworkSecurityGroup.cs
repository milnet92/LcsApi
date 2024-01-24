namespace LcsApi.Model
{
	public class NetworkSecurityGroup
    {
		public string Name { get; set; }
		public NSGRule[] Rules { get; set; }
    }
}