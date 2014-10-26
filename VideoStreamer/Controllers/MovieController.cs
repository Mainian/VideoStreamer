using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStreamer.Models;

namespace VideoStreamer.Controllers
{
    public class MovieController : Controller
    {
        //
        // GET: /Movie/

        public ActionResult Index()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"Z:\");
            IList<Movie> movies = getMovies(dir);
            movies.GroupBy(mov => mov.Title[0]);
            return View(movies);
        }

        public ActionResult MovieDirectory()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"Z:\");
            IList<MovieDirectory> movieDirectories = getMovieDirectories(dir);


            return View(movieDirectories);
        }

        //
        // GET: /Movie/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movie/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movie/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movie/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private IList<MovieDirectory> getMovieDirectories(System.IO.DirectoryInfo dir)
        {
            IList<Movie> movies = getMovies(dir);
            movies.GroupBy(x => x.Title[0]);

            List<MovieDirectory> directories = new List<MovieDirectory>();

            foreach (Movie mov in movies)
            {
                var myDir = directories.FirstOrDefault(x => x.Name == (mov.Title[0].ToString().ToUpper())[0]);
                if (myDir != null)
                    myDir.Movies.Add(mov);
                else
                {
                    MovieDirectory movieDirectory = new MovieDirectory();
                    movieDirectory.Name = (mov.Title[0].ToString().ToUpper())[0];
                    movieDirectory.Movies.Add(mov);
                    directories.Add(movieDirectory);
                }
                
            }

            //for (int i = 0; i < 256; i++)
            //{
            //    var mov = movies.Where(x => x.Title[0] == (char)i);
            //    if(mov.Count() > 0)
            //    {
            //        MovieDirectory directory = new MovieDirectory();
            //        directory.Name = (char)i;
            //        foreach (Movie m in mov)
            //            directory.Movies.Add(m);

            //        directories.Add(directory);
            //    }
            //}

            return directories;

        }

        private IList<Movie> getMovies(System.IO.DirectoryInfo dir)
        {
            List<Movie> movies = new List<Movie>();
            foreach (System.IO.DirectoryInfo d in dir.GetDirectories())
            {
                movies.AddRange(getMovies(d));
            }

            foreach (System.IO.FileInfo info in dir.GetFiles())
            {

                if (info.Extension.ToLower() == ".mp4" || info.Extension.ToLower() == ".iso" || info.Extension.ToLower() == ".mkv")
                {
                    Movie movie = new Movie();
                    movie.Title = info.Name;
                    movie.FullName = info.FullName;

                    movies.Add(movie);
                }
            }

            return movies;
        }
    }
}
