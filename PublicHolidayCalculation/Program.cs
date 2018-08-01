using Nager.Date;
using Nager.Date.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicHolidayCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
            Test3();
            Console.ReadLine();
        }

        private static void Test1()
        {
            var date = DateTime.Today;
            var countryCode = CountryCode.IE;

            do
            {
                date = date.AddDays(1);
            }
            while (DateSystem.IsPublicHoliday(date, countryCode) || date.IsWeekend(countryCode));
        }

        private static void Test2()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.IE, 2018);
            foreach (var publicHoliday in publicHolidays)
            {
                Console.WriteLine("{0:dd:MM:yyyy} {1} {2}", publicHoliday.Date, publicHoliday.LocalName, publicHoliday.Global);
            }
        }

        private static void Test3()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i= 0; i < 10000; i++)
            {
                var x = DateSystem.IsPublicHoliday(new DateTime(2017,07,04), CountryCode.IE);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed time: " + stopwatch.ElapsedMilliseconds + "ms");
        }
    }
}
