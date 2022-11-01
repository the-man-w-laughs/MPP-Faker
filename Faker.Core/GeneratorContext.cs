public class GeneratorContext : IGeneratorContext
{
    public GeneratorContext(Random random, IFaker faker)
    {
        this.Random = random;
        Faker = faker;
    }

    public string Alphabet { get; } = "abcdefghijklmnopqrstuvwxyz";
    public Random Random { get; }

    // to initialize first list's element
    // link to the Faker that contains this Context
    public IFaker Faker { get; }
}