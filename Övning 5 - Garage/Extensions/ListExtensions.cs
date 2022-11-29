namespace Exercise_5_Garage.Extensions
{
    // Was used, but not anymore
    public static class ListExtensions
    {
        public static string CommaSeparated(this List<string> list)
        {
            return string.Join(",", list);
        }
    }
}
