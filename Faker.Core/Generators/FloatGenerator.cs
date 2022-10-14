public class FloatGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t == typeof(float);
    }

    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        var buffer = new byte[4];
        context.Random.NextBytes(buffer);
        var result = BitConverter.ToSingle(buffer,0);
        return result;
    }
}