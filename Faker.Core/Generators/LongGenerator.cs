public class LongGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t == typeof(long);
    }

    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        var result = context.Random.NextInt64();
        return result;
    }
}