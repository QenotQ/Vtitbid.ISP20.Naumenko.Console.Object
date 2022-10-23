using Vtitbid.ISP20.Naumenko.Console.Route;

Route.CreatingLengthArray(out int n);
Route[] array = new Route[n];
for (int i = 0; i < array.Length; i++)
{
    array[i] = Route.CreateRoute();
}

Route.Sorting(ref array);
System.Console.WriteLine(Route.Search(ref array));
System.Console.WriteLine(Route.ArrayOutput(ref array));
//Route.RecordFile(ref array);
