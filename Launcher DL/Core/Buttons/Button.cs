namespace Launcher_DL.Core.Buttons;

public abstract class BodyButton
{
    public static void CheckURL()
    {
        if (string.IsNullOrEmpty(textBoxLink.Text))
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, " <>No link provided!");
            WindowsComponents.FreezeComponents();
            return;
        }
    }
};