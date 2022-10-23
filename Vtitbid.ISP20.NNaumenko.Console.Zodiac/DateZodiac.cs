using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.NNaumenko.Console.Zodiac
{
    public class DateZodiac
    {
        private int _dayOfBirth;
        private int _monthOfBirth;
        private int _yearOfBirth;
        public int DayOfBirth
        {
            get
            {
                return _dayOfBirth;
            }
            set
            {
                try
                {
                    if (value > 0 && value <= 31)
                    {
                        _dayOfBirth = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода даты");


                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"{e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }

            }
        }
        public int MonthOfBirth
        {
            get
            {
                return _monthOfBirth;
            }
            set
            {
                try
                {
                    if (value > 0 && value <= 12)
                    {
                        _monthOfBirth = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода даты");


                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"{e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }
        public int YearOfBirth
        {
            get
            {
                return _yearOfBirth;
            }
            set
            {
                try
                {
                    if (value > 1900 && value <= Convert.ToInt32(DateTime.Now.Year))
                    {
                        _yearOfBirth = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода даты");


                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"{e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }

            }
        }
        public DateZodiac(int dayOfBirth, int monthOfBirth, int yearOfBirth)
        {
            DayOfBirth = dayOfBirth;
            MonthOfBirth = monthOfBirth;
            YearOfBirth = yearOfBirth;
        }

        public static DateZodiac CreateDate()
        {
            System.Console.Write("Введите дату рождения: ");
            int dayOfBirth = Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Введите месяц рождения: ");
            int monthOfBirth = Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Введите год рождения: ");
            int yearOfBirth = Convert.ToInt32(System.Console.ReadLine());
            try
            {
                if (ChekDate(dayOfBirth, monthOfBirth, yearOfBirth))
                {
                    return new DateZodiac(dayOfBirth, monthOfBirth, yearOfBirth);
                }
                else
                {
                    throw new Exception("Ошибка ввода даты");
                }
            }
            catch (Exception e)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"{e.Message}");
                System.Console.ResetColor();
                Environment.Exit(0);
            }
            return null;
        }
        public static bool ChekDate(int day, int month, int year)
        {
            bool check = false;
            if (day <= 31 && (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12))
            {
                check = true;
            }
            if (day <= 30 && (month == 4 || month == 6 || month == 9))
            {
                check = true;
            }
            if (month == 2)
            {
                if (year % 4 == 0 && day <= 29)
                {
                    check = true;
                }
                if (year % 4 == 1 && day <= 28)
                {
                    check = true;
                }
            }
            return check;
        }
    }
}

