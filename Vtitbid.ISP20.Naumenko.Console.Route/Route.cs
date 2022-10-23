namespace Vtitbid.ISP20.Naumenko.Console.Route
{
    public class Route
    {
        private int _routNumber = 0;
        private string _startingPointName = String.Empty;
        private string _endingPointName = String.Empty;
        public string StartingPointName
        {
            get
            {
                return _startingPointName;
            }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    {
                        _startingPointName = value;
                    }
                    else
                    {
                        throw new Exception("Вы не ввели название начальной точки пути");

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
        public string EndingPointName
        {
            get
            {
                return _endingPointName;
            }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    {
                        _endingPointName = value;
                    }
                    else
                    {
                        throw new Exception("Вы не ввели название конечной точки пути");

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
        public int RoutNumber
        {

            get
            {
                return _routNumber;
            }
            set
            {
                try
                {
                    if (value > 0)
                    {
                        _routNumber = value;
                    }
                    else
                    {
                        throw new Exception("Номер пути не может быть отрицательным");

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

        public Route(int routNumber, string startingPointName, string endingPointName)
        {
            RoutNumber = routNumber;
            StartingPointName = startingPointName;
            EndingPointName = endingPointName;

        }
        public static Route CreateRoute()
        {
            System.Console.Write("\nВведите номер маршрута: ");
            int routNumber = Convert.ToInt32(System.Console.ReadLine());

            System.Console.Write("Введите название начального пункта маршрута: ");
            string beginRoute = System.Console.ReadLine();

            System.Console.Write("Введите название конечного пункта маршрута: ");
            string endRoute = System.Console.ReadLine();

            return new Route(routNumber, beginRoute, endRoute);
        }

        public static void Sorting(ref Route[] array)
        {
            Route newarr;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].RoutNumber > array[j].RoutNumber)
                    {
                        newarr = array[i];
                        array[i] = array[j];
                        array[j] = newarr;
                    }

                }

            }

        }

        public static string ArrayOutput(ref Route[] array)
        {
            string output = "\nСписок маршрутов: ";
            for (int i = 0; i < array.Length; i++)
            {
                output += $"\n{"Номер маршрута:",-2} {array[i].RoutNumber,-2} {"Название начального пункта маршрута:",-12} {array[i].StartingPointName,-15} {"Название конечного пункта маршрута:",-10} {array[i].EndingPointName} ";


            }
            return output;
        }
        public static void CreatingLengthArray(out int lenght)
        {
            System.Console.Write("Введите количество маршрутов: ");
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
                    throw new Exception("Количество маршрутов должно быть больше 0");
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

        public static string Search(ref Route[] array)
        {
            System.Console.Write("\nВведите номер маршрута, который необходимо найти: ");
            int num = Convert.ToInt32(System.Console.ReadLine());
            int j = 0;
            string str = "\nСписко маршрутов с указанным номером: ";
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].RoutNumber == num)
                    {
                        str += $"\n{"Номер маршрута:",-2} {array[i].RoutNumber,-2} {"Название начального пункта маршрута:",-12} {array[i].StartingPointName,-15} {"Название конечного пункта маршрута:",-10} {array[i].EndingPointName} ";
                        j++;
                    }
                }
                if (j == 0)
                {
                    throw new Exception("Маршрут с таким номером отсутствует!");

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

        public static void RecordFile(ref Route[] array)
        {
            System.Console.WriteLine("Введите желаемое имя файла ");
            string fileName = System.Console.ReadLine();
            string path = $"C:\\Users\\student\\Documents\\ISP-20\\Naumenko\\{fileName}.txt";

            using (StreamWriter textWriter = File.AppendText(path))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    textWriter.WriteLine($"{"Номер маршрута:",-2} {array[i].RoutNumber,-2} {"Название начального пункта маршрута:",-12} {array[i].StartingPointName,-15} {"Название конечного пункта маршрута:",-10} {array[i].EndingPointName} ");
                }
                textWriter.Close();
            }
            
        }

    }
}

