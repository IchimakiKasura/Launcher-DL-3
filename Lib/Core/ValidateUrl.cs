namespace Launcher_DL_v6;

public class ValidateLink
{
    public bool IsValid { get; set; } = false;
    public bool HasPlaylist { get; set; } = false;

    public ValidateLink(string url)
	{
		try
		{
		    Uri Link = new(url);
            var UrlHost = LauncherDL_Regex.URLname.Match(Link.Host).Groups["host"].Value;
            var UrlPath = Link.PathAndQuery;
            
            IsValid = true;

            if(UrlPath.Contains("&list=")) HasPlaylist = true;
		}
        catch { return; }

    }
}