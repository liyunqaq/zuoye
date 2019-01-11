using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    // GET: Artist
    /// <summary>
    /// 艺术家
    /// </summary>
    public class Artist
    {
        public int ArtistId { get; set; }//自动属性
        [DisplayName("歌手")]
        public string Name { get; set; }
        
    }
}