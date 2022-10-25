using System.Reflection;

public class ListGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>);
    }
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        var argument = typeToGenerate.GetGenericArguments().First();
        var generic = typeof(List<>).MakeGenericType(argument);
        MethodInfo method = typeof(Faker).GetMethod("Create")!.MakeGenericMethod(new Type[] { argument });
        var result = method.Invoke(context.Faker, new object[] { });
        // TODO: что за new object[]?

        var list = Activator.CreateInstance(generic);
        var addMethod = generic.GetMethod("Add");
        addMethod!.Invoke(list, new object[] { result! });
        return list!; 
    }
}