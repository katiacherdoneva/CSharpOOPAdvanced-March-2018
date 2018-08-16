using Models.Interfaces;

namespace Models.Factories
{
    internal class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
            : base(layout, errorLevel)
        {
            this.logFile = logFile;
        }
       
        public override void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {logFile.Size}";
        }
    }
}