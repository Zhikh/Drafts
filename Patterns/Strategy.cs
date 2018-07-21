namespace Patterns
{
    // Encapsulates a specific behavior with the ability to replace it
    public interface IStrategy
    {
        void Algorithm();
    }

    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.Algorithm();
        }
    }
}
