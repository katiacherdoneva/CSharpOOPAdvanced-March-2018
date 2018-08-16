public interface ICategory
{
    string Name { get; }

    void AddChild(ICategory child);

    void MoveUsersToParent();

    void RemoveChild(string name);

    void AddUser(IUser user);

    void SetParent(ICategory category);
}