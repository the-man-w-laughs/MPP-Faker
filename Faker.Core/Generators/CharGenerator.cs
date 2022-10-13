public class CharGenerator : IValueGenerator
    {
        public bool CanGenerate(Type t)
        {
            return t == typeof(char);
        }

        public object Generate(Type typeToGenerate, IGeneratorContext context)
        {
            var index = context.Random.Next(context.Alphabet.Length);
            var result = context.Alphabet[index];
            return result;
        }
    }