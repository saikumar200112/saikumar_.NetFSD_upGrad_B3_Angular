using System;

namespace consoleApp1
{
    public class InsufficientBalanceException : Exception
    {

        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    public class BankAccount
    {
        private double _balance;

        public BankAccount(double initialBalance)
        {
            _balance = initialBalance;
        }


        public void Withdraw(double amount)
        {
            if (amount > _balance)
            {

                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            _balance -= amount;
            Console.WriteLine($"Success! Remaining balance: {_balance}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount(3000);

            try
            {

                myAccount.Withdraw(5000);
            }
            catch (InsufficientBalanceException ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {

                Console.WriteLine("Transaction attempt finished.");
            }
            Console.ReadLine();
        }
    }
}