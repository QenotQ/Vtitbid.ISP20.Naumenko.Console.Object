namespace Vtitbid.ISP20.Naumenko.Console.Note14
{
    public class Note
    {
        private string _firstName = String.Empty;
        private string _lastName = String.Empty;
        private string _telephoneNumber = String.Empty;
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
        public string TelephoneNumber
        {
            get
            {
                return _telephoneNumber;
            }
            set
            {
                bool chek = true;
                try
                {
                    if (value.Length != 11)
                    {
                        chek = false;

                    }
                    if ((!String.IsNullOrEmpty(value)) && (!String.IsNullOrWhiteSpace(value)))
                    {

                        chek = false;
                    }
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!Char.IsDigit(value[i]))
                        {
                            chek = false;
                        }
                    }
                    if (chek == true)
                    {
                        _telephoneNumber = value;
                    }
                    if (chek == false)
                    {
                        throw new Exception("Ошибка ввода номера телефона");
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
        public Date DateOfBirth { get; set; }
        public Note(string firstName, string lastName, string telephoneNumber, Date dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            DateOfBirth = dateOfBirth;
        }
        public static Note CreateNote()
        {
            System.Console.Write("\nВведите имя: ");
            string firstName = System.Console.ReadLine();

            System.Console.Write("Введите фамилию: ");
            string lastName = System.Console.ReadLine();

            System.Console.Write("Введите номер телефона: ");
            string telephoneNumber = System.Console.ReadLine();

            Date date = Date.CreateDate();

            return new Note(firstName, lastName, telephoneNumber, date);
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
        public static void Sorting(ref Note[] arrayNotes)
        {
            int indexArray;
            int telephonNum;
            TelephonNumber[] telephonNumbers = new TelephonNumber[arrayNotes.Length];
            for (int k = 0; k < arrayNotes.Length; k++)
            {
                for (int i = 0; i < 3; i++)
                {
                    indexArray = k;
                    telephonNum = Convert.ToInt32(arrayNotes[k].TelephoneNumber[i]);
                    telephonNumbers[k] = TelephonNumber.CreateTelephonNum(ref indexArray, ref telephonNum);
                }
            }

            Note newarr;
            for (int i = 0; i < telephonNumbers.Length - 1; i++)
            {
                for (int j = i + 1; j < telephonNumbers.Length; j++)
                {
                    if (telephonNumbers[i].TelephonNum > telephonNumbers[j].TelephonNum)
                    {
                        newarr = arrayNotes[i];
                        arrayNotes[i] = arrayNotes[j];
                        arrayNotes[j] = newarr;
                    }

                }

            }


            for (int i = 0; i < telephonNumbers.Length - 1; i++)
            {
                for (int j = i + 1; j < telephonNumbers.Length; j++)
                {
                    if (telephonNumbers[i].IndexArray == j)
                    {
                        newarr = arrayNotes[i];
                        arrayNotes[i] = arrayNotes[j];
                        arrayNotes[j] = newarr;
                    }

                }

            }
        }
        public static string ArrayOutput(Note[] array)
        {
            string output = "\nСписок людей: ";
            for (int i = 0; i < array.Length; i++)
            {
                output += $"\n{array[i].LastName,-5}  {array[i].FirstName,-5}  {string.Format("{0:+#(###)###-##-##}", System.Convert.ToInt64(array[i].TelephoneNumber)),-5} {array[i].DateOfBirth.DayOfBirth}.{array[i].DateOfBirth.MonthOfBirth}.{array[i].DateOfBirth.YearOfBirth} ";


            }
            return output;
        }
        public static string Search(Note[] array)
        {
            System.Console.Write("\nВведите фамилию человека, которого нужно найти: ");
            string lastName = System.Console.ReadLine();
            Note[] array2 = new Note[array.Length];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = array[i];
            }
            int j = 0;
            string num = String.Empty;
            string str = "\nСписок людей с указанной фамилией: ";
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array2[i].LastName.ToLower() == lastName.ToLower())
                    {
                        str += $"\n{array[i].LastName,-5}  {array[i].FirstName,-5} {string.Format("{0:+#(###)###-##-##}", System.Convert.ToInt64(array[i].TelephoneNumber)),-5} {array[i].DateOfBirth.DayOfBirth}.{array[i].DateOfBirth.MonthOfBirth}.{array[i].DateOfBirth.YearOfBirth} ";
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
        public static void RecordFile(ref Note[] array)
        {
            System.Console.Write("\nВведите желаемое имя файла: ");
            string fileName = System.Console.ReadLine();
            string path = $"C:\\Users\\student\\Documents\\ISP-20\\Naumenko\\{fileName}.txt";

            using (StreamWriter textWriter = File.AppendText(path))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    textWriter.WriteLine($"{array[i].LastName,-5}  {array[i].FirstName,-5} {array[i].TelephoneNumber,-5} {array[i].DateOfBirth.DayOfBirth}.{array[i].DateOfBirth.MonthOfBirth}.{array[i].DateOfBirth.YearOfBirth}");
                }
                textWriter.Close();
            }
        }
    }
}
