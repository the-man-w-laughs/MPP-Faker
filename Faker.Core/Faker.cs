using System.Reflection;

public class Faker : IFaker
{
    private IGeneratorService _generatorService;
    private ICycleResolveService _cycleResolveService;
    private IGeneratorContext _context;

    public Faker(IGeneratorService generatorService, ICycleResolveService cycleResolveService)
    {
        _generatorService = generatorService;
        _context = new GeneratorContext(new Random(), this);
        _cycleResolveService = cycleResolveService;
    }

    public T Create<T>()
    {
        var type = typeof(T);
        return (T)Create(type);
    }

    private object Create(Type t, string? name = null)
    {
        try
        {
            var result = _generatorService.Generate(t, _context, name);
            return result;
        }
        catch (UnsupportedTypeException)
        {
            var obj = InitializeUserType(t);
            InitializeFields(obj);
            InitializeProperties(obj);
            return obj;
        }
    }

    private object InitializeUserType(Type type)
    {
        var ctors = type.GetConstructors().OrderByDescending(x => x.GetParameters().Count());
        foreach (var ctor in ctors)
        {
            try
            {
                var result = InitializeUserTypeViaConstructor(ctor);
                return result;
            }
            catch
            {
                System.Console.WriteLine("Exception while initializing type");
            }
        }
        var defaultValue = GetDefaultValue(type);
        return defaultValue;
    }

    private object InitializeUserTypeViaConstructor(ConstructorInfo ctor)
    {
        var parameters = ctor.GetParameters();
        var initParameters = new List<object>();
        foreach (var param in parameters)
        {
            if (_cycleResolveService.Contains(param.ParameterType))
            {
                var defaultValue = GetDefaultValue(param.ParameterType);
                initParameters.Add(defaultValue);
            }
            else
            {
                _cycleResolveService.Add(param.ParameterType);
                var initializedParam = Create(param.ParameterType, param.Name.FirstLetterToUpper());
                _cycleResolveService.Remove(param.ParameterType);
                initParameters.Add(initializedParam);
            }
        }
        var result = ctor.Invoke(initParameters.ToArray());
        return result;
    }

    private void InitializeFields(object obj)
    {
        var type = obj.GetType();
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            if ((!field.IsPublic) ||
                (!IsDefault(field.GetValue(obj), field.FieldType)))
            {
                continue;
            }

            if (_cycleResolveService.Contains(field.FieldType))
            {
                var defaultValue = GetDefaultValue(field.FieldType);
                field.SetValue(obj, defaultValue);
            }
            else
            {
                _cycleResolveService.Add(field.FieldType);
                var result = Create(field.FieldType, field.Name);
                _cycleResolveService.Remove(field.FieldType);
                field.SetValue(obj, result);
            }
        }
    }

    private void InitializeProperties(object obj)
    {
        var type = obj.GetType();
        var props = type.GetProperties();
        foreach (var prop in props)
        {

            if ((prop.GetSetMethod() == null)
                || (!IsDefault(prop.GetValue(obj), prop.PropertyType)))
            {
                continue;
            }

            if (_cycleResolveService.Contains(prop.PropertyType))
            {
                var defaultValue = GetDefaultValue(prop.PropertyType);
                prop.SetValue(obj, defaultValue);
            }
            else
            {
                _cycleResolveService.Add(prop.PropertyType);
                var result = Create(prop.PropertyType, prop.Name);
                _cycleResolveService.Remove(prop.PropertyType);
                prop.SetValue(obj, result);
            }
        }
    }

    private object GetDefaultValue(Type t)
    {
        if (t.IsValueType)
            // Для типов-значений вызов конструктора по умолчанию даст default(T).
            return Activator.CreateInstance(t);
        else
            // Для ссылочных типов значение по умолчанию всегда null.
            return null;
    }

    private bool IsDefault(object obj, Type t)
    {
        if (t.IsValueType)
        {
            var instance = Activator.CreateInstance(t);
            return obj.Equals(instance);
        }
        else
        {
            return obj == null;
        }
    }
}