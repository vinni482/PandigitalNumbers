using System;
using System.Linq;

namespace PandigitalNumbers
{
    class Program
    {
        private static bool AreDigitsUnique(long num)
        {
            string numStr = num.ToString();
            if (numStr.Distinct().Count() == numStr.Count())
                return true;

            return false;
        }

        static void Main(string[] args)
        {
            long res = 0;
            for (int div17 = 017; div17 <= 987; div17 += 17) //is divisible by 17
            {
                if (!AreDigitsUnique(div17)) continue;

                for (int div13 = 013; div13 <= 987; div13 += 13) //is divisible by 13
                {
                    if (!AreDigitsUnique(div13) || div13 % 100 != div17 / 10) continue; //last 2 digits should be equal to first 2 digits from previous loop

                    for (int div11 = 011; div11 <= 987; div11 += 11) //is divisible by 11
                    {
                        if (!AreDigitsUnique(div11) || div11 % 100 != div13 / 10) continue;

                        for (int div7 = 014; div7 <= 987; div7 += 7) //is divisible by 7
                        {
                            if (!AreDigitsUnique(div7) || div7 % 100 != div11 / 10) continue; 

                            for (int div5 = 015; div5 <= 987; div5 += 5) //is divisible by 5
                            {
                                if (!AreDigitsUnique(div5) || div5 % 100 != div7 / 10) continue;

                                for (int div3 = 012; div3 <= 987; div3 += 3) //is divisible by 3
                                {
                                    if (!AreDigitsUnique(div3) || div3 % 100 != div5 / 10) continue;

                                    for (int div2 = 012; div2 <= 987; div2 += 2) //is divisible by 2
                                    {
                                        if (!AreDigitsUnique(div2) || div2 % 100 != div3 / 10) continue;

                                        for (int i = 1; i <= 9; i++) //first digit can be from 1 to 9
                                        {
                                            long pandigital = long.Parse(string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", i, div2 / 100, div3 / 100, div5 / 100, div7 / 100, div11 / 100, div13 / 100, div17));
                                            if (!AreDigitsUnique(pandigital)) continue;

                                            res += pandigital;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {res}");
        }
    }
}
