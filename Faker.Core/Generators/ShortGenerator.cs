public class ShortGenerator : IValueGenerator
    {
        public bool CanGenerate(Type t)
        {
            return t == typeof(short);
        }

        public object Generate(Type typeToGenerate, IGeneratorContext context)
        {
            var result = (short)context.Random.Next(short.MaxValue + 1);
            return result;
        }
    }