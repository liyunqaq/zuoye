using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();
        // GET: Store
        [AllowAnonymous]
        public ActionResult Index()
        {
            var albums = GetAlbums();
            return View(albums.ToList());
        }
        public List<Album> GetAlbums()
        {
            var albums = db.Albums
                .Include(x => x.Genre)
                .Include(x => x.Artist)
                .OrderByDescending(x=>x.AlbumId)//倒序
                .Take(100)//后100条数据
                .ToList();
            return albums;
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            var album = GetAlbums().Single(x => x.AlbumId == id);
            return View(album);
        }
    }
}