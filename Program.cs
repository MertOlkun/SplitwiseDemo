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
                Console.WriteLine("What was it spent on");
                string? userSpending = Convert.ToString(Console.ReadLine());

                if (userSpending != null)
                {
                    List<int> payments = new List<int>();

                    var dict = new Dictionary<string, int>();

                    while (true)
                    {
                        string selectedUser = userList.SelectedUser();

                        Console.WriteLine("How much was spent");
                        int userAmount = Convert.ToInt32(Console.ReadLine());
                        payments.Add(userAmount);
                        System.Console.WriteLine(payments[0]);
                        System.Console.WriteLine(payments.Count());
                        int firsPayment = payments[0];
                        
                        int totalDebt = 0;

                        for (int i = 0; i < payments.Count(); i++)
                        {
                            int debt = payments[i];
                            totalDebt += debt;
                        }
                        System.Console.WriteLine(totalDebt);

                        if (totalDebt-firsPayment > firsPayment)
                        {
                            Console.WriteLine("Debts cannot exceed payment.");
                            break;
                        }


                        dict.Add(selectedUser, userAmount);

                        SpendingPlace post = new SpendingPlace(selectedUser, userSpending, userAmount, dict);

                        spendingList.AddSpendings(post);
                        spendingList.ShowSpendings();

                        Console.WriteLine("Choose a new action ");


                    }
                }
                else
                {
                    Console.WriteLine("Spending cannot be null.");
                    break;
                }
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
