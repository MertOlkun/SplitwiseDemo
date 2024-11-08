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


public class Spending
{
    public string WhoPaid { get; set; }
    public string SpendingName { get; set; }
    public int Amount { get; set; }
    public Dictionary<string, int> Payments { get; set; }

    public Spending(string whoPaid, string spendingName, int amount, Dictionary<string, int> payments)
    {
        Amount = amount;
        SpendingName = spendingName;
        WhoPaid = whoPaid;
        Payments = payments;
    }

    public void ShowUsers()
    {
        foreach (KeyValuePair<string, int> x in Payments)
        {
            Console.WriteLine($"{x.Key} {x.Value}");
        }
    }

    public override string ToString()
    {
        return $"Amount: {Amount}, Spending: {SpendingName}, Who paid: {WhoPaid}";
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

public class SpendingList
{
    public List<Spending> spendings = new List<Spending>();

    public void AddSpendings(Spending spending)
    {
        spendings.Add(spending);
    }

    public void ShowSpendings()
    {
        for (int i = 0; i < spendings.Count; i++)
        {
            Console.WriteLine(spendings[i].ToString());
        } 
    }
}