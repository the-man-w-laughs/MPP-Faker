// using System.Reflection;

// Contains
// 'Generate' method that returns specific value
// '_generators' field that keeps all generators
// '_config' object that keeps all custom generators

public class GeneratorService : IGeneratorService
{
    private List<IValueGenerator> _generators;
    private IGeneratorConfig _config;

    public GeneratorService(IGeneratorConfig config)
    {
        InitializeGenerators();
        _config = config;
    }

    public GeneratorService()
    {
        InitializeGenerators();
    }

    public object Generate(Type type, IGeneratorContext context, string name = null)
    {
        if (name != null && _config != null)
        {
            var configGenerator = _config.GetGeneratorByName(name);
            if (configGenerator != null)
            {
                return configGenerator.Generate(type, context);
            }
        }
        var generator = _generators.SingleOrDefault(x => x.CanGenerate(type));
        if (generator == null)
        {
            throw new UnsupportedTypeException();
        }
        var result = generator.Generate(type, context);
        return result;
    }

    private void InitializeGenerators()
    {
        _generators = new List<IValueGenerator>();
        _generators.Add(new BooleanGenerator());
        _generators.Add(new ByteGenerator());
        _generators.Add(new CharGenerator());
        _generators.Add(new DateTimeGenerator());
        _generators.Add(new DecimalGenerator());
        _generators.Add(new DoubleGenerator());
        _generators.Add(new FloatGenerator());
        _generators.Add(new IntGenerator());
        _generators.Add(new ListGenerator());
        _generators.Add(new LongGenerator());
        _generators.Add(new SByteGenerator());
        _generators.Add(new ShortGenerator());
        _generators.Add(new StringGenerator());
        _generators.Add(new UriGenerator());

        // _generators = new List<IValueGenerator>();
        // var assembly = Assembly.GetExecutingAssembly();
        // var types = assembly.GetTypes();
        // foreach (var type in types)
        // {
        //     if (type.IsAssignableTo(typeof(IValueGenerator)) && type.IsClass)
        //     {
        //         var generator = Activator.CreateInstance(type);
        //         _generators.Add((IValueGenerator)generator);
        //     }
        // }
    }
}