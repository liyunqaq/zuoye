using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    using System;
    using System.Collections.Generic;
    public partial class Carts
    {
        public int RecordId { get; set; }//自动属性
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }

        public virtual Album Album { get; set; }
    }
}