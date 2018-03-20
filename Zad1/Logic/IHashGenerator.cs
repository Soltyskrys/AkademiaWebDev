using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdev.Logic
{
    public interface IHashGenerator
    {
        string Generate(int number);
    }
}
