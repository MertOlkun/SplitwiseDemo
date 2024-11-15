using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Tar;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

class Program
{

    static void Main(string[] args)
    {
        List<int> payments = new List<int>();

        userlist userlist = new userlist();

        string filePath = "Spendings_payments.txt";

        string data = File.ReadAllText(filePath);

        List<Spending>? getSpendingJson = JsonConvert.DeserializeObject<List<Spending>>(data);

        SpendingList spendingList = new SpendingList(getSpendingJson);


        while (true)
        {
            var dict = new Dictionary<string, int>();
            Console.WriteLine("\nChoose a new action:\n\nPress: 1 to add user.\nPress: 2 to look at users\nPress: 3 to add Spending\nPress: 4 to look at payment list");
            int a = Convert.ToInt32(Console.ReadLine());

            //* ADD USER
            if (a == 1)
            {
                Console.WriteLine("\nEnter a name: ");
                string? name = Convert.ToString(Console.ReadLine());

                if (name != null)
                {
                    userlist.AddUser(new User(name));
                }

            }

            //* GET USER
            else if (a == 2)
            {
                userlist.GetUser();

            }

            //* ADD SPENDING 
            else if (a == 3)
            {
                if (userlist.GetCount() == 1)
                {
                    Console.WriteLine("You need to add at least 2 users.");

                }
                List<string> firstPayment = new List<string>();

                Console.WriteLine("\nWhat was it spent on");
                string? userSpending = Convert.ToString(Console.ReadLine());

                if (userSpending == null)
                {
                    Console.WriteLine("\nSpending cannot be null.");
                    break;
                }

                Console.WriteLine("\nWho paid the expense?");
                string FirstUser = userlist.SelectedUser();

                Console.WriteLine("\nHow much was spent?");
                int WhoPaidSpending = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i < userlist.GetCount(); i++)
                {
                    Console.WriteLine("\nAdd payment amount for each user.");
                    string debtorUser = userlist.SelectedUser();

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

                string addSpendingJson = JsonConvert.SerializeObject(spendingList);
                File.WriteAllText(filePath, addSpendingJson);

            }

            //* VIEW SPENDING LIST
            else if (a == 4)
            {
                spendingList.ShowSpendings();
                Console.WriteLine(spendingList);
            }
        }
    }
}
