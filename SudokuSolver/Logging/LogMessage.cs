namespace SudokuSolver.Logging
{
    internal class LogMessage: Message
    {
        public LogMessage(string message) : base(message)
        {
            this.message = "[Log] " + message;
        }
    }
}
