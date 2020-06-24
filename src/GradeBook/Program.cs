using System;
using System.Collections.Generic;

namespace GradeBook
{
 class Program
 {
  static void Main(string[] args)
  {

   Console.WriteLine("Hi, who's book would you like to update today?");
   var Student = Console.ReadLine();
   Console.WriteLine($"Ok, let me just grab {Student}'s book");
   var addGradeMessage = new AddToGradeBook();
   var book = new Book($"{Student}'s grade book");
   book.Name = Student;
   book.GradeAdded += addGradeMessage.OnGradeAdded;
   bool InputGrade = true;
   do
   {
    Console.WriteLine("Please enter their grade");
    var Grade = Convert.ToDouble(Console.ReadLine());
    try
    {
     book.AddGrade(Grade);
    }
    catch (Exception ex)
    {
     Console.WriteLine($"{ex.Message}");
    }
    Console.WriteLine("Would you like to add another grade [Y/N]");
    char ContInput = Console.ReadKey().KeyChar;
    Console.WriteLine("");
    if (ContInput == 'n') InputGrade = false;
   } while (InputGrade);

   Console.WriteLine("Great, that has saved all the scores. Would you like some stats on these scores? [Y/N]");
   char response = Console.ReadKey().KeyChar;
   Console.WriteLine("");

   var statistics = book.GetStatistics();
   switch (response)
   {
    case var d when d == 'y':
     Console.WriteLine($"Here is {book.Name}'s scores");
     Console.WriteLine($"The highest score is {statistics.High}, the lowest score is {statistics.Low} and the average score is {statistics.Average}. Their grade is {statistics.Letter}");
     break;
    case var d when d == 'n':
     Console.WriteLine("No problem, maybe another time");
     break;
   }


  }

 }

}
