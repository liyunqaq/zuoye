using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    // GET: Album

    /// <summary>
    /// 唱片集,音乐专辑类
    /// </summary>
    public class Album
    {
        [ScaffoldColumn(false)]//设定表单编辑时允许隐藏的字段
        public int AlbumId { get; set; }//自动属性


        [DisplayName("链接")]
        public string AlbumArtUrl { get; set; }

        
        public int ArtistId { get; set; }
        [Required(ErrorMessage ="必填内容（音乐专辑名）")]//定义必填字段

        
        public int GenreId { get; set; }


        [DisplayName("价格")]
        public decimal Price { get; set; }


        [DisplayName("专辑")]
        public string Title { get; set; }

        
        public virtual Genre Genre { get; set; }
        
        public virtual Artist Artist { get; set; }

    }
}