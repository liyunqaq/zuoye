using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Classes
    {
        public int  ClassId { get; set; }
        public string Name{ get; set; }
        public int StudentNum { get; set; }
        public virtual College College { get; set;  }

    }
}