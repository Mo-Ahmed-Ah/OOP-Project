namespace OOPProject.Extentions;

public static class StringExtention
{
    public static string NormalizeId(this string id) => 
        id !=  null ? id.Trim().ToUpperInvariant() : string.Empty;
    public static bool IsDiget(this string value)
    {
        foreach (var item in value)
            if (char.IsDigit(item))
                return true;
        return false;
    }
    public static bool FormatEmail(this string value)
    {
        bool hasAat = false;
        bool hasDot = false;
        foreach (var item in value)
        {
            if(item == '@') hasAat = true;
            if(item == '.') hasDot = true;
        }
            
        return (hasAat && hasDot);
    }

    
}
