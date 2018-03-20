using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.Models;

namespace webdev.DataAccessLayer
{
    public interface ILinkDataRepository
    {
        IEnumerable<LinkData> GetLinks();
        void Add(LinkData linkData);
        void Remove(string hash);
        string GetLinkFromHash(string hash);
    }
}
