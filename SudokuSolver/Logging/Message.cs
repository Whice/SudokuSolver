namespace SudokuSolver.Logging
{
    internal abstract class Message
    {
        public string message { get; protected set; }
        public Message(string message)
        {
            this.message = message + "\n\n";
        }
    }
}
