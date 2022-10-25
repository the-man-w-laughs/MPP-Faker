public class GeneratorContext : IGeneratorContext
{
    public GeneratorContext(Random random, IFaker faker)
    {
        this.Random = random;
        Faker = faker;
    }

    public string Alphabet { get; } = "abcdefghijklmnopqrstuvwxyz";
    public Random Random { get; }
    public IFaker Faker { get; }
}