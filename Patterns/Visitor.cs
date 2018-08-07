namespace Patterns
{
    public interface IVisitor
    {
        void Visit(ExceptionLogEntry exceptionLogEntry);
    }

    public abstract class LogEntry
    {
        public abstract void Accept(IVisitor logEntryVisitor);
    }

    public class ExceptionLogEntry : LogEntry
    {
        public override void Accept(IVisitor logEntryVisitor)
        {
            logEntryVisitor.Visit(this);
        }
    }

    public class DatabaseLogSaver : IVisitor
    {
        public void SaveLogEntry(LogEntry logEntry)
        {
            logEntry.Accept(this);
        }

        void IVisitor.Visit(ExceptionLogEntry exceptionLogEntry)
        {
            SaveException(exceptionLogEntry);
        }
        
        private void SaveException(ExceptionLogEntry logEntry) {}
    }
}
