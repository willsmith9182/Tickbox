namespace Tool.GenerateJava.GenerateWebApi
{
    public class ClassNamePair
    {
        public readonly string CamelCaseName;
        public readonly string PascalCaseName;

        public ClassNamePair(string pascalCaseName)
        {
            PascalCaseName = pascalCaseName;
            CamelCaseName = pascalCaseName.Substring(0, 1).ToLowerInvariant() + pascalCaseName.Substring(1);
        }
    }
}