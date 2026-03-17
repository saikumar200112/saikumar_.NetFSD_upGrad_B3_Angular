using System;

namespace BankManagementSystem
{
    class BankMangementSystem
    {
        private string _accountNumber;
        private decimal _balance;

        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            private set
            {
                _accountNumber = value;

            }
        }
        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }
        public BankMangementSystem(string accountNumber, decimal initialBalance)
        {
            _accountNumber = accountNumber;
            _balance = initialBalance > 0 ? initialBalance : 0;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                return;
            }
            _balance += amount;
            Console.WriteLine($"Successfully Deposited INR.{amount}.Current Balance INR.{_balance}");

        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                return;
            }
            if (amount > _balance)
            {
                Console.WriteLine("Insufficient Funds");
                return;
            }
            _balance -= amount;
            Console.WriteLine($"Successfully Withdraw INR.{amount}.Current Balance INR.{_balance}");

        }

    }




    class Program
    {
        static void Main(string[] args)
        {

            BankMangementSystem bsm = new BankMangementSystem("SAP-2703789855", 0);
            bsm.Deposit(5000);
            bsm.Withdraw(2000);
            Console.WriteLine($"AccountNumber: {bsm.AccountNumber}");
            Console.WriteLine($"Balance: {bsm.Balance}");

            Console.ReadLine();

        }
    }
}