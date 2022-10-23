using Vtitbid.ISP20.NNaumenko.Console.Zodiac;

Zodiac.CreatingLengthArray(out int n);
Zodiac[] array = new Zodiac[n];
for (int i = 0; i < array.Length; i++)
{
    array[i] = Zodiac.CreateZodiac();
}

Zodiac.Sorting(ref array);

System.Console.WriteLine(Zodiac.Search(array));
System.Console.WriteLine(Zodiac.ArrayOutput(array));