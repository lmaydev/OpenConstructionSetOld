namespace OpenConstructionSet.Data;

public static class DataExtensions
{
    public static bool IsModType(this DataFileType fileType) => fileType is (DataFileType.Mod or DataFileType.MergeMod);
}
