using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Accounts
    {
        public string id { get; set; }
        public string name { get; set; }
        public decimal balance { get; set; }

        private static int firstId = 1234567890;
        private List<Transactions> allTransactions = new List<Transactions>();
        public Accounts( string name, decimal initialBalance)
        {
            this.id = firstId.ToString();
            this.name = name;
            this.balance = initialBalance;
            firstId += 1;
           
        
        }

        public void MakeDeposit() 
        {
            Console.WriteLine("Please type how much money you want to deposit.");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Any Notes?");
            string depositNote = Console.ReadLine();
            var deposit = new Transactions("Deposit",depositAmount, DateTime.Now, depositNote);
            allTransactions.Add(deposit);
            balance += depositAmount;
            Console.WriteLine("Deposit Succesful!");
            
            
        
        }

        public void MakeWithdrawal ()
        {
            Console.WriteLine("Please type how much money you want to withdraw.");
            decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Any Notes?");
            string withdravalNote = Console.ReadLine();
            var withdrawal = new Transactions("Withdrawal", withdrawalAmount, DateTime.Now, withdravalNote);
            allTransactions.Add(withdrawal);
            balance -= withdrawalAmount;
            Console.WriteLine("Withdrawal Succesful!");


        }
        
        public void AccountHistory()
        {
            Console.WriteLine("TYPE\t        DATE\t\t         AMOUNT\t NOTE\t");

            foreach (var transaction in allTransactions)
            {
                Console.WriteLine($"{transaction.transactionType} \t{transaction.dateTime}\t " +
                    $"{transaction.amount}\t {transaction.note}");
            }
           
         }

        public void AccountDetails()
        {
            Console.WriteLine($" The account of user {name} \n ID: {id}\n Balance: {balance}\n");
        }
    }
}
