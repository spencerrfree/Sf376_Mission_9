using Microsoft.AspNetCore.Mvc;
using Sf376_Mission_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sf376_Mission_9.Components
{
    public class CatergoriesViewComponent : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public CatergoriesViewComponent(IBookStoreRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCatergory = RouteData?.Values["categoryName"];

            var catergories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(catergories);
        }
    }
}
