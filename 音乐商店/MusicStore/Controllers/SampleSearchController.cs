using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class SampleSearchController : Controller
    {
        MusicStoreDB db = new MusicStoreDB();
        // GET: SampleSearch
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(string str)
        {
            var albums = db.Albums
                .Include("Artist")
                .Include("Genre")
                .Where(x => x.Title.Contains(str) || x.Genre.Name.Contains(str) || x.Artist.Name.Contains(str));
            return View(albums);
        }
        public ActionResult Details(int id)
        {
            //var album = db.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            var album = db.Albums.Find(id);
            return View(album);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }
        [ValidateAntiForgeryToken]//防止重复提交
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Search");
        }


    }
}