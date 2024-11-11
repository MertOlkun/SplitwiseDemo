using System;
using System.Collections.Generic;
using System.Runtime;

public class User
{
    public string Name { get; set; }

    public User(string name)
    {
        Name = name;
    }
}


public class UserList
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }
    public string SelectedUser()
    {
        int a = 0;
        foreach (var item in users)
        {
            Console.WriteLine($"{users.IndexOf(item)}: {item.Name}");
            if (a > users.IndexOf(item))
            {
                break;
            }
            a++;
        }
        Console.WriteLine("Select one of user:");
        int selectedNumber = Convert.ToInt32(Console.ReadLine());
        string selectedUser = users[selectedNumber].Name;
        Console.WriteLine(selectedUser);
        return selectedUser;
    }


    public void GetUser()
    {
        foreach (var item in users)
        {
            Console.WriteLine($"{users.IndexOf(item)}: {item.Name}");
        }
    }

    public int GetCount()
    {
        int a = users.Count();
        return a;
    }
}
