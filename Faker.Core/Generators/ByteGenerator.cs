public class ByteGenerator : IValueGenerator
    {
        public bool CanGenerate(Type t)
        {
            return t == typeof(byte);
        }

        public object Generate(Type typeToGenerate, IGeneratorContext context)
        {
            byte result = (byte)context.Random.Next(byte.MaxValue + 1);
            return result;
        }
    }