using System.Collections.Generic;

public interface IPeople
{
    void Add(string username, long id);

    void Remove(string username);

    long FindId(long id);

    string FindUsername(string username);

    Dictionary<string, long> Fetch();
}

