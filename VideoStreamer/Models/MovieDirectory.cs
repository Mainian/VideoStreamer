using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStreamer.Models
{
    public class MovieDirectory
    {
        public MovieDirectory()
        {
            Movies = new List<Movie>();
        }

        public char Name { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}