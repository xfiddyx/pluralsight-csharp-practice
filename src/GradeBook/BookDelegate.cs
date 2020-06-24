using System;
using System.Collections.Generic;

namespace GradeBook
{
 public class AddToGradeBook
 {
  public void OnGradeAdded(object source, EventArgs args)
  {
   Console.WriteLine("A grade has been added");
  }
 }
}
