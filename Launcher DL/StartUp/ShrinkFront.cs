namespace Launcher_DL.StartUp;

internal class ShrinkFront
{
	public static void AutoShrink(DLLanguages.Pick.LanguageName language)
	{
		
		switch(language)
		{
			case DLLanguages.Pick.LanguageName.Default: _Japanese(); break;
			case DLLanguages.Pick.LanguageName.Japanese: _Japanese(); break;
			case DLLanguages.Pick.LanguageName.Tagalog: _Tagalog(); break;
			case DLLanguages.Pick.LanguageName.bruh: _bruh(); break;
		}
	}

	private static void _Japanese()
	{
		buttonFileFormat.TextSize = 12;
		buttonOpenFile.TextSize = 16;
	}

	private static void _Tagalog()
	{ }

	private static void _bruh()
	{ }
}

