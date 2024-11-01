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

    Dictionary<string,int> myDict = new Dictionary<string, int>();

    public void AddToDictionary()
    {
        myDict.Add(WhoPaid,Amount);
        foreach (var item in myDict)
        {
            System.Console.WriteLine(item);
        }
    }
}
