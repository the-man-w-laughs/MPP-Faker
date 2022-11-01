public class DecimalGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t == typeof(decimal);
    }

    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        byte scale = (byte)context.Random.Next(29);
        bool sign = context.Random.Next(2) == 1;
        var result = new decimal(context.Random.Next(),
                        context.Random.Next(),
                        context.Random.Next(),
                        sign,
                        scale);
        return result;
    }
}