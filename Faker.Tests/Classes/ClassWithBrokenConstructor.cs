public class ClassWithBrokenConstructor : Class
{
    public string Prop1 { get; }
    public string Prop2 { get; }
    public ClassWithBrokenConstructor(string prop1)
    {
        Prop1 = prop1;
    }

    public ClassWithBrokenConstructor(string prop1, string prop2)
    {
        throw new Exception("To be or not to be. Not to be.");
    }
}