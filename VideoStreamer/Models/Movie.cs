using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStreamer.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string FullName { get; set; }
        public float Rating { get; set; }
        public string Ext { get; set; }
    }
}