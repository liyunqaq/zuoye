using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreDB db = new MusicStoreDB();
        public ActionResult Index()
        {
            var albums = db.Albums
                .OrderByDescending(x => x.AlbumId)
                .Take(5)
                .ToList();
            return View(albums);
            
        }
        public ActionResult Search(string str)
        {
            var albums = db.Albums
                .Include("Artist")
                .Include("Genre")
                .Where(x => x.Title.Contains(str) || x.Genre.Name.Contains(str) || x.Artist.Name.Contains(str));
            //return View(albums);
            return PartialView("_Search", albums);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 促销方法实现
        /// </summary>
        /// <returns></returns>
        public ActionResult DailyDeal()
        {
            var album = db.Albums
                .OrderBy(x => System.Guid.NewGuid())//通过动态生成NewID的方式，完成半随机数据选择
                .First();
            album.Price *= 0.5m;
            return PartialView("_DailyDeal", album);
        }
    }
}