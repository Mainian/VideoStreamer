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

        public string FullNameNoSpecials()
        {
            string fName = FullName.Replace(":\\", "-_");
            fName = fName.Replace("\\", "===");
            fName = fName.Replace(".", "_=_");
            return fName.Split('.')[0];
        }

        public Movie()
        {
        }

        public Movie(string specialName)
        {
            FullName = specialName.Replace("-_", ":\\");
            FullName = FullName.Replace("===", "\\");
            FullName = FullName.Replace("_=_",".");
        }
    }
}