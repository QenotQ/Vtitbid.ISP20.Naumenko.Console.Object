namespace Vtitbid.ISP20.Naumenko.Console.Cringeee
{
    public class Cringe
    {
        private int _indexArray = 0;
        private string _name = String.Empty;
        public int IndexArray
        {
            get
            {
                return _indexArray;
            }
            set
            {
                if (value > 0)
                {
                    _indexArray = value;
                }

            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value) && String.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }

            }
        }
        public static int CreatingLengthArray()
        {
            System.Console.Write("Введите количество человек: ");
            int num = Convert.ToInt32(System.Console.ReadLine());
            int lenght = 0;
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
            return lenght;

        }
        public static Cringe[] CreateArray(int lenght)
        {
            Cringe[] cringeArray = new Cringe[lenght + 1];
            for (int i = 1; i < cringeArray.Length; i++)
            {
                cringeArray[i] = new Cringe();
                cringeArray[i].Name = $"Игрок {i}";
                cringeArray[i].IndexArray = i;
            }
            return cringeArray;
        }
        public static void CreatingWinners(out int winners, int lenght)
        {

            System.Console.Write("Введите количество победителей: ");
            int num = Convert.ToInt32(System.Console.ReadLine());
            winners = 0;
            try
            {
                if (num > 0 && num < lenght)
                {
                    winners = num;
                }
                else if (num < 0)
                {
                    throw new Exception("Количество человек должно быть больше 0");
                }
                else
                {
                    throw new Exception("Количество человек должно быть меньше общего количества");
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
        public static void RandomWinners(Cringe[] cringeArray, int winners)
        {
            Random random = new Random();
            int[] arrayOfWinners = new int[winners + 1];
            int index;
            for (int k = 1; k < arrayOfWinners.Length; k++)
            {
                index = random.Next(1, cringeArray.Length);
                arrayOfWinners[k] = index;
            }

            bool isRepeat = true;
            int repeatsCounter;

            while (isRepeat == true)
            {
                repeatsCounter = 0;

                for (int k = 2; k < arrayOfWinners.Length; k++)
                {
                    for (int i = 1; i < arrayOfWinners.Length; i++)
                    {
                        if (k != i)
                        {
                            if (arrayOfWinners[k] == arrayOfWinners[i])
                            {
                                index = random.Next(1, cringeArray.Length);
                                arrayOfWinners[k] = index;
                                repeatsCounter++;
                            }
                        }

                    }

                }
                if (repeatsCounter == 0)
                {
                    isRepeat = false;
                }

            }

            string output = String.Empty;
            System.Console.Write("\nПобедители:\n");
            for (int k = 1; k < arrayOfWinners.Length; k++)
            {
                for (int i = 1; i < cringeArray.Length; i++)
                {
                    if (arrayOfWinners[k] == cringeArray[i].IndexArray)
                    {
                        output += $"Игрок №{cringeArray[i].IndexArray}; \n";
                    }

                }
            }
            System.Console.WriteLine(output);

        }
    }
}

