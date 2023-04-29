namespace SudokuSolver.Logging
{
    internal class ErrorMessage: Message
    {
        public ErrorMessage(string message):base(message)
        {
            this.message = "[Error] " + this.message;
        }
    }
}
