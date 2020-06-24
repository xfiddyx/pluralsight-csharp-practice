using System;
using Xunit;

namespace GradeBook.Tests
{
 public class BookTests
 {
  [Fact]
  public void BookCalculatesStatistics()
  {

   var book = new Book("");
   book.AddGrade(70.5);
   book.AddGrade(81.4);
   book.AddGrade(97.6);

   var result = book.GetStatistics();

   Assert.Equal(83.17, result.Average, 2);
  }
 }
}
