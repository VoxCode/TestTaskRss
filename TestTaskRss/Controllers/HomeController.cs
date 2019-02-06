using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTaskRss.Models;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;

namespace TestTaskRss.Controllers
{
    public class HomeController : Controller
    {
        private readonly RssContext db = new RssContext();

        public ActionResult Index()
        {          
            return View();
        }

        public ActionResult PostPage(string id, string sort, int? page)
        {
            if (id == "" || id == null)
            {
                id = "Все";
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<RssSources> sources = db.RssSources.ToList();            
            SelectList items = new SelectList(sources, "Name", "Name");
            ViewBag.Sources = items;
            IEnumerable<RssNews> data = db.RssNews.ToList();
            if (id != "Все")
            {
                data = data.Where(p => p.RssSources.Name == id);
            }
            if (sort == "date")
            {
                data = data.OrderByDescending(p => p.DateTime);
            }
            else
            {
                data = data.OrderByDescending(p => p.RssSources.Name);
            }

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult PostPage(string id, string sort)
        {
            if (id == "" || id == null)
            {
                id = "Все";
            }
            int pageSize = 10;
            int pageNumber = 1;
            IEnumerable<RssSources> sources = db.RssSources.ToList();
            SelectList items = new SelectList(sources, "Name", "Name");
            ViewBag.Sources = items;
            IEnumerable<RssNews> data = db.RssNews.ToList();
            if (id != "Все")
            {
                data = data.Where(p => p.RssSources.Name == id);
            }
            if (sort == "date")
            {
                data = data.OrderByDescending(p => p.DateTime);
            }
            else
            {
                data = data.OrderByDescending(p => p.RssSources.Name);
            }
            return View(data.ToPagedList(pageNumber, pageSize));
        }

        






        public ActionResult AjaxPage()
        {
           
            IEnumerable<RssSources> sources = db.RssSources.ToList();
            SelectList items = new SelectList(sources, "Name", "Name");
            ViewBag.Sources = items;          

            return View();
        }

        [HttpPost]
        public ActionResult AjaxPage(string id)
        {          
            return View("AjaxPage", (object)id);
        }

        public ActionResult AjaxPageData(string id, string sort, int? page)
        {
            if (id == "" || id == null){
                id = "Все";
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IEnumerable<RssSources> sources = db.RssSources.ToList();
            SelectList items = new SelectList(sources, "Name", "Name");
            ViewBag.Sources = items;
            IEnumerable<RssNews> data = db.RssNews.ToList();
            if (id != "Все")
            {
                data = data.Where(p => p.RssSources.Name == id);
            }
            if (sort == "date")
            {
                data = data.OrderByDescending(p => p.DateTime);
            }
            else
            {
                data = data.OrderByDescending(p => p.RssSources.Name);
            }
            return PartialView(data.ToPagedList(pageNumber, pageSize));

           
        }
    }
}