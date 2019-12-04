using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class PasswordCracker
    {
        public static IEnumerable<string> FindAllPasswordsInRange(int min, int max)
        {
            for (int i = min; i < max; i++)
            {
                if(MeetsRequirements(i.ToString()))
                {
                    yield return i.ToString();
                }
            }
        }

        public static bool MeetsRequirements(string password)
        {
            if(password.Length != 6)
            {
                return false;
            }

            bool hasAdjacentPair = false;

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

                if(!hasAdjacentPair && password[i] == password[i - 1])
                {
                    hasAdjacentPair = true;
                }
            }

            return hasAdjacentPair;
        }
    }
}
