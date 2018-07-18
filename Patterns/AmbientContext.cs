namespace Patterns
{
    public interface IWorker
    {
        void DoSmth();
    }

    internal class Worker : IWorker
    {
        public void DoSmth() { }
    }

    public class GlobalWorker
    {
        private static IWorker _someWorker = new Worker();
        
        public static IWorker Worker
        {
            get
            {
                return _someWorker;
            }
            internal set
            {
                _someWorker = value;
            }
        }
    }
}
