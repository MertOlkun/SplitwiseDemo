using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public class UserList
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }
    public string Listsss()
    {
        int a = 0;
        foreach (var item in users)
        {
            System.Console.WriteLine($"{users.IndexOf(item)}: {item.Name}");
            if (a >users.IndexOf(item))
            {
                break;
            }
            a++;
        }
        System.Console.WriteLine("Select one of user:");
        int selectedNumber = Convert.ToInt32(Console.ReadLine());
        string selectedUser = users[selectedNumber].Name;
        System.Console.WriteLine( selectedUser);
        return selectedUser;
        
    }

    
    public void GetUser()
    {
        foreach (var item in users)
        {
            System.Console.WriteLine(item.Name);
            System.Console.WriteLine(users.IndexOf(item));
        }
    }
}