using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Ch8_Datetime
{
    class Program
    {

        static void Main(string[] args)
        {
            var dt1 = new DateTime(2017, 10, 22);
            var dt2 = new DateTime(2016, 10, 22, 8, 45, 20);

            var today = DateTime.Today;
            var now = DateTime.Now;

            Console.WriteLine(dt1);
            Console.WriteLine(dt2);
            Console.WriteLine("Today : {0}", today);
            Console.WriteLine("Now : {0}", now);

            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;
            int millisecond = now.Millisecond;

            DayOfWeek dayOfWeek = today.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Sunday)
                Console.WriteLine("오늘은 일요일입니다.");
            else if (dayOfWeek == DayOfWeek.Monday)
                Console.WriteLine("오늘은 월요일입니다.");
            else if (dayOfWeek == DayOfWeek.Tuesday)
                Console.WriteLine("오늘은 화요일입니다.");
            else if (dayOfWeek == DayOfWeek.Wednesday)
                Console.WriteLine("오늘은 수요일입니다.");
            else if (dayOfWeek == DayOfWeek.Thursday)
                Console.WriteLine("오늘은 목요일입니다.");
            else if (dayOfWeek == DayOfWeek.Friday)
                Console.WriteLine("오늘은 금요일입니다.");
            else if (dayOfWeek == DayOfWeek.Saturday)
                Console.WriteLine("오늘은 토요일입니다.");

            var isLeapYear = DateTime.IsLeapYear(2016);
            if (isLeapYear)
                Console.WriteLine("윤년입니다.");
            else
                Console.WriteLine("윤년 아닙니다.");

            DateTime dt3;
            if (DateTime.TryParse("2017/6/21", out dt3))
                Console.WriteLine(dt3);

            DateTime dt4;
            if (DateTime.TryParse("2017/6/21 10:41:38", out dt4))
                Console.WriteLine(dt4);

            try
            {
                DateTime dt5 = DateTime.Parse("20170621"); // FormatException 예외 발생
                Console.WriteLine(dt5);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            DateTime dt6;
            if (DateTime.TryParse("서기2020년6월11일", out dt6))
                Console.WriteLine(dt6);

            var date = new DateTime(2017, 10, 22, 21, 6, 47);
            var s1 = date.ToString("d");
            var s2 = date.ToString("D");
            var s3 = date.ToString("yyyy-mm-dd");
            var s4 = date.ToString("yyyy년m월d일(ddd)");
            var s5 = date.ToString("yyyy년mm월dd일 HH시mm분ss초");
            var s6 = date.ToString("f");
            var s7 = date.ToString("F");
            var s8 = date.ToString("t");
            var s9 = date.ToString("T");
            var s10 = date.ToString("tt hh:mm");
            var s11 = date.ToString("HH시mm분ss초");

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(s6);
            Console.WriteLine(s7);
            Console.WriteLine(s8);
            Console.WriteLine(s9);
            Console.WriteLine(s10);
            Console.WriteLine(s11);

            var str = string.Format("{0}년{1,3}월{2,3}일",
                today.Year, today.Month, today.Day);
            Console.WriteLine(str);

            var date1 = new DateTime(2016, 8, 15);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str1 = date.ToString("ggyy年M月d日", culture);
            Console.WriteLine(str1);

            var date2 = new DateTime(2020, 6, 11);
            var culture2 = new CultureInfo("ko-KR");
            culture2.DateTimeFormat.Calendar = new KoreanCalendar();
            var dayOfWeek2 = culture2.DateTimeFormat.GetDayName(date2.DayOfWeek);
            Console.WriteLine(dayOfWeek2);

            var dt7 = new DateTime(2020, 6, 11, 1, 30, 21);
            var dt8 = new DateTime(2020, 11, 2, 18, 5, 28);
            if (dt7 < dt8)
                Console.WriteLine("dt8쪽이 미래입니다.");
            else if (dt7 == dt8)
                Console.WriteLine("dt7과 dt8은 같은 시각입니다.");

            if (dt7.Date < dt8.Date)
                Console.WriteLine("dt8쪽이 미래입니다.");
            else if (dt7.Date == dt8.Date)
                Console.WriteLine("dt7과 dt8은 같은 시각입니다.");

            var future = now + new TimeSpan(1, 30, 0);
            Console.WriteLine(future);

            var past = now - new TimeSpan(1, 30, 0);
            Console.WriteLine(past);

            var future1 = today.AddDays(20);
            Console.WriteLine(future1);
            var past1 = today.AddDays(-20);
            Console.WriteLine(past1);

            var date3 = new DateTime(2020, 6, 11);
            var future2 = date.AddYears(2).AddMonths(5);
            Console.WriteLine(future2);

            TimeSpan diff = date3 - date1;
            Console.WriteLine("두 시각의 차는 {0}일 {1}시간 {2}분 {3}초입니다.", diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
            Console.WriteLine("총 {0}초입니다.", diff.TotalSeconds);

            int day1 = DateTime.DaysInMonth(today.Year, today.Month);
            var endOfMonth = new DateTime(today.Year, today.Month, day1);
            Console.WriteLine(endOfMonth);

            int dayOfYear = today.DayOfYear;
            Console.WriteLine(dayOfYear);

            DateTime nextWednesday = NextDay(today, DayOfWeek.Wednesday);
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            Console.WriteLine(nextWednesday);
            Console.WriteLine(days);

            var birthday = new DateTime(1979, 1, 13);
            int age = GetAge(birthday, today);
            Console.WriteLine(age);


            var nth = NthWeek(today);
            Console.WriteLine("{0}주째", nth);

            DateTime day2 = DayOfNthWeek(2020, 6, DayOfWeek.Sunday, 3);
            Console.WriteLine(day2);

        }

        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek)
        {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0)
                days += 7;
            return date.AddDays(days);
        }

        public static int GetAge(DateTime birthday, DateTime targetDay)
        {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age))
            {
                age--;
            }
            return age;
        }

        public static int NthWeek(DateTime date)
        {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }

        public static DateTime DayOfNthWeek(int year, int month, DayOfWeek dayOfWeek, int nth)
        {
            var firstDay = Enumerable.Range(1, 7)
                .Select(d => new DateTime(year, month, d))
                .First(d => d.DayOfWeek == dayOfWeek)
                .Day;
            var day = firstDay + (nth - 1) * 7;
            return new DateTime(year, month, day);
        }

    }
}
