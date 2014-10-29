using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using VideoStreamer.CustomResult;

namespace VideoStreamer.Controllers
{
    public class VideoController : Controller
    {
        //public HttpResponseMessage Get(string filename, string ext)
        //{
        //    var response = Request.CreateResponse();
        //    response.Content = PushStreamContent(
        //}

        public ActionResult Index(string filepath, string name)
        {
            return View(new VideoResult(filepath, name));
        }
    }
}
