namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class FilePathAttribute : Attribute
{
    private const string FolderDataName = "LauncherDL_Data";

    public string FileName { get; }

    public FilePathAttribute(string fileName)
    {
        FileName = fileName;
    }

    public static void InitiateAttribute<T>()
    {
        foreach (FieldInfo field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            if (field.IsDefined(typeof(FilePathAttribute), false))
            {
                var attribute = field.GetCustomAttribute<FilePathAttribute>();
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), FolderDataName, attribute.FileName);
                field.SetValue(null, filePath);
            }
        }
    }
}