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


public class SpendingPlace
{
    public string WhoPaid { get; set; }
    public string Spending { get; set; }
    public int Amount { get; set; }
    public Dictionary<string, int> Payments { get; set; }

    public SpendingPlace(string whoPaid, string spending, int amount, Dictionary<string, int> payments)
    {
        Amount = amount;
        Spending = spending;
        WhoPaid = whoPaid;
        Payments = payments;
    }

    public void ShowUsers()
    {
        foreach (KeyValuePair<string, int> x in Payments)
        {
            System.Console.WriteLine($"{x.Key} {x.Value}");
        }
    }
}


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
            if (a > users.IndexOf(item))
            {
                break;
            }
            a++;
        }
        System.Console.WriteLine("Select one of user:");
        int selectedNumber = Convert.ToInt32(Console.ReadLine());
        string selectedUser = users[selectedNumber].Name;
        System.Console.WriteLine(selectedUser);
        return selectedUser;

    }


    public void GetUser()
    {
        foreach (var item in users)
        {
            Console.WriteLine($"{users.IndexOf(item)}: {item.Name}");
        }
    }
}