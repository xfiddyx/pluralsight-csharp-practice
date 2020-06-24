using System;
using System.Collections.Generic;

namespace GradeBook
{


 public class Book : NamedObject
 {
  public Book(string name)
  {
   Grades = new List<double>();
   Name = name;

  }
  public void AddGrade(double num)
  {
   if (num <= 100 && num >= 0)
   {
    Grades.Add(num);
    OnGradeAdded();
   }
   else
   {
    throw new ArgumentException($"The grade {nameof(num)} is invalid");
   }
  }

  public char AddLetterGrade(double num)
  {
   switch (num)
   {
    case var d when d >= 90.0:
     return 'A';
    case var d when d >= 80.0:
     return 'B';
    case var d when d >= 70.0:
     return 'C';
    case var d when d >= 60.0:
     return 'D';
    case var d when d >= 50.0:
     return 'E';
    default:
     return 'F';
   }
  }


  public Statistics GetStatistics()
  {
   var result = new Statistics();
   result.Average = 0.0;
   result.High = double.MinValue;
   result.Low = double.MaxValue;

   for (var i = 0; i < Grades.Count; i++)
   {

    result.High = Math.Max(Grades[i], result.High);
    result.Low = Math.Min(Grades[i], result.Low);
    result.Average += Grades[i];

   }
   result.Average /= Grades.Count;
   result.Letter = AddLetterGrade(result.Average);

   return result;
  }

  private List<double> Grades;
  public string Name
  {
   get; set;
  }

  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public event GradeAddedDelegate GradeAdded;
  private void OnGradeAdded()
  {
   if (GradeAdded != null)
   {
    GradeAdded(this, new EventArgs());
   }
  }
  const string category = "maths";



 }
}
