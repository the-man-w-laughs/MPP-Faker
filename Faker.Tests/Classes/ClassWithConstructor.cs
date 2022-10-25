public class ClassWithConstructor : Class
{
    public ClassWithConstructor(string privateProperty1)
    {
        PrivateProperty1 = privateProperty1;
    }
    public ClassWithConstructor(string privateProperty1, string privateProperty2)
    {
        PrivateProperty1 = privateProperty1;
        PrivateProperty2 = privateProperty2;
    }
    public string PrivateProperty1 { get; }
    public string PrivateProperty2 { get; }
}