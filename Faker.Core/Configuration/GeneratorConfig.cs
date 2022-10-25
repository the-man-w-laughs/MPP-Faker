using System.Linq.Expressions;

public class GeneratorConfig : IGeneratorConfig
{
    Dictionary<string, IValueGenerator> _generatorsByName = new Dictionary<string, IValueGenerator>();
    public void Add<A, B, C>(Expression<Func<A, B>> expression) where C : IValueGenerator
    {
        MemberExpression member = expression.Body as MemberExpression;
        if (member == null)
        {
            throw new Exception("Expression body should be property or field");
        }
        var generator = (C)Activator.CreateInstance(typeof(C), new object[] { });
        _generatorsByName.Add(member.Member.Name, generator);
    }

    public IValueGenerator GetGeneratorByName(string name)
    {
        return _generatorsByName.GetValueOrDefault(name);
    }
}
