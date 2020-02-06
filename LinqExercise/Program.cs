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
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            Console.WriteLine(sum); //or Console.WriteLine(numbers.Sum());
            var average = numbers.Average();
            Console.WriteLine(average); //or Console.WriteLine(numbers.Average());
            //Order numbers in ascending order and descending order. Print each to console.
            var orderAscending = numbers.OrderBy(number => number);

            Console.WriteLine("-----");
            foreach (var num in orderAscending)
            {
                Console.WriteLine(num);
            }

            var orderDescending = numbers.OrderByDescending(number => number);

            Console.WriteLine("-----");
            foreach (var num in orderDescending)
            {
                Console.WriteLine(num);
            }

            //Print to the console only the numbers greater than 6
            var greaterThan6 = numbers.Where(number => number > 6);

            Console.WriteLine("-----");
            foreach (var num in greaterThan6)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var only4 = numbers.OrderBy(number => number).Take(4); //.Take limits the amount you print out, try to do it another way

            Console.WriteLine("-----");
            foreach (var num in only4)  //or you can use foreach (var num in orderDescending.Take(4))
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 25; //or numbers.SetValue(32, 4);
            var changed = numbers.OrderByDescending(number => number);

            Console.WriteLine("-----");
            foreach (var num in changed)
            {
                Console.WriteLine(num);
            }
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var firstName = employees.Where(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's')
                .OrderBy(name => name.FirstName);

            Console.WriteLine("-----");
            foreach (var person in firstName)
            {
                Console.WriteLine(person);
            }
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var over26 = employees.Where(years => years.Age > 26).OrderBy(years => years.Age).ThenBy(name => name.FirstName);

            Console.WriteLine("-----");
            foreach(var item in over26)
            {
                Console.WriteLine(item);
            }
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine("-----");
            Console.WriteLine($"Total YOE:{sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg YOE:{sumAndYOE.Average(x => x.YearsOfExperience)}");
            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Alex", "Days", 25, 8)).ToList();

            Console.WriteLine("-----");

            foreach (var person in employees)
            {
                Console.WriteLine(person.FullName);
            }

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
