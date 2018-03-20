using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdev.Logic
{
    public class HashGenerator : IHashGenerator
    {
        private static readonly string SALT = "SAL&^^%$#^%#^%$&T123213535233425232143 %^$&^*$^43^%3";
        public string Generate(int number)
        {
            return new HashidsNet.Hashids(SALT).Encode(number);
        }
    }
}
