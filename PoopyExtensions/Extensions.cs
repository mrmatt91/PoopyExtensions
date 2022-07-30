namespace PoopyExtensions
{
    public static class Extensions
    {
        public static string Poopy<T>(this IEnumerable<T> items)
        {
            var x = 0;
            var poopyString = items switch
            {
                IEnumerable<int> => Poopify(items.Cast<int>().ToList().Select(i => string.Join(" ", items.Take(items.Count() - i + 1)))),
                IEnumerable<string> => Poopify(items.Select(w => string.Join(" ", items.Take(items.Count() - x++)))),
                _ => throw new NotImplementedException()
            };
            return poopyString;
        }

        public static string Poopy(this int num)
        {
            var nums = Enumerable.Range(1, num).ToList();
            return Poopify(nums.Select(i => string.Join(" ", nums.Take(nums.Count() - i + 1)));
        }

        public static string Poopy(this string str)
        {
            var x = 0;
            return Poopify(str.Select(s => string.Join(" ", str.Take(str.Count() - x++))));
        }

        private static string Poopify<T>(IEnumerable<T> collection)
        {
            return string.Join(Environment.NewLine, collection);
        }
    }
}