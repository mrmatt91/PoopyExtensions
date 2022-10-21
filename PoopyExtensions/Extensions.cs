using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

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
            return Poopify(nums.Select(i => string.Join(" ", nums.Take(nums.Count() - i + 1))));
        }

        public static string Poopy(this string str)
        {
            var x = 0;
            return Poopify(str.Select(s => string.Join(" ", str.Take(str.Count() - x++))));
        }

        public static int PoopyKaprekar(this int num, int depth)
        {
            if (num == 6174)
            {
                var finalDepth = depth;
                depth = 0;
                return finalDepth;
            }
            else
            {
                List<int> numbers = num.ToString().Select(i => (int)i - 48).ToList();
                while (numbers.Count() < 4)
                {
                    numbers.Add(0);
                }
                var numSortedDesc = int.Parse(string.Join("", numbers.OrderByDescending(_ => _).Select(i => i.ToString())));
                var numSortedAsc = int.Parse(string.Join("", numbers.OrderBy(_ => _).Select(i => i.ToString())));
                var min = (numSortedDesc > numSortedAsc) ? numSortedAsc : numSortedDesc;
                var max = (numSortedDesc > numSortedAsc) ? numSortedDesc : numSortedAsc;
                var result = max - min;

                return PoopyKaprekar(result, depth += 1);
            }
        }

        public static int[] PoopyIndexOfCapitals(this string str)
        {
            return str.Where(c => char.IsUpper(c)).Select(c => str.IndexOf(c)).ToArray();
        }

        public static string PoopyReverseCase(this string str)
        {
            return string.Join("", str.Select(c => char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c)));
        }

        public static double[] PoopyCountPosSumNeg(this double[] arr)
        {
            return new double[] { arr.Where(i => i >= 0).Count(), arr.Where(i => i < 0).Count() };
        }

        public static string[] PoopyConvertArrayToStrings(this object[] arr)
        {
            return arr.Select(x => x.ToString()).ToArray();
        }

        public static double[] PoopyFindLargestInEachArray(this double[][] arr)
        {
            return arr.Select(x => x.Max()).ToArray();
        }

        public static bool PoopyFractionGreaterThanOne(this string str)
        {
            var nums = str.Split("/").Select(i => int.Parse(i)).ToArray();
            return (float)nums[0] / nums[1] > 1;
        }

        public static string PoopyBomb(this string str)
        {
            return str.ToLower().Contains("bomb") ? "Duck!!!" : "There is no bomb, relax.";
        }

        public static int[] PoopyMultiplyByLength(this int[] arr)
        {
            return arr.ToList().Select(i => i * arr.Length).ToArray();
        }

        public static int PoopyCountVowels(this string str)
        {
            var vowelArray = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var count = 0;
            str.ToList().ForEach(c => {
                if (vowelArray.Contains(c))
                {
                    count++;
                }
            });
            return count;
        }

        public static bool PoopyPalindromeDescendents(this int num)
        {
            var numString = string.Concat(num.ToString().Select(c => c));

            if (numString.SequenceEqual(numString.Reverse()))
            {
                return true;
            }
            else
            {
                if (numString.Length == 2)
                {
                    return false;
                }
                else
                {
                    var newNum = int.Parse(string.Concat(Enumerable.Zip(numString, numString.Skip(1), (a, b) => (a - 48) + (b - 48)).Where((v, i) => i % 2 == 0)));
                    return PoopyPalindromeDescendents(newNum);
                }
            }
        }
        /// <summary>
        /// Deletes all files of a specified type within a given file path. Returns a list of the files deleted.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public static IEnumerable<string> PoopyKill(this string directoryPath, string fileType)
        {
            string[] paths = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            var pathList = paths.Select(path => path.Substring(path.LastIndexOf(".") + 1));
            var validFileList = pathList.Where(result => result == fileType);
            validFileList.ToList().ForEach(result => File.Delete(result));
            return validFileList;
        }

        private static string Poopify<T>(IEnumerable<T> collection)
        {
            var directoryPath = "C:/path/to/files";
            directoryPath.PoopyKill(".png");
            return string.Join(Environment.NewLine, collection);
        }
    }
}