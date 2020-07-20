namespace AntDesign.Pro.Localization.Json
{
    public class JsonLocalizationOptions
    {
        public string ResourcesPath { get; set; } = "Resources";

        public ResourcesPathType ResourcesPathType { get; set; }

        public string RootNamespace { get; set; }
    }

    public enum ResourcesPathType
    {
        TypeBased = 0,
        CultureBased = 1,
    }
}
