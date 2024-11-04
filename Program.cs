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

        System.Console.WriteLine("Press: 1 to add user.\nPress: 2 to look at users\nPress: 3 to add Spending\nPress: 4 to look at payment list");

        while (true)
        {

            int a = Convert.ToInt32(Console.ReadLine());

            //* ADD USER
            if (a == 1)
            {
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
                string? userSpending = Convert.ToString(Console.ReadLine());

                while (true)
                {

                    if (userSpending != null)
                    {
                        string selectedUser = userList.Listsss();
                        int userAmount = Convert.ToInt32(Console.ReadLine());

                        var dict = new Dictionary<string, int>();

                        dict.Add(selectedUser, userAmount);



        SpendingPlace post = new SpendingPlace(selectedUser, userSpending, userAmount, dict);


                    }
                    else
                    {
                        System.Console.WriteLine("Spending cannot be null.");
                        break;
                    }
                }


            }
            /*
            //* VIEW SPENDING LIST
                    else if (a == 4)
                    {

                    }*/
        }
    }
}
