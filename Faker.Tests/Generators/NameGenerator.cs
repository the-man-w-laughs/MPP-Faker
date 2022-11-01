public class NameGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t == typeof(string);
    }

    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return "Nazar";
    }
}