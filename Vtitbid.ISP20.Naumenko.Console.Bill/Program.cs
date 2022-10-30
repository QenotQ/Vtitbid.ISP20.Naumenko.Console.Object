using System;
using Vtitbid.ISP20.Naumenko.Console.Bill;

Bill.CreatingLengthArray(out int n,System.Console.Write,System.Console.ReadLine);
Bill[] array = new Bill[n];
for (int i = 0; i < array.Length; i++)
{
    array[i] = Bill.CreateNote(System.Console.Write,System.Console.ReadLine);
}

Bill.Sorting(array);
System.Console.WriteLine(Bill.Search(array,System.Console.Write,System.Console.ReadLine));
System.Console.WriteLine(Bill.ArrayOutput(array));