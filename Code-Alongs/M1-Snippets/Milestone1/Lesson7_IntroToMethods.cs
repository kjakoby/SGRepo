using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone1
{
    class Lesson7_IntroToMethods
    {
        // 1   2    3      4 
        //int Add(int x, int y)~~~~~~~~~~~~~   1 is the "return type"   2 is the "name" of the method   3 is one "parameter"   4 is second "parameter"
        //{
        //    int sum = x + y; // 6~~~~~~~~~   the statement
        //    return sum;      // 7~~~~~~~~~   return statement
        //}



        //a void method

        //void PrintCurrentDate()
        //{
        //    Console.WriteLine(DateTime.Now);
        //}



        //example of a method that prints a special message and returns early if today is New Years, and otherwise prints something else and returns

        //void PrintCurrentDate()
        //{
        //    DateTime today = DateTime.Today;

        //    if (today.DayOfYear == 1)
        //    {
        //        Console.WriteLine("Happy New Years!");
        //        return; // immediately exit method
        //    }

        //    Console.WriteLine($"Today is day {today.DayOfYear} of the current year.");
        //    // no return needed here, we can let a void method end
        //}



        //example of how scope works

        //if(true)
        //{
        //    // x only exists here
        //    int x = 5;
        //}
        //// invalid, x is out of scope
        //Console.WriteLine(x);



        //example of how to make sure methods are done in a certain order and are private to be protected

        //class SportsRecorder
        //{
        //    public void ExecuteProcess()
        //    {
        //        TurnOnTv();
        //        TurnOnCableBox();
        //        TuneToSportsChannel();
        //        StartRecording();
        //    }
        //    private void TurnOnTv()
        //    {
        //    }
        //    private void TurnOnCableBox()
        //    {
        //    }
        //    private void TuneToSportsChannel()
        //    {
        //    }
        //    private void StartRecording()
        //    {
        //    }
        //}

    }
}
