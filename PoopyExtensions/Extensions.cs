namespace PoopyExtensions
{
    public static class Extensions
    {
        public static string Poopy<T>(this IEnumerable<T> items)
        {
            var x = 0;
            var poopyString = items switch
            {
                IEnumerable<int> _ => string.Join(Environment.NewLine, items.Cast<int>().ToList().Select(i => string.Join(" ", items.Take(items.Count() - i + 1)))),
                IEnumerable<string> _ => string.Join(Environment.NewLine, items.Select(w => string.Join(" ", items.Take(items.Count() - x++)))),
                _ => throw new NotImplementedException()
            };
            return poopyString;
        }

        public static string Poopy(this int num)
        {
            var nums = Enumerable.Range(1, num).ToList();
            return string.Join(Environment.NewLine, nums.Select(i => string.Join(" ", nums.Take(nums.Count() - i + 1))));
        }

        public static string Poopy(this string str)
        {
            var x = 0;
            return string.Join(Environment.NewLine, str.Select(s => string.Join(" ", str.Take(str.Count() - x++))));
        }
    }
}