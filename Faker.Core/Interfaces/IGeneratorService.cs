public interface IGeneratorService
{
    object Generate(Type type, IGeneratorContext context, string? name = null);
}