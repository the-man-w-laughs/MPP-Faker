using System.Text;

public class StringGenerator : IValueGenerator
{
    private int _minLength = 10;
    private int _maxLength = 32;

    public bool CanGenerate(Type t)
    {
        return t == typeof(string);
    }


    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        var len = context.Random.Next(_minLength, _maxLength);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < len; i++)
        {
            var index = context.Random.Next(context.Alphabet.Length);
            sb.Append(context.Alphabet[index]);
        }
        return sb.ToString();
    }
}