//using System.Collections.Generic;
//using System.Linq;

//public class User : IUser
//{
//    private string name;
//    private List<ICategory> categories;

//    public User(string name)
//    {
//        this.name = name;
//        this.categories = new List<ICategory>();
//    }

//    public string Name
//    {
//        get
//        {
//            return this.name;
//        }
//        private set
//        {
//            this.name = value;
//        }
//    }

//    public void AddCategory(ICategory category)
//    {
//        this.categories.Add(category);
//    } 

//    public void RemoveCategory(ICategory category)
//    {
//        this.categories.Remove(category);

//        if (category.parent != null)
//        {
//            this.categories.Add(category.parent);
//        }
//    }
//}