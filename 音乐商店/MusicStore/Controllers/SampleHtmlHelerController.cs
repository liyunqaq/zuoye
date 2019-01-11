using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    /// <summary>
    /// HTML辅助方法实例代码
    /// </summary>
    public class SampleHtmlHelerController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();//数据上下文
        // GET: SampleHtmlHelper
        public ActionResult Index()
        {
            var albums = db.Albums.ToList();
            return View(albums);
        }
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "name");
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        [HttpPost]//HttpPost操作选择器
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {

            //happy path:当记录状态/模型状态为：有效时
            //sad path：当模型状态：无效时执行当操作和采用路径
            if (ModelState.IsValid)
            {
                //告诉数据上下文，对象在DB已经存在，采用修改模式
                db.Entry(album).State = EntityState.Modified;

                album.Genre = db.Genres.Where(x => x.GenreId == album.GenreId).FirstOrDefault();
                album.Artist = db.Artists.Where(x => x.ArtistId == album.ArtistId).FirstOrDefault();
                //在数据上下文找那个通过SaveChange方法生成SQL update 命令完成对应记录的更新操作
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);//将对象album添加至当前集合Ablum中
                db.SaveChanges();//将数据添加至数据库
                return RedirectToAction("Index");//跳转到Index页面
            }
            //SelectList(db.Artists,"ArtistId","Name")
            //SelectList(数据表，"数据表主键“，前端显示内容 - - 字段”
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");//向前端页面传输一个对象
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewData["ArtistId"] = db.Artists.Where(x => x.ArtistId == 1).FirstOrDefault();
            return View();
        }
    }
}