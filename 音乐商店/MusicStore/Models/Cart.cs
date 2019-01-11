using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    // GET: Cart
    /// <summary>
    /// 购物车
    /// </summary>
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }//自动属性
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Album Album { get; set; }
    }
}