namespace IWannaPlaceEveryItem.Constructor
{
  public class Part
	{
		public bool Enabled { get; set; }
		public string Info { get; set; } = "";

		public Part(bool enabled, string info)
    {
			Enabled = enabled;
			Info = info;
    }
	}
}