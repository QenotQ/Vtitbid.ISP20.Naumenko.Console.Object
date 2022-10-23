using System;
using Vtitbid.ISP20.Naumenko.Console.Bill;

Bill.CreatingLengthArray(out int n);
Bill[] array = new Bill[n];
for (int i = 0; i < array.Length; i++)
{
    array[i] = Bill.CreateNote();
}

Bill.Sorting(array);
System.Console.WriteLine(Bill.Search(array));
System.Console.WriteLine(Bill.ArrayOutput(array));