using System.Collections.Generic;

public interface IClient
{
    IRepoTwitter RepoTwitter { get; }

    void SendMessageOfTweet(string message);

    void PrintMessage(string message);
}

