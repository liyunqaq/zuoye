using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class SampleLinqAndLambdaController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();

        //查询歌手表
        public ActionResult SearchTableArtist()
        {
            //Linq表达式
            var artistList1 = from x in db.Set<Artist>() select x;
            //Lambda表达式
            var artists1 = db.Set<Artist>().Select(x => x);
            //Linq单条件查询
            artistList1 = from c in db.Set<Artist>()
                          where c.Name.Contains("AC")//等效SQL：where name like "%AC%"
                          select c;


            //Linq多条件查询
            artistList1 = from c in db.Set<Artist>()
                          where (c.Name.Contains("AC")&&c.ArtistId==5)//等效SQL：where name like "%AC%"
                          select c;



            //Linq多表查询
            var query1 = from a in db.Set<Album>()
                          join b in db.Set<Genre>() on a.Genre.GenreId equals b.GenreId
                          select a;

            //Linq多表，带条件查询
            query1 = from x in db.Set<Album>()
                     join y in db.Artists on x.Artist.ArtistId equals y.ArtistId
                     where y.Name.Contains("ac")
                     select x;

            //查询Album、Artist，指定列表ArtistName、AlbumTitle、Price
            //多表并指定列
            var albumAndArtist = from a in db.Set<Album>()
                                 join b in db.Set<Artist>() on a.Artist.ArtistId equals b.ArtistId
                                 select new
                                 {
                                     ArtistName = b.Name,
                                     AlbumTitle = a.Title,
                                     Price = a.Price
                                 };

                      

            //Lambda单条件查询
            artists1 = db.Set<Artist>().Select(x => x).Where(x => x.Name.Contains("AC"));



            //Lambda多条件查询
            artists1 = db.Set<Artist>()
                .Where(x => x.Name.Contains("AC") && x.ArtistId == 5);


            //Lambda多表查询
            var query2 = db.Set<Album>()
                .Join(db.Set<Genre>(), x => x.Genre.GenreId, y => y.GenreId, (x, y) => x);


            //查询Album、Artist，指定列表ArtistName、AlbumTitle、Price，只取第一条数据
            var query3 = db.Set<Album>()
                .Join(db.Set<Artist>(), a => a.Artist.ArtistId, b => b.ArtistId, (a, b) => a)
                .Select(a => (new { title = a.Title, price = a.Price, artist = a.Artist.Name }))
                //.OrderBy(x => x.price);//升序排序
                //.OrderByDescending(x=>x.price);//降序排序
                .FirstOrDefault();//取默认第一条数据



            return View();
        }
        
        // GET: SampleLinqAndLambda
        public ActionResult Index()
        {
            return View();
        }
    }
}