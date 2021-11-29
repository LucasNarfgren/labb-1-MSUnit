﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KoalaBankApp
{
    public class Bank
    {

        public void Run()
        {

            List<Account> Accounts = new List<Account>();

            List<BankAccount> BAList1 = new List<BankAccount>();
            BankAccount BAccount1 = new BankAccount("Privat-Konto", 25000);
            Account Account1 = new Account("Lukke", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1, true);


            List<BankAccount> BAList2 = new List<BankAccount>();
            BankAccount BAccount2 = new BankAccount("Privat-Konto", 25000);
            Account Account2 = new Account("Ludde", "hejhej123", "Ludwig", "Oleby", "Ludwig1337@live.se", BAList2, false);

            Account1.Useraccount.Add(BAccount1);
            Accounts.Add(Account1);

            Account2.Useraccount.Add(BAccount2);
            Accounts.Add(Account2);

            login inlog = new login();
            inlog.userLogin(Accounts);



        }

           public static void userMenu(List<Account> Accounts,Account ActiveUser)
            {
                // TESTNINGS MENY!
                int menu = 0;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen till KoalaBanken!");
                    try
                    {
                        Console.WriteLine("1. Överför Pengar");
                        Console.WriteLine("2. Skriv ut Konton");
                        Console.WriteLine("3. Sök Användare");
                        Console.WriteLine("4. Logga ut");
                        menu = int.Parse(Console.ReadLine());

                        switch (menu)
                        {
                            
                            case 1:

                                break;
                            case 2:
                            Console.Clear();
                            Console.WriteLine(ActiveUser.Firstname);
                            Console.WriteLine(ActiveUser.Lastname);
                            Console.WriteLine(ActiveUser.Email);
                            foreach (var item in ActiveUser.Useraccount)
                            {
                                Console.WriteLine("Name: {0}",item.AccountName);
                                Console.WriteLine("Balance: {0}",item.Balance);
                            }



                            Console.ReadKey();
                                break;
                            case 3:

                                Console.Write("Skriv in ett Giltligt användarnamn: ");
                                string userinput = Console.ReadLine();

                                Account Check = Accounts.Find(c => c.Username == userinput);
                                if (Check == null)
                                {
                                    Console.WriteLine("Användare Existerar inte.");
                                }
                                else
                                {
                                    Console.WriteLine("Användare: {0} finns i databasen.", Check.Username);
                                }
                                Console.ReadKey();
                                break;
                            case 4:
                            login logout = new login();
                            logout.userLogin(Accounts);
                            break;

                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                } while (true);

                int menyChoice = 0;
                try
                {
                    menyChoice = Int32.Parse(Console.ReadLine());
                    if (menyChoice > 5) // to high number
                    {
                        Console.WriteLine("please enter a number that is a option");
                    }
                    else if (menyChoice < 1) // to low number
                    {
                        Console.WriteLine("please enter a number that is a option");
                    }
                    else //Purfect
                    {

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please input a number instead");
                }
                switch (menyChoice)
                {
                    case 1:
                        Console.WriteLine(""); // Placeholder
                        break;
                    case 2:
                        Transfer Transaction = new Transfer();
                        Transaction.TransferMenyOptions();
                        break;
                    case 3:
                        Console.WriteLine(""); // Placeholder
                        break;
                    case 4:
                        Console.WriteLine(""); // placeholder
                        break;
                    case 5:
                        Console.WriteLine("Logout");
                        //MenyAcitve = false;
                        break;
                }
            }
    }
}
