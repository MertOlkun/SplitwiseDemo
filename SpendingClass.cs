using System;
using System.Collections.Generic;
using System.Runtime;
using System.Xml.Linq;
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
    public string xd {get;set;}
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