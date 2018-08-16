using System.Collections.Generic;

public interface IUser
{
    string Name { get; }

    void AddCategory(ICategory category);

    void RemoveCategory(ICategory category);
}