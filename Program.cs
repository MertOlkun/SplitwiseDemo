using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Tar;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

class Program
{

    static void Main(string[] args)
    {


        UserList userList = new UserList();

        SpendingList spendingList = new SpendingList();

        Console.WriteLine("Press: 1 to add user.\nPress: 2 to look at users\nPress: 3 to add Spending\nPress: 4 to look at payment list");

        while (true)
        {

            int a = Convert.ToInt32(Console.ReadLine());

            //* ADD USER
            if (a == 1)
            {
                Console.WriteLine("Enter a name: ");
                string? name = Convert.ToString(Console.ReadLine());

                if (name != null)
                {
                    userList.AddUser(new User(name));
                }
                Console.WriteLine("Choose a new action ");
            }
            //* GET USER
            else if (a == 2)
            {
                userList.GetUser();
                Console.WriteLine("Choose a new action ");
            }
            //* ADD SPENDING 
            else if (a == 3)
            {
                List<string> firstPayment = new List<string>();

                Console.WriteLine("What was it spent on");
                string? userSpending = Convert.ToString(Console.ReadLine());

                if (userSpending == null)
                {
                    Console.WriteLine("Spending cannot be null.");
                    break;
                }

                List<int> payments = new List<int>();
                var dict = new Dictionary<string, int>();
                string FirstUser = userList.SelectedUser();
                Console.WriteLine("How much was spent");
                int WhoPaidSpending = Convert.ToInt32(Console.ReadLine());
                

                for (int i = 0; i < userList.GetCount(); i++)
                {
                    string debtorUser = userList.SelectedUser();
                   /*  System.Console.WriteLine(userList.GetCount()); */

                    int debtorPaid = Convert.ToInt32(Console.ReadLine());


                    payments.Add(debtorPaid);
                    /* System.Console.WriteLine(payments[0]);
                    System.Console.WriteLine(payments.Count()); */
                    int firsPayment = payments[0];

                    int totalDebt = 0;

                    for (int s = 0; s < payments.Count(); s++)
                    {
                        int debt = payments[s];
                        totalDebt += debt;
                    }
                    System.Console.WriteLine(totalDebt);

                    if (totalDebt - firsPayment > firsPayment)
                    {
                        Console.WriteLine("Debts cannot exceed payment.");
                        break;
                    }


                    dict.Add(debtorUser, debtorPaid);
                }
                    

                    Spending post = new Spending(FirstUser, userSpending, WhoPaidSpending, dict);

                    spendingList.AddSpendings(post);
                    spendingList.ShowSpendings();

                    Console.WriteLine("Choose a new action ");

            }
            //* VIEW SPENDING LIST
            else if (a == 4)
            {
                spendingList.ShowSpendings();

                Console.WriteLine("Choose a new action ");
            }
        }
    }
}
