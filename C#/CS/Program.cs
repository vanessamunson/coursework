using CS.Assignment1;
using CS.Assignment2;
using CS.Assignment3;
using CS.Assignment4;
using System.Collections.Generic;
using System.Linq;

namespace CS;

public class Program
{
    public static void Main(string[] args)
    {
        #region Assignment1
            Console.WriteLine("Assignment 1: SwapperChecker");
            Console.WriteLine($"Swap [1, 2]: [{string.Join(", ", SwapperChecker.Swap(new int[] {1, 2}))}]"); 
            Console.WriteLine($"Opposites (-1, 1): {SwapperChecker.Opposites(-1, 1)}");
            Console.WriteLine($"Opposites (1, -1): {SwapperChecker.Opposites(1, -1)}");
            Console.WriteLine($"Opposites (0, 1): {SwapperChecker.Opposites(0, 1)}");
            Console.WriteLine($"Equals (5, 5): {SwapperChecker.Equals(5, 5)}");
            Console.WriteLine($"Equals (5, -5): {SwapperChecker.Equals(5, -5)}");
        #endregion

        #region Assignment2
            Console.WriteLine("Assignment 2a: Averages");
            Console.WriteLine("SumAverage:");
            DiamondApp.SumAverage();

            Console.WriteLine("Assignment 2b: Diamonds");
            Console.WriteLine("VariantOne(4):");
            DiamondApp.VariantOne(4);
            Console.WriteLine("VariantTwo(4):");
            DiamondApp.VariantTwo(4);
            Console.WriteLine("VariantThree(4):");
            DiamondApp.VariantThree(4);
        #endregion

        #region Assignment 3
            Person Zach = new Person();
            Console.WriteLine(Zach.Greet());

            Student Vanessa = new Student{ Age = 22 };
            Console.WriteLine(Vanessa.Greet());
            Console.WriteLine(Vanessa.ShowAge());

            Teacher Mom = new Teacher{ Age = 50 };
            Console.WriteLine(Mom.Greet());
            Console.WriteLine(Mom.Explain());
        #endregion

        #region Assignment 4
            // Had to make class Students instead of Student, which was taken by assignment 3
            IList<Students> studentsList = new List<Students>() {
                new Students() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Students() { StudentID = 2, StudentName = "Steve", Age = 21, StandardID = 1 } ,
                new Students() { StudentID = 3, StudentName = "Bill", Age = 18, StandardID = 2 } ,
                new Students() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Students() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            var studentsOver21 = studentsList.Where(x => x.Age >= 21);
            Console.WriteLine("Students over 21: ");
            foreach (var student in studentsOver21)
            {
                Console.WriteLine($"{student.StudentName} {student.Age}");
            }

            var studentNames = studentsList.Select(s => new {s.StudentName});
            Console.WriteLine("Student names: ");
            foreach (var name in studentNames)
            {
                Console.WriteLine($"{name.StudentName}");
            }

            var groupedByStandardId = studentsList.GroupBy(x => x.StandardID);
            Console.WriteLine("Students grouped by standard ID: ");
            foreach (var group in groupedByStandardId)
            {
                Console.WriteLine($"StandardID: {group.Key}");

                foreach (var student in group)
                {
                    Console.WriteLine($"  {student.StudentName}");
                }
            }

            var leftJoin = 
                from s in studentsList
                join stan in standardList
                on s.StandardID equals stan.StandardID
                into joinedGroup
                from j in joinedGroup.DefaultIfEmpty()
                select new
                {
                  s.StudentName,
                  s.Age,
                  standardName = j?.StandardName  
                };
            Console.WriteLine("Left join on StandardID: ");
            foreach (var student in leftJoin)
            {
                Console.WriteLine($"{student.StudentName} {student.Age} --> {student.standardName}");
            }
        #endregion
    }
}
