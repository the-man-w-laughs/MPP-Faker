public class DateTimeGenerator : IValueGenerator
{
    private int _initYear = 1970;
    private int _initMonth = 1;
    private int _initDay = 1;
    private int _maxDays = 21900;
    private int _maxSeconds = 86400;

    public bool CanGenerate(Type t)
    {
        return t == typeof(DateTime);
    }


    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        DateTime dateTime = new DateTime(_initYear, _initMonth, _initDay);
        var days = context.Random.Next(_maxDays);
        var seconds = context.Random.Next(_maxSeconds);
        var result = dateTime.AddDays(days).AddSeconds(seconds);
        return result;
    }
}