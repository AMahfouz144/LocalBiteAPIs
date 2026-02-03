using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Helper
    {
        public static string GeneratePassword()
        {
            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                 "0123456789",                  // digits
                  "!@$?_-"                      // non-alphanumeric
                };

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            List<char> chars = new List<char>();

            chars.Insert(rand.Next(0, 1),
                randomChars[0][rand.Next(0, randomChars[0].Length)]);

            chars.Insert(rand.Next(0, 1),
                randomChars[1][rand.Next(0, randomChars[1].Length)]);

            chars.Insert(rand.Next(0, 1),
                randomChars[2][rand.Next(0, randomChars[2].Length)]);

            chars.Insert(rand.Next(0, 1),
                randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < 8 || chars.Distinct().Count() < 8; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
