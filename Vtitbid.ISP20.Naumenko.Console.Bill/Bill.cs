namespace Vtitbid.ISP20.Naumenko.Console.Bill
{
    public class Bill
    {
        private string _payersCurrentAccount = String.Empty;
        private string _recipientCurrentAccount = String.Empty;
        private double _transaction;
        public string PayersCurrentAccount
        {
            get
            {
                return _payersCurrentAccount;
            }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    {
                        _payersCurrentAccount = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода номера расчётного счёта плательщика");
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
        public string RecipientCurrentAccount
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
                    System.Console.WriteLine($"{e.Message}");
                    System.Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }
        public double Transaction
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
                    System.Console.WriteLine($"{e.Message}");
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
        public static Bill CreateNote()
        {
            System.Console.Write("\nВведите номер расчётного счёта плательщика: ");
            string payersCurrentAccount = System.Console.ReadLine();

            System.Console.Write("Введите номер расчётного счёта получателя: ");
            string recipientCurrentAccount = System.Console.ReadLine();

            System.Console.Write("Введите перечисляемую сумму: ");
            double transaction = Convert.ToDouble(System.Console.ReadLine());

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
        public static string Search(Bill[] arrayBills)
        {
            System.Console.Write("\nВведите сумму, снятую с рассчётного счёта: ");
            double transaction = System.Convert.ToDouble(System.Console.ReadLine());
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

