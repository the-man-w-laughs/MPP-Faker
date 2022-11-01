public interface IValueGenerator
{
    bool CanGenerate(Type t);
    object Generate(Type typeToGenerate, IGeneratorContext context);
}