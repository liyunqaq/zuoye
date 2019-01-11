using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public partial class ShoppingCart
    {
        MusicStoreDB db = new MusicStoreDB();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(MusicStoreDB db,HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCardId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCardId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        public void EmptyCart()
        {
            var cartIrems = db.Carts.Where(cart => cart.CartId == ShoppingCartId);
            foreach(var item in cartIrems)
            {
                db.Carts.Remove(item);
            }
            db.SaveChanges();
        }
        /// <summary>
        /// 添加音乐专辑到购物车
        /// </summary>
        /// <param name="album"></param>
        public void AddToCart(Album album)
        {
            var cartItem = db.Carts.SingleOrDefault(x => x.CartId == ShoppingCartId && x.AlbumId == album.AlbumId);
            if(cartItem==null)
            {
                cartItem = new Cart
                {
                    AlbumId = album.AlbumId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.Carts.Add(cartItem);//完成购物车的添加
            }
            else
            {
                cartItem.Count++;
            }
            db.SaveChanges();//完成购物车的实例化
        }
        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveFromCart(int id)
        {
            //获取购物车数据
            var cartItem = db.Carts.Single(x => x.CartId == ShoppingCartId && x.RecordId == id);
            int itemCount = 0;
            if (cartItem!=null)
            {
                if(cartItem.Count>1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }
                db.SaveChanges();
            }
            return itemCount;
        }
        /// <summary>
        /// 获取购物车数据
        /// </summary>
        /// <returns></returns>
        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(x => x.CartId == ShoppingCartId).ToList();
        }
        /// <summary>
        /// 订单创建
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int CreatOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();

            foreach(var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    AlbumId = item.AlbumId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Album.Price,
                    Quantity = item.Count
                };
                orderTotal += (item.Count * item.Album.Price);
                db.OrderDetails.Add(orderDetail);
            }
            order.Total = orderTotal;
            db.Orders.Add(order);
            db.SaveChanges();
            EmptyCart();
            return order.OrderId;
        }
        public int GetCount()
        {
            int? count=(from cartItems in db.Carts
                where cartItems.CartId==ShoppingCartId
                select (int?)cartItems.Count).Sum();
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Album.Price).Sum();
            return total ?? decimal.Zero;
        }
        /// <summary>
        /// 关联登录用户和购物车
        /// </summary>
        /// <param name="username"></param>
        public void MigrateCart(string username)
        {
            var shoppingCart = db.Carts.Where(x => x.CartId == ShoppingCartId);
            foreach(Cart item in shoppingCart)
            {
                item.CartId = username;
            }
            db.SaveChanges();
        }
    }
}