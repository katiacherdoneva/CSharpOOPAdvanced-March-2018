using Models.Interfaces;
using System;

namespace Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public void Append(IError error)
        {
            throw new NotImplementedException();
        }
    }
}
