using System;
using System.Collections.Generic;

public class Client : IClient
{
    private IWritter writter;

    public Client(IRepoTwitter repoTwitter, IWritter writter)
    {
        this.RepoTwitter = repoTwitter;
        this.writter = writter;
    }

    public IRepoTwitter RepoTwitter { get; }

    public void SendMessageOfTweet(string message)
    {
        this.RepoTwitter.GetMessage(message);

        PrintMessage(message);
    }

    public void PrintMessage(string message)
    {
       this.writter.WriteLine(message);
    }
}

