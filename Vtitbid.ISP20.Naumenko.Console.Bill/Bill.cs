namespace Vtitbid.ISP20.Naumenko.Console.Bill
{
    public class Bill
    {
       private Action<string> writer;
        private string _payersCurrentAccount = String.Empty;
        private string _recipientCurrentAccount = String.Empty;
        private double _transaction;

        public string PayersCurrentAccount //Cчёт плательщика
        {
            get
            {
                return _payersCurrentAccount;
            }
            set
            {
                try
                {
                    if (value.Length ==10 )
                    {
                        if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                        {
                            _payersCurrentAccount = value;
                        }
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода номера расчётного счёта плательщика");
                    }
                }
                catch (Exception e)
                {
                   
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    //MassageService massageService = new MassageService();
                    //massageService.MassageHandler += MassageToStringConsole;
                    writer($"{e.Message}");
                    //System.Console.WriteLine($"{e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }
        public string RecipientCurrentAccount //Cчёт получателя
        {
            get
            {
                return _recipientCurrentAccount;
            }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    {
                        _recipientCurrentAccount = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода номера расчётного счёта получателя");
                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    //MassageService massageService = new MassageService();
                    //massageService.MassageHandler += MassageToStringConsole;
                    writer($"{e.Message}");
                    //System.Console.WriteLine($"{e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }
        public double Transaction //Перевод
        {
            get
            {
                return _transaction;
            }
            set
            {
                try
                {
                    if (value >= 0)
                    {
                        _transaction = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода суммы");
                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    //MassageService massageService = new MassageService();
                    //massageService.MassageHandler += MassageToStringConsole;
                    writer($"{e.Message}");
                    //System.Console.WriteLine($"{e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }
        public Bill(string payersCurrentAccount, string recipientCurrentAccount, double transaction)
        {
            PayersCurrentAccount = payersCurrentAccount;
            RecipientCurrentAccount = recipientCurrentAccount;
            Transaction = transaction;
        }
        public static void CreatingLengthArray(out int lenght, Action<string> writeer,Func<string> reader)
        {
            writeer("Введите количество человек: ");
            //System.Console.Write("Введите количество человек: ");
            var input = reader();
            bool isNumber = int.TryParse(input, out lenght);
            if (isNumber)
            {
                try
                {
                    if (Convert.ToInt32(input) > 0)
                    {
                        lenght = Convert.ToInt32(input);
                    }
                    else
                    {
                        throw new Exception("Количество человек должно быть больше 0");
                    }
                }
                catch (Exception e)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    writeer($"Ошибка: {e.Message}");
                    //System.Console.WriteLine($"Ошибка: {e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
            if (!isNumber)
            {
                lenght = 1;
                System.Console.ForegroundColor = ConsoleColor.Red;
                writeer($"Ошибка: Количество человек должно быть введено числами");
                //System.Console.WriteLine($"Ошибка: Количество человек должно быть введено числами");
                System.Console.ResetColor();
                Environment.Exit(0);
            }

        }
        public static Bill CreateNote(Action<string> writeer, Func<string> reader)
        {
            //System.Console.Write("\nВведите номер расчётного счёта плательщика: ");
            writeer("\nВведите номер расчётного счёта плательщика: ");
            string payersCurrentAccount = reader();


            //System.Console.Write("Введите номер расчётного счёта получателя: ");
            writeer("Введите номер расчётного счёта получателя: ");
            string recipientCurrentAccount = reader();

            //System.Console.Write("Введите перечисляемую сумму: ");
            writeer("Введите перечисляемую сумму: ");
            double transaction = Convert.ToDouble(reader());

            return new Bill(payersCurrentAccount, recipientCurrentAccount, transaction);
        }
        public static void Sorting(Bill[] arrayBills)
        {
            Bill newarr;
            for (int i = 0; i < arrayBills.Length - 1; i++)
            {
                for (int j = i + 1; j < arrayBills.Length; j++)
                {
                    if (string.Compare(arrayBills[i].RecipientCurrentAccount, arrayBills[j].RecipientCurrentAccount) > 0)
                    {
                        newarr = arrayBills[i];
                        arrayBills[i] = arrayBills[j];
                        arrayBills[j] = newarr;
                    }
                }
            }
        }
        public static string Search(Bill[] arrayBills,Action<string> writeer, Func<string> reader)
        {
            //System.Console.Write("\nВведите сумму, снятую с рассчётного счёта: ");

            writeer("\nВведите сумму, снятую с рассчётного счёта: ");
            double transaction = Convert.ToDouble(reader);
            int j = 0;
            string str = $"\nСписко счетов с указанной суммой:";
            try
            {
                for (int i = 0; i < arrayBills.Length; i++)
                {
                    if (arrayBills[i].Transaction == transaction)
                    {
                        str += $"\nНомер расчётного счёта плательщика:{arrayBills[i].PayersCurrentAccount,-12} Номер расчётного счёта получателя:{arrayBills[i].RecipientCurrentAccount,-12} Перечисляемая сумма:{arrayBills[i].Transaction}рублей ";
                        j++;
                    }
                }
                if (j == 0)
                {
                    throw new Exception("Несуществует счетов, с данной суммой снятия");

                }
            }
            catch (Exception e)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                //System.Console.WriteLine($"\n{e.Message}");
                writeer($"\n{e.Message}");
                System.Console.ResetColor();
                Environment.Exit(0);
            }
            return str;
        }
        public static string ArrayOutput(Bill[] arrayBills)
        {
            string output = "\nСписок людей: ";
            for (int i = 0; i < arrayBills.Length; i++)
            {
                output += $"\nНомер расчётного счёта плательщика:{arrayBills[i].PayersCurrentAccount,-12} Номер расчётного счёта получателя:{arrayBills[i].RecipientCurrentAccount,-12} Перечисляемая сумма:{arrayBills[i].Transaction}рублей ";
            }
            return output;
        }
        public override string ToString()
        {
            return $"Номер расчётного счёта плательщика:{PayersCurrentAccount} Номер расчётного счёта получателя:{RecipientCurrentAccount,-5} Перечисляемая сумма:{Transaction,-5}рублей ";
        }
    }
}

