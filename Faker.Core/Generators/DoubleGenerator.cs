public class DoubleGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t == typeof(double);
    }

    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        var result = context.Random.NextDouble();
        return result;
    }
}