using System;
using System.Collections.Generic;

public class RepoTwitter : IRepoTwitter
{
    private List<string> messages;
    
    public RepoTwitter()
    {
        this.messages = new List<string>();
    }

    public void GetMessage(string message)
    {
        this.messages.Add(message);
    }
}

