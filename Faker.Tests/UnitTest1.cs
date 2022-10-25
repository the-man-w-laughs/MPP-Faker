public class UnitTest1
{
    [Fact]
    public void ByteGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<byte>();
        Assert.NotEqual(Activator.CreateInstance(typeof(byte)), result);
    }

    [Fact]
    public void CharGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<char>();
        Assert.NotEqual(Activator.CreateInstance(typeof(char)), result);
    }

    [Fact]
    public void DateTimeGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<DateTime>();
        Assert.NotEqual(Activator.CreateInstance(typeof(DateTime)), result);
    }

    [Fact]
    public void DecimalGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<decimal>();
        Assert.NotEqual(Activator.CreateInstance(typeof(decimal)), result);
    }

    [Fact]
    public void DoubleGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<double>();
        Assert.NotEqual(Activator.CreateInstance(typeof(double)), result);
    }

    [Fact]
    public void FloatGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<float>();
        Assert.NotEqual(Activator.CreateInstance(typeof(float)), result);
    }

    [Fact]
    public void IntegerGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<int>();
        Assert.NotEqual(Activator.CreateInstance(typeof(int)), result);
    }

    [Fact]
    public void ListGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<List<string>>();
        Assert.NotEqual(Activator.CreateInstance(typeof(List<string>)), result);
    }

    [Fact]
    public void LongGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<long>();
        Assert.NotEqual(Activator.CreateInstance(typeof(long)), result);
    }

    [Fact]
    public void ShortGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<short>();
        Assert.NotEqual(Activator.CreateInstance(typeof(short)), result);
    }

    [Fact]
    public void SignedByteGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<sbyte>();
        Assert.NotEqual(Activator.CreateInstance(typeof(sbyte)), result);
    }

    [Fact]
    public void StringGeneratorShouldReturnNotDefault()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<string>();
        Assert.NotEqual(Activator.CreateInstance(typeof(string)), result);
    }

    [Fact]
    public void ShouldFakeUserTypeWithCyclicDependency()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<Class>();
        Assert.NotNull(result);     
        Assert.NotEqual(Activator.CreateInstance(typeof(string)), result.FirstName);
        Assert.NotEqual(Activator.CreateInstance(typeof(string)), result.LastName);
        Assert.NotEqual(Activator.CreateInstance(typeof(int)), result.Age);
        Assert.NotNull(result.Children); 
        Assert.NotEqual(Activator.CreateInstance(typeof(string)), result.Children.FirstName);
        Assert.NotEqual(Activator.CreateInstance(typeof(string)), result.Children.LastName);
        Assert.NotEqual(Activator.CreateInstance(typeof(int)), result.Children.Age);
        Assert.Null(result.Children.Children);   

    }

    [Fact]
    public void ShouldNotGeneratePrivateSetters()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<ClassWithPrivateSetter>();
        Assert.NotNull(result.PrivateProperty);
        Assert.Equal(Activator.CreateInstance(typeof(int)), result.PrivateProperty);
    }

    [Fact]
    public void ShouldUseConstructorWithMoreParams()
    {
        // TODO: Что за тест?         
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<ClassWithConstructor>();
        Assert.NotNull(result);
        Assert.NotEqual(Activator.CreateInstance(typeof(int)), result.PrivateProperty);
    }

    [Fact]
    public void ShouldUseDifferentConstructors()
    {
        var generatorService = new GeneratorService();
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<ClassWithBrokenConstructor>();
        Assert.NotNull(result);
        Assert.NotEqual(Activator.CreateInstance(typeof(int)), result.Prop1);
        Assert.NotEqual(Activator.CreateInstance(typeof(int)), result.Prop2);
    }

    [Fact]
    public void ShouldUseGeneratorFromConfig()
    {
        var config = new GeneratorConfig();
        config.Add<Class, string, NameGenerator>(u => u.FirstName);
        var generatorService = new GeneratorService(config);
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<Class>();
        Assert.NotNull(result);
        Assert.Equal("Nazar", result.FirstName);
        Assert.NotEqual("Nazar", result.LastName);
    }

    [Fact]
    public void ShouldUseGeneratorFromConfigUsingConstructor()
    {
        var config = new GeneratorConfig();
        config.Add<ClassWithConstructor, string, NameGenerator>(u => u.PrivateProperty);
        var generatorService = new GeneratorService(config);
        var cycleResolveService = new CycleResolveService();
        Faker sut = new Faker(generatorService, cycleResolveService);
        var result = sut.Create<ClassWithConstructor>();
        Assert.NotNull(result);
        Assert.Equal("Nazar", result.PrivateProperty);
    }
}