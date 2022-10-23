namespace Vtitbid.ISP20.NNaumenko.Console.Zodiac
{
    public class Zodiac
    {
        private string _firstName = String.Empty;
        private string _lastName = String.Empty;
        private string _zodiacSign = String.Empty;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    {
                        _firstName = value;
                    }
                    else
                    {
                        throw new Exception("Вы не ввели имя");


                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"Ошибка: {e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    {
                        _lastName = value;
                    }
                    else
                    {
                        throw new Exception("Вы не ввели фамилию");


                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"Ошибка: {e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }
        public string SignOfZodiac
        {
            get
            {
                return _zodiacSign;
            }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    {
                        _zodiacSign = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода знака зодиака");


                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"Ошибка: {e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }
        public DateZodiac DateOfBirth { get; set; }
        public Zodiac(string firstName, string lastName, DateZodiac date)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = date;
        }
        public Zodiac(string firstName, string lastName, string signOFZodiac, DateZodiac date)
            : this(firstName, lastName, date)
        {
            SignOfZodiac = signOFZodiac;

        }
        public static void CreatingLengthArray(out int lenght)
        {
            System.Console.Write("Введите количество человек: ");
            int num = Convert.ToInt32(System.Console.ReadLine());
            lenght = 0;
            try
            {
                if (num > 0)
                {
                    lenght = num;
                }
                else
                {
                    throw new Exception("Количество человек должно быть больше 0");
                }
            }
            catch (Exception e)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Ошибка: {e.Message}");
                System.Console.ResetColor();
                Environment.Exit(0);
            }

        }
        public static void ZodiacSign(Zodiac arrayElement)
        {
            switch (arrayElement.DateOfBirth.MonthOfBirth)
            {
                case 1:
                    if (arrayElement.DateOfBirth.DayOfBirth < 20)
                    {
                        arrayElement.SignOfZodiac = "Козерог";
                    }
                    else
                        arrayElement.SignOfZodiac = "Водолей";
                    break;

                case 2:
                    if (arrayElement.DateOfBirth.DayOfBirth < 19)
                    {
                        arrayElement.SignOfZodiac = "Водолей";
                    }
                    else
                        arrayElement.SignOfZodiac = "Рыбы";
                    break;

                case 3:
                    if (arrayElement.DateOfBirth.DayOfBirth < 20)
                    {
                        arrayElement.SignOfZodiac = "Рыбы";
                    }
                    else
                        arrayElement.SignOfZodiac = "Овен";
                    break;

                case 4:
                    if (arrayElement.DateOfBirth.DayOfBirth < 20)
                    {
                        arrayElement.SignOfZodiac = "Овен";
                    }
                    else
                        arrayElement.SignOfZodiac = "Телец";
                    break;

                case 5:
                    if (arrayElement.DateOfBirth.DayOfBirth < 21)
                    {
                        arrayElement.SignOfZodiac = "Телец";
                    }
                    else
                        arrayElement.SignOfZodiac = "Близнецы";
                    break;

                case 6:
                    if (arrayElement.DateOfBirth.DayOfBirth < 21)
                    {
                        arrayElement.SignOfZodiac = "Близнецы";
                    }
                    else
                        arrayElement.SignOfZodiac = "Рак";
                    break;

                case 7:
                    if (arrayElement.DateOfBirth.DayOfBirth < 22)
                    {
                        arrayElement.SignOfZodiac = "Рак";
                    }
                    else
                        arrayElement.SignOfZodiac = "Лев";
                    break;

                case 8:
                    if (arrayElement.DateOfBirth.DayOfBirth < 23)
                    {
                        arrayElement.SignOfZodiac = "Лев";
                    }
                    else
                        arrayElement.SignOfZodiac = "Дева";
                    break;

                case 9:
                    if (arrayElement.DateOfBirth.DayOfBirth < 23)
                    {
                        arrayElement.SignOfZodiac = "Дева";
                    }
                    else
                        arrayElement.SignOfZodiac = "Весы";
                    break;

                case 10:
                    if (arrayElement.DateOfBirth.DayOfBirth < 23)
                    {
                        arrayElement.SignOfZodiac = "Весы";
                    }
                    else
                        arrayElement.SignOfZodiac = "Скорпион";
                    break;

                case 11:
                    if (arrayElement.DateOfBirth.DayOfBirth < 22)
                    {
                        arrayElement.SignOfZodiac = "Скорпион";
                    }
                    else
                        arrayElement.SignOfZodiac = "Стрелец";
                    break;

                case 12:
                    if (arrayElement.DateOfBirth.DayOfBirth < 22)
                    {
                        arrayElement.SignOfZodiac = "Стрелец";
                    }
                    else
                        arrayElement.SignOfZodiac = "Козерог";
                    break;
            }
        }
        public static Zodiac CreateZodiac()
        {
            System.Console.Write("\nВведите имя: ");
            string firstName = System.Console.ReadLine();

            System.Console.Write("Введите фамилию: ");
            string lastName = System.Console.ReadLine();

            DateZodiac date = DateZodiac.CreateDate();
            Zodiac arrayElement = new Zodiac(firstName, lastName, date);
            ZodiacSign(arrayElement);
            return arrayElement;
        }
        public static string ArrayOutput(Zodiac[] array)
        {
            string output = "\nСписок людей: ";
            for (int i = 0; i < array.Length; i++)
            {
                output += $"\n{array[i].LastName,-9}  {array[i].FirstName,-9} {array[i].SignOfZodiac,-10} {array[i].DateOfBirth.DayOfBirth}.{array[i].DateOfBirth.MonthOfBirth}.{array[i].DateOfBirth.YearOfBirth} ";
            }
            return output;
        }
        public static string Search(Zodiac[] array)
        {
            System.Console.Write("\nВведите фамилию человека,которого хотите найти: ");
            string lastName = System.Console.ReadLine();
            Zodiac[] array2 = new Zodiac[array.Length];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = array[i];
            }
            int j = 0;
            string num = String.Empty;
            string str = "Список людей с указанной фамилией: ";
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array2[i].LastName.ToLower() == lastName.ToLower())
                    {
                        str += $"\n{array[i].LastName,-5}  {array[i].FirstName,-5} {array[i].SignOfZodiac,-10} {array[i].DateOfBirth.DayOfBirth}.{array[i].DateOfBirth.MonthOfBirth}.{array[i].DateOfBirth.YearOfBirth} ";
                        j++;
                    }
                }
                if (j == 0)
                {
                    throw new Exception("Человек с такой фамилией отсутствует!");

                }
            }
            catch (Exception e)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"\n{e.Message}");
                System.Console.ResetColor();
                Environment.Exit(0);
            }
            return str;
        }
        public static void Sorting(ref Zodiac[] arrayZodiac)
        {
            Zodiac newarr;
            for (int i = 0; i < arrayZodiac.Length - 1; i++)
            {
                for (int j = i + 1; j < arrayZodiac.Length; j++)
                {
                    if ((arrayZodiac[i].DateOfBirth.YearOfBirth > arrayZodiac[j].DateOfBirth.YearOfBirth) || (arrayZodiac[i].DateOfBirth.MonthOfBirth > arrayZodiac[j].DateOfBirth.MonthOfBirth) || (arrayZodiac[i].DateOfBirth.DayOfBirth > arrayZodiac[j].DateOfBirth.DayOfBirth))
                    {
                        newarr = arrayZodiac[i];
                        arrayZodiac[i] = arrayZodiac[j];
                        arrayZodiac[j] = newarr;
                    }

                }

            }
        }
    }
}
