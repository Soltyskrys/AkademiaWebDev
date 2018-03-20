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

        public IActionResult Index()
        {
            var viewModel = repository.GetLinks().Select(x => new LinkDataViewModel() { Link = x.Link, Hash = x.Hash });
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddLinkInput input)
        {
            var linkData = new LinkData() { Link = input.Link };
            repository.Add(linkData);
            linkData.Hash = generator.Generate(linkData.Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(RemoveLinkInput input)
        {
            repository.Remove(input.Hash);
            return RedirectToAction("Index");
        }

    }
}
