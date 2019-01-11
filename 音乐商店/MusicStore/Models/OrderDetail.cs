using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    // GET: OderDetail
    /// <summary>
    /// 订单详情
    /// </summary>
    public class OrderDetail
    {

        public int OrderDetailId { get; set; }//自动属性
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }


        public virtual Album Album { get; set; }
        public virtual Order Order { get; set; }
    }
}