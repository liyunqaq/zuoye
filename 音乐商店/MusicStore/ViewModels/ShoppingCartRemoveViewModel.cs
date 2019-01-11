using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    /// <summary>
    /// 删除购物车视图类
    /// </summary>
    public class ShoppingCartRemoveViewModel
    {
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }//和购物车中的AlbumId匹配
        public decimal CartTotal { get; set; }//购物车商品总价
        public string Message { get; set; }
    }
}