using System;
using Xunit;

namespace GradeBook.Tests
{
 public class TypeTest
 {

  public delegate string WriteLogDelete(string loggingMessage);
  [Fact]
  public void Test1()
  {

   var book = new Book("Steven's grade book");
   book.AddGrade(90.5);
   book.AddGrade(89.1);
   book.AddGrade(77.3);
   book.AddGrade(80.3);
   var myGradeBook = book.GetStatistics();

   Assert.Equal(84.3, myGradeBook.Average);
   Assert.Equal('B', myGradeBook.Letter);
  }
  int count = 0;

  [Fact]
  public void WriteLogDeleteMethod()
  {

   WriteLogDelete log = ReturnMessage;

   log += IncrementCount;
   string result = log("Ay up!");

   Assert.Equal(3, count);
   Assert.Equal("Ay up!", result);



  }

  public string IncrementCount(string message)
  {
   count++;
   Console.WriteLine(count + "inc");

   return message;
  }
  public string ReturnMessage(string message)
  {
   count++;
   Console.WriteLine(count + "ret");

   return message;
  }
  private void SetInt(ref int x)
  {
   x = 42;
  }

  private int GetInt()
  {
   return 3;
  }
 }
}
