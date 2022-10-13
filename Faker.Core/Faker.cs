public class Faker : IFaker
{
    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }

    // Может быть вызван изнутри Faker, из IValueGenerator (см. ниже) или пользователем
    public object Create(Type t)
    {
        throw new NotImplementedException();
        // Процедура создания и инициализации объекта.
    }
}