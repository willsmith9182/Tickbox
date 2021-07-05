namespace Tool.GenerateJava.GenerateModel
{
    public class PackageName
    {
        public readonly string LowerCase;
        public readonly string MixCase;

        public PackageName(string lowerCase)
        {
            LowerCase = lowerCase;
            MixCase = lowerCase.Substring(0, 1).ToUpperInvariant() + lowerCase.Substring(1);
        }
    }
}