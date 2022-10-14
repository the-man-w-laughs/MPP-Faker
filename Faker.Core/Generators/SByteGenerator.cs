public class SByteGenerator : IValueGenerator
    {
        public bool CanGenerate(Type t)
        {
            return t == typeof(sbyte);
        }

        public object Generate(Type typeToGenerate, IGeneratorContext context)
        {
            var result = (sbyte)context.Random.Next(byte.MaxValue + 1);
            return result;
        }
    }