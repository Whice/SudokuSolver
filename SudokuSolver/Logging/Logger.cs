using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SudokuSolver.Logging
{
    internal class Logger
    {
        public static RichTextBox messagesTextBox;
        private static StringBuilder sb = new StringBuilder();
        private static void MessagesTextUpdate()
        {
            sb.Clear();
            foreach(var message in messages)
            {
                sb.Append(message.message);
            }
            messagesTextBox.Text = sb.ToString();
        }
        public static void ClearTextBox()
        {
            messagesTextBox.Clear();
        }
        private static List<Message> messages = new List<Message>();
        public static void Log(string message)
        {
            messages.Add(new LogMessage(message));
            MessagesTextUpdate();
        }
        public static void Error(string message)
        {
            messages.Add(new ErrorMessage(message));
            MessagesTextUpdate();
        }

    }
}
