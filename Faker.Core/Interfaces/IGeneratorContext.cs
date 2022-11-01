public interface IGeneratorContext
{
    string Alphabet { get; }
    Random Random { get; }
    IFaker Faker { get; }

}