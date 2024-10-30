using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3wed
{
    internal class Account
    {
         
        private decimal _balance;
        public readonly DateTime accountCreation;
        public const string Class_Creator = "gagandeep";
        public Account()
        {
            _balance = 0m;
            this.accountCreation = DateTime.Now;

        }
        public Account(decimal balance)
        {
            setBalance(balance);
            this.accountCreation = DateTime.Now;
        }
        private void setBalance(decimal balance)
        {
            _balance = balance > 0 ? balance : 0;
        }
        public decimal getBalance() => _balance;

        public decimal Withdraw(decimal amount)
        {
            if (amount <= _balance)
            {
                _balance -= amount;
                return amount;
            }
            return 0;
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
