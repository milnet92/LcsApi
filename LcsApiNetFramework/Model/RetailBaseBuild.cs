using System;

namespace LcsApi.Model
{
	public class RetailBaseBuild
    {
		public string BlobLink { get; set; }
		public string Label { get; set; }
		public DateTime PublishedDate { get; set; }
		public int Source { get; set; }
		public int Value { get; set; }
		public string Version { get; set; }
    }
}