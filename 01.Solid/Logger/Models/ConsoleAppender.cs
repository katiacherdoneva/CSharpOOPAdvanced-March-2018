using Models.Interfaces;
using System;

namespace Models
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
            : base(layout, level)
        {
        }
        
        public override void Append(IError error)
        {
            string formatError = this.Layout.FormatError(error);
            Console.WriteLine(formatError);
            this.MessagesAppended++;
        }
    }
}
