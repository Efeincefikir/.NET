using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Transactions
    {

        public string transactionType;
        public decimal amount;
        public DateTime dateTime;
        public string note;

        public Transactions( string type, decimal amount, DateTime dateTime, string note)
        {
            this.transactionType = type;
            this.amount = amount;
            this.note = note;
            this.dateTime = dateTime;

        }


    }


    } 




 
