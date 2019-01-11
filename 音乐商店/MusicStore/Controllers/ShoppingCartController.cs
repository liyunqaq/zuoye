using MusicStore.Models;
using MusicStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicStoreDB db = new MusicStoreDB();
        // GET: ShoppingCart
        /// <summary>
        /// 购物车列表视图
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(db, this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }
        public ActionResult AddToCart(int id)
        {
            var addAlbum = db.Albums.Single(x => x.AlbumId == id);//确定需要添加至购物车的Album数据
            var cart = ShoppingCart.GetCart(db, this.HttpContext);//获取购物车列表
            cart.AddToCart(addAlbum);//将Album数据添加至购物车
            db.SaveChanges();//实例化数据
            return RedirectToAction("Index");
        }
        public ActionResult youhuijia(int id)
        {
            var addAlbum = db.Albums.Single(x => x.AlbumId == id);//确定需要添加至购物车的Album数据
            var cart = ShoppingCart.GetCart(db, this.HttpContext);//获取购物车列表
            addAlbum.Price *= 0.5m;
            cart.AddToCart(addAlbum);//将Album数据添加至购物车
            db.SaveChanges();//实例化数据
            return RedirectToAction("Index");
        }
        public ActionResult EmptyCart()
        {
            var cart = ShoppingCart.GetCart(db, this.HttpContext);//获取购物车列表
            cart.EmptyCart();//将Album数据添加至购物车
            db.SaveChanges();//实例化数据
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(db, this.HttpContext);//获取购物车列表
            string albumName = db.Carts.Single(x => x.RecordId == id).Album.Title;//二次确认
            int itemCount = cart.RemoveFromCart(id);
            db.SaveChanges();
            string removed = (itemCount > 0) ? "复制" : string.Empty;
            var result = new ShoppingCartRemoveViewModel
            {
                Message = removed + albumName + "唱片已被移除购物车",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(result);
        }
    }
}