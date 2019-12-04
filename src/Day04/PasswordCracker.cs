using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class PasswordCracker
    {
        public static IEnumerable<string> FindAllPasswordsInRange(int min, int max, bool strict = false)
        {
            for (int i = min; i < max; i++)
            {
                if(MeetsRequirements(i.ToString(), strict))
                {
                    yield return i.ToString();
                }
            }
        }

        public static bool MeetsRequirements(string password, bool strict = false)
        {
            if(password.Length != 6)
            {
                return false;
            }

            if(!SequenceNeverDecreases(password))
            {
                return false;
            }

            if(strict)
            {
                return SequenceContainsPairStrict(password);
            }

            return SequenceContainsPair(password);
        }

        static bool SequenceNeverDecreases(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if(i == 0)
                {
                    continue;
                }

                if(password[i] < password[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        static bool SequenceContainsPairStrict(string password)
        {
            int consecutiveDigits = 1;
            for (int i = 0; i < password.Length; i++)
            {
                if(i == 0)
                {
                    continue;
                }

                if(password[i] == password[i - 1])
                {
                    consecutiveDigits++;
                }
                else
                {
                    if(consecutiveDigits == 2)
                    {
                        return true;
                    }

                    consecutiveDigits = 1;
                }
            }

            return consecutiveDigits == 2;
        }

        static bool SequenceContainsPair(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if(i == 0)
                {
                    continue;
                }

                if(password[i] == password[i - 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
