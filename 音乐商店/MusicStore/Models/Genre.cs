using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    // GET: Genre
    /// <summary>
    /// 音乐流派/音乐分类
    /// </summary>
    public class Genre
    {
        public int GenreId { get; set; }//自动属性
        [DisplayName("专辑")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}