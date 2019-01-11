using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        /// <summary>
        /// 购物车视图类
        /// </summary>
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}