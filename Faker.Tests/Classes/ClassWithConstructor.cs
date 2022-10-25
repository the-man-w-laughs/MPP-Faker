public class ClassWithConstructor : Class
    {
        public string PrivateProperty { get; }
        public ClassWithConstructor(string privateProperty)
        {
            PrivateProperty = privateProperty;
        }
    }