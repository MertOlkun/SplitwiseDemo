using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Newtonsoft.Json;


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

public class SpendingList
{
    public List<Spending> Spendings = new List<Spending>();

     public SpendingList(List<Spending> spendings)
    {
        Spendings = spendings;
    } 
    
    public void AddSpendings(Spending spending)
    {
        Spendings.Add(spending);
    }

    public void ShowSpendings()
    {
        foreach (var item in Spendings)
        {
            System.Console.WriteLine(item);
            foreach (var x in item.Payments)
            {
                System.Console.WriteLine(x);
            }
            
        }

        
    }
}