using System.Linq.Expressions;

public interface IGeneratorConfig
{
    void Add<A, B, C>(Expression<Func<A, B>> expression) where C : IValueGenerator;
    IValueGenerator GetGeneratorByName(string name);
}