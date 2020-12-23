using System;
using System.IO;
using System.Linq;

/// <summary>
/// Штанько Екатерина БПИ193. Реализация алгоритма Манакера.
/// Тесты:
/// 1) cabacabaabacabac
/// 2) DoGeeSeSeeGoD
/// 3) mumdidciviclevelracecarKooKoo
/// 4) KazAk
/// 5) gogogog
/// </summary>
namespace ShtankoEkaterina_193_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText(args[0]);
            int even = calculateD2(input).Sum(x => x); // Кол-во чет.
            int odd = calculateD1(input).Sum(x => x); // Кол-во нечет.
            File.WriteAllText(args[1], $"{even + odd} {even} {odd}"); 
        }

        /// <summary>
        /// Вычиляет кол-во палиндромов нечет. длины с центром в i
        /// </summary>
        /// <param name="s">строка</param>
        /// <returns> кол-во палиндромов нечет. длины с центром в i </returns>
        public static int[] calculateD1(string s)
        {
            int l = 0;
            int r = -1;
            int n = s.Length;
            int[] d1 = new int[n];
            for (int i = 0; i < n; i++)
            {
                int k = i > r ? 1 : Math.Min(r - i + 1, d1[r - i + l]);
                while (i + k < n && i - k >= 0 && s[i + k] == s[i - k])
                {
                    k++;
                }
                d1[i] = k;
                if (i + k - 1 > r)
                {
                    l = i - k + 1;
                    r = i + k - 1;
                }
            }
            return d1;
        }

        /// <summary>
        /// Вычиляет кол-во палиндромов чет. длины с центром в i
        /// </summary>
        /// <param name="s">строка</param>
        /// <returns> кол-во палиндромов чет. длины с центром в i </returns>
        public static int[] calculateD2(string s)
        {
            int l = 0;
            int r = -1;
            int n = s.Length;
            int[] d2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                int k = i > r ? 0 : Math.Min(r - i + 1, d2[r - i + l + 1]);
                while (i + k < n && i - k - 1 >= 0 && s[i + k] == s[i - k - 1])
                {
                    k++;
                }
                d2[i] = k;
                if (i + k - 1 > r)
                {
                    l = i - k;
                    r = i + k - 1;
                }
            }
            return d2;
        }
    }
}
