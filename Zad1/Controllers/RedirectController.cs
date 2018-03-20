using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.DataAccessLayer;

namespace webdev.Controllers
{
    public class RedirectController:Controller
    {
        private ILinkDataRepository repository;

        public RedirectController(ILinkDataRepository repository)
        {
            this.repository = repository;
        }

        [Route("/{hash}")]
        public void RedirectFromHash(string hash)
        {
            string finalUrl = repository.GetLinkFromHash(hash);
            Response.Redirect(finalUrl);
        }
    }
}
