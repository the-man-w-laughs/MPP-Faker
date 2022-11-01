public class BooleanGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t == typeof(bool);
    }

    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        bool result = false;
        var rand = context.Random.NextInt64(2);
        result = Convert.ToBoolean(rand);
        return result;
    }
}