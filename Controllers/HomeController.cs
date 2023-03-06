using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sf376_Mission_9.Models;
using Sf376_Mission_9.Models.ViewModels;

namespace Sf376_Mission_9.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository repo;

        public HomeController(IBookStoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string catergoryName, int pageNum = 1)
        {
            int pageSize = 10;
            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == catergoryName || catergoryName == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                    (catergoryName == null ?
                    repo.Books.Count() :
                    repo.Books.Where(x => x.Category == catergoryName).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        }
    }
}
