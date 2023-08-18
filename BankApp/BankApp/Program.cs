using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{ 

    class Program
    {
        private static List<Accounts> accountsList = new List<Accounts>();

        public static void Main(string[] args)
        {
            int exitCondition = 1;
            Console.WriteLine("****** Welcome to the Efe's Banking System! *******");

            if (accountsList.Count == 0)
            {
                Console.WriteLine("First, you have to create an account.");
                newAccountMaker();
                

            }

            Accounts currentAccount = accountsList.First();

            while (exitCondition == 1)
             {
                 Console.WriteLine("\n1- Deposit");
                 Console.WriteLine("2- Withdrawal");
                 Console.WriteLine("3- See Transactions");
                 Console.WriteLine("4- See Account");
                 Console.WriteLine("5- Create/Change Account");
                 Console.WriteLine("6- Exit");
                 
                 Console.WriteLine("Please enter the corresponding number to your desired action.\n");
                int action = int.Parse(Console.ReadLine());

                 switch (action)
                 {
                    case 1 :
                        currentAccount.MakeDeposit();
                        break;
                    
                    case 2 :
                        currentAccount.MakeWithdrawal();
                        break;

                    case 3 :
                        currentAccount.AccountHistory();
                        break;

                    case 4 :
                        currentAccount.AccountDetails();
                        break;
                    case 5 :
                        if (accountsList.Count == 1)
                        {
                            newAccountMaker();
                            currentAccount = accountsList[1];
                            Console.WriteLine("New account has been made.");

                        }
                        else
                        {   
                            
                            Console.WriteLine("What is your desired operation? \n");
                            Console.WriteLine("1- Create a new account \n 2- Change to an existing account");
                            int accountAction = int.Parse(Console.ReadLine());
                            switch(accountAction)
                            {
                                case 1 :
                                    newAccountMaker();
                                    currentAccount = accountsList.Last();
                                    Console.WriteLine("New account has been made.");
                                    break;

                                case 2 :
                                    Console.WriteLine("Previously created accounts are:");
                                    int accountCounter = 1;
                                    foreach ( var account in accountsList)
                                    {   
                                        Console.WriteLine($" {accountCounter}- {account.id}  {account.name}");
                                        accountCounter++;

                                    }
                                    Console.WriteLine("\nPlease enter the number corresponding to the account you want to use.");
                                    int accountSelector = int.Parse(Console.ReadLine());
                                    currentAccount = accountsList[accountSelector - 1];
                                    Console.WriteLine($"The account belonging to {currentAccount.name} has been selected");
                                    
                                    break;

                            }
                        }
                        break;

                    case 6 : 
                        exitCondition= 0;
                        break;

                    
                        
                 }      
             }
        }

        public static void newAccountMaker()
        {
            Console.WriteLine("Who is the account for?");
            string accountName = Console.ReadLine();
            Console.WriteLine("What is your initial balance?");
            decimal initialBalance = Decimal.Parse(Console.ReadLine());
            Accounts newAccount = new Accounts(accountName, initialBalance);
            accountsList.Add(newAccount);

        }
    }
}