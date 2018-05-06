using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.Models;

namespace webdev.DataAccessLayer
{
    public interface ILinkDataRepository
    {
        (IEnumerable<LinkData> Links,int allLinksNumber) GetLinks(string search,int page,int pageSize);
        void Add(LinkData linkData);
        void Update(LinkData linkData);
        void Remove(string hash);
        string GetLinkFromHash(string hash);
        void UpdateLinkAssignedToHash(string hash, string link);
    }
}
