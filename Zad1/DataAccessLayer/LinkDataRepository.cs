using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using webdev.Models;

namespace webdev.DataAccessLayer
{
    public class LinkDataRepository : ILinkDataRepository
    {
        private LinksContext Context { get; }

        public LinkDataRepository(LinksContext context)
        {
            Context = context;
        }

        public IEnumerable<LinkData> GetLinks()
        {
            return Context.LinksData;
        }

        public void Add(LinkData linkData)
        {
            Context.LinksData.Add(linkData);
            Context.SaveChanges();
        }

        public void Update(LinkData linkData)
        {
            Context.LinksData.Attach(linkData);
            Context.Entry(linkData).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Remove(string hash)
        {
            var removedLinkData = Context.LinksData.First(x => x.Hash.Equals(hash));
            Context.LinksData.Remove(removedLinkData);
            Context.SaveChanges();
        }

        public string GetLinkFromHash(string hash)
        {
            return Context.LinksData.First(x => x.Hash.Equals(hash)).Link;
        }

        public (IEnumerable<LinkData> Links, int allLinksNumber) GetLinks(string search, int page, int pageSize)
        {
            search = search.ToLower();
            var searchedLinks = Context.LinksData.Where(x => x.Link.ToLower().Contains(search));

            var links = searchedLinks
                .OrderBy(x=>x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return (Links:links, allLinksNumber: searchedLinks.Count());
        }

        public void UpdateLinkAssignedToHash(string hash,string link)
        {
            var updatedLink = Context.LinksData.First(x => x.Hash == hash);
            updatedLink.Link = link;
            Context.SaveChanges();
        }
    }
}
