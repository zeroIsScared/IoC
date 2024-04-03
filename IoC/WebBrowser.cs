namespace BusinessLayer
{
    public class WebBrowser
	{
		public BrowserName Name { get; set; }
		public int MajorVersion { get; set; }

		public WebBrowser(string name, int majorVersion)
		{
			Name = TranslateStringToBrowserName(name);
			MajorVersion = majorVersion;
		}

		private BrowserName TranslateStringToBrowserName(string name)
		{
			if (name.Contains("IE")) return BrowserName.InternetExplorer;
			//TODO: Add more logic for properly sniffing for other browsers.
			if (name.Contains("FF")) return BrowserName.Firefox;
			if (name.Contains("CH")) return BrowserName.Chrome;
			if (name.Contains("OP")) return BrowserName.Opera;
			if (name.Contains("SF")) return BrowserName.Safari;
			if (name.Contains("DL")) return BrowserName.Dolphin;
			if (name.Contains("KQ")) return BrowserName.Konqueror;
			if (name.Contains("LX")) return BrowserName.Linx;
			return BrowserName.Unknown;
		}

		public enum BrowserName
		{
			Unknown,
			InternetExplorer,
			Firefox,
			Chrome,
			Opera,
			Safari,
			Dolphin,
			Konqueror,
			Linx
		}
	}
}
