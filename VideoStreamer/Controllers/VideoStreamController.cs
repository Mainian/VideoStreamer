using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
//using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;


namespace VideoStreamer.Controllers
{
    //public class VideoStreamController : ApiController
    //{
    //    public HttpResponseMessage Get(string filepath, string ext)
    //    {
    //        var video = new VideoStreamer.Models.VideoStream(filepath, ext);

    //        var response = Request.CreateResponse();
    //        response.Content = new PushStreamContent(video.WriteToStream, new System.Net.Http.Headers.MediaTypeHeaderValue("video/" + ext));

    //        return response;
    //    }
    //}

    public class VideoStreamController : ApiController
    {
        //[HttpGet]
        //public ActionResult GetVideoStream(string filepath, string ext)
        //{
        //    var video = new VideoStreamer.Models.VideoStream(filepath, ext);
        //    //ext = "mp4";
        //    //return Json(new PushStreamContent(video.WriteToStream), ""<html><body><video width="480"height="320" controls="controls" autoplay="autoplay"><source src="/api/videos/webm/CkY96QuiteBitterBeings" type="video/webm"></video></body></html>"
        //    return Json(new PushStreamContent(video.WriteToStream, new System.Net.Http.Headers.MediaTypeHeaderValue("video/" + ext)), JsonRequestBehavior.AllowGet);
        //    //return View(video);
        //}

        public HttpResponseMessage Get(string filepath, string ext)
        {
            var video = new VideoStreamer.Models.VideoStream(filepath, ext);

            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(video.WriteToStream, new System.Net.Http.Headers.MediaTypeHeaderValue("video/"+ext));

            return response;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}
