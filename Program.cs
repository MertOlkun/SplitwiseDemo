﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Tar;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

class Program
{

    static void Main(string[] args)
    {

        UserList userList = new UserList();

        SpendingList spendingList = new SpendingList();

        var dict = new Dictionary<string, int>();

        while (true)
        {
            Console.WriteLine("\nChoose a new action:\n\nPress: 1 to add user.\nPress: 2 to look at users\nPress: 3 to add Spending\nPress: 4 to look at payment list");
            int a = Convert.ToInt32(Console.ReadLine());

            //* ADD USER
            if (a == 1)
            {
                Console.WriteLine("\nEnter a name: ");
                string? name = Convert.ToString(Console.ReadLine());

                if (name != null)
                {
                    userList.AddUser(new User(name));
                }
                
            }
            //* GET USER
            else if (a == 2)
            {
                userList.GetUser();
                
            }
            //* ADD SPENDING 
            else if (a == 3)
            {
                if (userList.GetCount() == 1)
                {
                    System.Console.WriteLine("You need to add at least 2 users.");
                    
                }
                List<string> firstPayment = new List<string>();

                Console.WriteLine("\nWhat was it spent on");
                string? userSpending = Convert.ToString(Console.ReadLine());

                if (userSpending == null)
                {
                    Console.WriteLine("\nSpending cannot be null.");
                    break;
                }

                List<int> payments = new List<int>();
                
                Console.WriteLine("\nWho paid the expense?");
                string FirstUser = userList.SelectedUser();

                Console.WriteLine("\nHow much was spent?");
                int WhoPaidSpending = Convert.ToInt32(Console.ReadLine());
                

                for (int i = 1; i < userList.GetCount(); i++)
                {
                    Console.WriteLine("\nAdd payment amount for each user.");
                    string debtorUser = userList.SelectedUser();

                    Console.WriteLine("\nHow much did the chosen person pay?");
                    int debtorPaid = Convert.ToInt32(Console.ReadLine());

                    payments.Add(debtorPaid);

                    int totalDebt = 0;
                    for (int s = 0; s < payments.Count(); s++)
                    {
                        int debt = payments[s];
                        totalDebt += debt;
                    }

                    if (totalDebt > WhoPaidSpending)
                    {
                        Console.WriteLine("\nDebts cannot exceed payment.");
                       break;
                    }
                    dict.Add(debtorUser, debtorPaid);
                }
                
                    

                    Spending post = new Spending(FirstUser, userSpending, WhoPaidSpending, dict);

                    spendingList.AddSpendings(post);
                    spendingList.AddSpendingList();

                  /*   System.Console.WriteLine(post);
                    string json = JsonConvert.SerializeObject(post, Formatting.Indented);

                    File.AppendAllText(filePath, json + Environment.NewLine); */

            }
            //* VIEW SPENDING LIST
            else if (a == 4)
            {
                spendingList.GetSpendingList();
                spendingList.ShowSpendings();
                foreach (KeyValuePair<string, int> item in dict)
                {
                 Console.WriteLine($"Name: {item.Key} Payment: {item.Value}");   
                }

                
                
            }
        }
    }
}
