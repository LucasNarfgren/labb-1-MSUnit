﻿using KoalaBankApp;
using System;
using System.Collections.Generic;
using System.Text;


public class Transfer
{
    //- [x]  Transfer between personal accounts
    //- [ ]  transfer to other users
    //- [ ]  User transaction log
    //- [ ]  (admin) Transactions dont happen instantly, limit it so it only happens every 15 mins

    public int maxAccounts = 5; //Max number of user accounts isnt decided yet.
    public int accountFrom = 0;
    public int accountTo = 0;
    public double amountTotransfer = 0;
    public double amountLeft = 0;
    public double amountAdd = 0;



    public void transferMenu(List<BankAccount> AccountsTransfer, User ActiveUserTransfer, List<User> Accounts)
    {
        Console.Clear();
        int menuChoice = 0;
        Console.WriteLine("1. Transfer between personal accounts \n2. Transfer to other users");
        menuChoice = Int32.Parse(Console.ReadLine());
        switch (menuChoice)
        {
            case 1:
                TransferMoney(AccountsTransfer, ActiveUserTransfer);
                break;
            case 2:
                transferToOtherUser(AccountsTransfer, ActiveUserTransfer, Accounts);
                break;
        }
    }


    public void TransferMoney(List<BankAccount> AccountsTransfer, User ActiveUserTransfer)
    {
        List<BankAccount> AllAccounts = AccountsTransfer.FindAll(a => a.Balance > 0);

        Console.Clear();
        bool transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("From what account you wanna move money from?");
            int nr = 1;
            foreach (BankAccount item in AllAccounts)
            {
                Console.WriteLine(nr + " " + item.Balance);
                nr++;
            }
            try
            {
                accountFrom = int.Parse(Console.ReadLine());
                if (accountFrom <= maxAccounts && accountFrom > 0)
                {
                    accountFrom = accountFrom - 1;
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a active account");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the accountnumber with a number/numbers");
            }
        }
        Console.Clear();
        transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("To what account you wanna move money to? dont pick the same as before");
            int nr = 1;
            foreach (BankAccount item in AllAccounts)
            {
                Console.WriteLine(nr + " " + item.Balance);
                nr++;
            }
            try
            {
                accountTo = int.Parse(Console.ReadLine());
                if (accountTo <= maxAccounts && accountTo != accountFrom && accountTo > 0)
                {
                    accountTo = accountTo - 1;
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("please enter a valid account and not the same account you wanna move from");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the accountnumber with a number/numbers");
            }
        }
        Console.Clear();
        transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("How much money would u like to transfer");
            try
            {
                amountTotransfer = double.Parse(Console.ReadLine());
                if (amountTotransfer > 0)
                {
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("You can not transfer a amount below zero or equal to");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the amount with numbers");
            }
        }
        //calc for amount to be removed and added
        Console.Clear();
        int coverage = 0;
        if (AllAccounts[accountTo].Balance >= amountTotransfer)
        {
            amountAdd = AllAccounts[accountTo].Balance;
            amountAdd = amountAdd + amountTotransfer;
            AllAccounts[accountTo].Balance = amountAdd;

            amountLeft = AllAccounts[accountFrom].Balance;
            amountLeft = amountLeft - amountTotransfer;
            AllAccounts[accountFrom].Balance = amountLeft;
            coverage = 1;
        }
        if (coverage == 1)
        {
            // The actual transfer
            BankAccount bankAccount1 = new BankAccount();
            bankAccount1.Balance = AllAccounts[accountFrom].Balance;
            BankAccount bankAccount2 = new BankAccount();
            bankAccount2.Balance = AllAccounts[accountTo].Balance;

            AllAccounts.RemoveAt(accountFrom);
            AllAccounts.Insert(accountFrom, bankAccount1);
            AllAccounts.RemoveAt(accountTo);
            AllAccounts.Insert(accountTo, bankAccount2);

            Console.WriteLine("New balance of the account money was moved from: " + AllAccounts[accountFrom].Balance);
            Console.WriteLine("New balance of the account money was moved to: " + AllAccounts[accountTo].Balance);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("The tranfer was terminated due to insufficent funds");
            Console.ReadKey();
        }
    }

    public void transferToOtherUser(List<BankAccount> ActiveUserTransfer, User ActiveUser, List<User> Accounts)
    {
        string accountToName = "";
        // LIST USER ACCOUNTS
        Console.Clear();
        List<BankAccount> AllAccounts = ActiveUserTransfer.FindAll(a => a.Balance > 0);
        int nr = 1;

        foreach (BankAccount item in AllAccounts)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(nr + ". Account name: {0} Balance: {1}", item.AccountName, item.Balance);
            Console.WriteLine("----------------------");
            nr++;
        }
        // SELECT USERACCOUNT
        bool transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("Select the account you want to transfer money from: ");
            try
            {
                accountFrom = int.Parse(Console.ReadLine());
                if (accountFrom <= maxAccounts && accountFrom > 0)
                {
                    accountFrom = accountFrom - 1;
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a active account");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the accountnumber with a number/numbers");
            }
        }
        Console.WriteLine("Select the user that you want to transfer money to:"); //Choose user to transfer to
        nr = 1;
        foreach (User item in Accounts)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(nr + ". Account name: {0}", item.Username);
            Console.WriteLine("----------------------");
            nr++;
        }
        transferLoop = true;
        

        while (transferLoop)
        {
            Console.WriteLine("To what account you wanna move money too?"); // Useraccount that recieves the money
            try
            {
                accountToName = Console.ReadLine();
                User userTransfer1 = Accounts.Find(c => c.Username == accountToName);

                if (accountToName == userTransfer1.Username)
                {
                    transferLoop = false;
                }
                else if (accountToName != userTransfer1.Username)
                {
                    Console.WriteLine("User not found!");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the account number with a number/numbers");
            }
        }
        
        transferLoop = true;
        while (transferLoop)
        {
            Console.WriteLine("How much money would u like to transfer");   // Amount of money to transfer
            try
            {
                amountTotransfer = double.Parse(Console.ReadLine());
                if (amountTotransfer > 0)
                {
                    transferLoop = false;
                }
                else
                {
                    Console.WriteLine("You can not transfer a amount below zero or equal to");
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please input the amount with numbers");
            }
        }
        //calc for amount to be removed and added
        Console.Clear();
        User userTransfer = Accounts.Find(c => c.Username == accountToName);
        List<BankAccount> namn = userTransfer.BankAccountList.FindAll(c => c.Balance > 0);
        BankAccount name = namn.Find(c => c.Balance > 0);
        int coverage = 0;

        if (AllAccounts[accountTo].Balance >= amountTotransfer)
        {
            amountLeft = AllAccounts[accountFrom].Balance; // Money from first user
            amountLeft = amountLeft - amountTotransfer;
            AllAccounts[accountFrom].Balance = amountLeft;
            

            amountAdd = namn[0].Balance; // Money to second user
            amountAdd = amountAdd + amountTotransfer;
            namn[0].Balance = amountAdd;
            coverage = 1;
        }
        if (coverage == 1)
        {
            // The actual transfer
            BankAccount bankAccount1 = new BankAccount();
            bankAccount1.Balance = AllAccounts[accountFrom].Balance;
            BankAccount bankAccount2 = new BankAccount();
            bankAccount2.AccountName = Accounts[accountTo].Username;

            AllAccounts.RemoveAt(accountFrom);
            AllAccounts.Insert(accountFrom, bankAccount1);
            namn.RemoveAt(0); 
            namn.Insert(0, bankAccount2);

            Console.WriteLine("New balance of the account money was moved from: " + AllAccounts[accountFrom].Balance);
            Console.WriteLine("You have transfered {0} to {1}: " , amountTotransfer, accountToName);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("The tranfer was terminated due to insufficent funds");
            Console.ReadKey();
        }
    }
}