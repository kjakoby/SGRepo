using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeLab
{
    public class DateTimeLabCode
    {
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            DateTime today = DateTime.Today;
            return today;
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            DateTime d1 = new DateTime(year, month, day);
            return d1.ToString("M/d/yy");

        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            DateTime d1 = DateTime.Parse(date);
            return d1;


        }

        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            DateTime d1 = DateTime.Parse(date);
            return d1.ToString("MM.dd.yyyy hh:mm tt");
        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            DateTime d1 = DateTime.Parse(date);
            //string finalDate;
            d1 = d1.AddMonths(6);
            return d1.ToString("MMMM d, yyyy");

        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>
        public string GetDateThirtyDaysInPast(string date)
        {
            DateTime d1 = DateTime.Parse(date);
            d1 = d1.AddDays(-30);
            return d1.ToString("MMMM d, yyyy");

        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>
        public DateTime[] GetNextWednesdays(int count, string startDate)
        {
            DateTime[] array = new DateTime[count];
            DateTime startDay = DateTime.Parse(startDate);
            for (int i = 0; i < count; i++)
            {
                if(startDay.DayOfWeek == DayOfWeek.Wednesday)
                {
                    array[i] = startDay;
                    startDay = startDay.AddDays(7);
                }
                else
                {
                    for (int j = 1; j < 7; j++)
                    {
                        startDay = startDay.AddDays(1);

                        if (startDay.DayOfWeek == DayOfWeek.Wednesday)
                        {
                            array[i] = startDay;
                            startDay = startDay.AddDays(7);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    
                }
            }
            return array;
        }
    }
}
