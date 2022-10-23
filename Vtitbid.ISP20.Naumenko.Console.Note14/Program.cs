using Vtitbid.ISP20.Naumenko.Console.Note14;

Note.CreatingLengthArray(out int n);
Note[] array = new Note[n];
for (int i = 0; i < array.Length; i++)
{
    array[i] = Note.CreateNote();
}

Note.Sorting(ref array);
System.Console.WriteLine(Note.Search(array));
System.Console.WriteLine(Note.ArrayOutput(array));