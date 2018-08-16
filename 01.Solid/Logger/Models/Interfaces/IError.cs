namespace Models.Interfaces
{
    using System;

    public interface IError : IAppender
    {
        DateTime DateTime { get; }

        string Message { get; }
    }
}