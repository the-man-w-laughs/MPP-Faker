public class IntGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t == typeof(int);
    }

    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        var result = (int)context.Random.Next();
        return result;
    }
}