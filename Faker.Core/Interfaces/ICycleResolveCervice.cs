public interface ICycleResolveService
    {
        bool Contains(Type t);
        void Add(Type t);
        void Remove(Type t);
        void Clear();
    }