using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Employee
    {
        private string _fullName;
        private int _age;
        private decimal _salary;
        private int _employeeId;


        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name cannot be null or empty.");

                _fullName = value.Trim();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 18 || value > 80)
                    throw new ArgumentException("Age must be between 18 and 80 inclusive.");
                _age = value;
            }
        }

        public decimal Salary
        {
            get => _salary;

            private set
            {
                if (value < 1000)
                    throw new ArgumentException("Salary cannot be less than 1000.");
                _salary = value;
            }
        }


        public int EmployeeId => _employeeId;


        public Employee(string fullName, decimal startingSalary, int age,int employeeId)
        {

            FullName = fullName;
            Age = age;
            Salary = startingSalary;
            _employeeId = employeeId;
        }


        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
                throw new ArgumentException("Raise percentage must be between 0.1 and 30.");

            decimal increase = _salary * (percentage / 100);
            Salary += increase;

            Console.WriteLine($"{FullName} received a {percentage}% raise. New Salary: {Salary}");
        }


        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0) return false;

            decimal potentialNewSalary = _salary - amount;

            if (potentialNewSalary < 1000)
            {
                Console.WriteLine("Penalty denied: Resulting salary would fall below company minimum.");
                return false;
            }

            Salary = potentialNewSalary;
            return true;
        }
    }

}