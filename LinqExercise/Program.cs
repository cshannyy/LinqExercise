using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());


            //Order numbers in ascending order and decsending order. Print each to console.
            var ascOrder = numbers.OrderBy(num => num);
            Console.WriteLine("---");
            foreach (var number in ascOrder)
            {
                Console.WriteLine(number);
            }

            var desOrder = numbers.OrderByDescending(num => num);
            Console.WriteLine("---");
            foreach( var number in desOrder)
            {
                Console.WriteLine(number);
            }


            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("---");

            foreach( var number in greaterThanSix)
            {
                Console.WriteLine(number);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("---");

            foreach (var num in desOrder.Take(4))
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("---");
            numbers[4] = 21;
            //or
            //numbers.SetValue(21, 4);

            var descWithAge = numbers.OrderByDescending(num => num);

            foreach (var num in descWithAge)
            {
                Console.WriteLine(num);
            }
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0] == 's')
                           .OrderBy(person => person.FirstName);

            Console.WriteLine("---");

            Console.WriteLine("C or S employees:");
            foreach(var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var overAge = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age)
                .ThenBy(person => person.FullName)
                .ThenBy(person => person.YearsOfExperience);
                
               

            Console.WriteLine("---");

            Console.WriteLine("Employees over 26:");

           foreach (var employee in overAge)
            {
                Console.WriteLine(employee.FullName);
                Console.WriteLine($"Age: {employee.Age} YOE: {employee.YearsOfExperience}");
                
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("---");
            var years = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            var sumOfYOE = years.Sum(employee => employee.YearsOfExperience);
            var avgOfYOE = years.Average(employee => employee.YearsOfExperience);

            Console.WriteLine($"The sum of the years of experience is {sumOfYOE} " +
                $"and the average of years of experience is {avgOfYOE} ");

            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("first", "lastName", 27, 4)).ToList();

            foreach(var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
