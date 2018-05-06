using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.DataAccessLayer;
using webdev.Logic;
using webdev.Models;

namespace webdev.Controllers
{
    public class LinksController :Controller
    {
        private ILinkDataRepository repository;
        private IHashGenerator generator;

        public LinksController(ILinkDataRepository repository,IHashGenerator generator)
        {
            this.repository = repository;
            this.generator = generator;
        }

        [HttpGet("api/links")]
        public IActionResult GetLinks([FromQuery]LinkRequest request)
        {
            var pageSize = 10;

            (IEnumerable<LinkData> links, int linksCount) = repository
                .GetLinks(request.SearchedLink, request.Page, pageSize);

            var result = links.Select(x => new LinkResult() { Link = x.Link, Hash = x.Hash });
            int maxPage = CountMaxPage(pageSize, linksCount);

            return Ok(new PageableResult<LinkResult>(result, request.Page, maxPage));
        }

        private static int CountMaxPage(int pageSize, int linksCount)
        {
            var maxPage = (linksCount / pageSize) + 1;
            if (maxPage > 1 && (linksCount % pageSize == 0)) maxPage--;
            return maxPage;
        }

        [HttpGet("api/links/{hash}")]
        public IActionResult GetLink(string hash)
        {
            string link = repository.GetLinkFromHash(hash);
            return Ok(new { link });
        }

        [HttpPost("api/links")]
        public IActionResult AddLink([FromBody]AddLinkInput input)
        {
            var linkData = new LinkData() { Link = input.Link };
            repository.Add(linkData);
            linkData.Hash = generator.Generate(linkData.Id);
            repository.Update(linkData);
            return Ok(new { response = "Ok" });
        }

        [HttpDelete("api/links")]
        public IActionResult RemoveLink(RemoveLinkInput input)
        {
            repository.Remove(input.Hash);
            return Ok(new { response = "Ok" });
        }

        [HttpPut("api/links")]
        public IActionResult ChangeLink([FromBody]ChangeLinkInput input)
        {
            repository.UpdateLinkAssignedToHash(input.Hash, input.Link);
            return Ok(new { response = "OK" });
        }
    }
}
