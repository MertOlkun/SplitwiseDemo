using System;
using System.Collections.Generic;
using System.Runtime;

public class User
{
    public string Name {get;set;}

    public User(string name)
    {
        Name = name;
    }
    

    
}


public class SpendingPlace
{
    public string WhoPaid {get;set;}
    public string Spending {get;set;}
    public int Amount {get; set;}

    public SpendingPlace(string whoPaid, string spending, int amount)
    {
        Amount = amount;
        Spending = spending;
        WhoPaid = whoPaid;
    }

    public Dictionary<string,int> myDict = new Dictionary<string, int>();

    public void AddToDictionary()
    {
        myDict.Add(WhoPaid,Amount);
    }
    public void ShowUsers()
    {
        foreach (KeyValuePair <string, int> x in myDict)
        {
            System.Console.WriteLine($"{x.Key} {x.Value}");
        }
    }
}
/*
public class SpendingDictionary
{
    public Dictionary<string,int> dictionary = new Dictionary<string,int>();
    public void AddToDictionary()
    {
        dictionary.Add()
    }
}
*/
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
            Console.WriteLine($"{users.IndexOf(item)}: {item.Name}");
        }
    }
}