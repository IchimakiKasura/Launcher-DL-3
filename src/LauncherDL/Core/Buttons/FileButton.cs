namespace LauncherDL.Core.Buttons;

public class FileButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        OpenFileDialog openFile = new();
		openFile.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV;*.flv;*.FLV;*.ogg;*.OGG;*.ts;*.TS";
		if (openFile.ShowDialog() == true)
		{
			console.AddFormattedText($"<Yellow%14>[INFO] <%12>Selected file: \"{Path.GetFileName(openFile.FileName)}\"");
			textBoxLink.Text = openFile.FileName;
		}
    }
}