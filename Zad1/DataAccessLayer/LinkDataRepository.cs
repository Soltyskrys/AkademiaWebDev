using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.Models;

namespace webdev.DataAccessLayer
{
    public class LinkDataRepository : ILinkDataRepository
    {
        List<LinkData> links;
        private int currentId;

        public LinkDataRepository()
        {
            currentId = 0;
            links = new List<LinkData>();
        }

        public void Add(LinkData linkData)
        {
            currentId++;
            linkData.Id = currentId;
            links.Add(linkData);
        }

        public string GetLinkFromHash(string hash)
        {
            return links.First(x => x.Hash.Equals(hash)).Link;
        }

        public IEnumerable<LinkData> GetLinks()
        {
            return links;
        }

        public void Remove(string hash)
        {
            links.RemoveAll(x => x.Hash.Equals(hash));
        }
    }
}
