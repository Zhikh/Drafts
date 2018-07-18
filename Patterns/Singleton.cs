namespace Drafts.Patterns
{
    public sealed class DoubleCheckedLockSingleton
    {
        private static volatile DoubleCheckedLockSingleton _instance;

        private static readonly object _syncRoot = new object();

        DoubleCheckedLockSingleton(){ }

        public static DoubleCheckedLockSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleCheckedLockSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    public sealed class LazyFieldInitSingleton
    {
        private LazyFieldInitSingleton() { }

        public static LazyFieldInitSingleton Instance
        {
            get { return Nested._instance; }
        }

        private static class Nested
        {
            public static readonly LazyFieldInitSingleton _instance =
            new LazyFieldInitSingleton();
        }
    }
}
