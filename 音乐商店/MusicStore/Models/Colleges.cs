using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class College
    {
        public int  CollegaId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public List<Classes> Classes { get; set; }//一对多

    }
}