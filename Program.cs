using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;

/*
kullanıcı ekle
harcama ekle
kim ödedi sor
kimler ne kadar verdi sor
*/

class Program
{
    static void Main(string[]args)
    {
        Dictionary<string, int> myDict = new Dictionary<string, int>();
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
        string selectedUser = userList.Listsss();
        int userAmount = Convert.ToInt32(Console.ReadLine());
        myDict.Add(selectedUser,userAmount);
        

        
        }
//* WIEV SPENDING LIST
        else if (a == 4)
        {
        System.Console.WriteLine("List of ");
        foreach 
        ( 
        KeyValuePair <string, int> item in myDict)
        {
        
        System.Console.WriteLine($"{item.Key} {item.Value}");
        }

        }

        }
    }
}