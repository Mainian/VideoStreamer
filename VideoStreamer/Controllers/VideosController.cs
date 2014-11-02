using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;

namespace VideoStreamer.Controllers
{
    public class VideosController : ApiController
    {
        public HttpResponseMessage Get(string filename, string ext)
        {
            var video = new VideoStreamer.Models.VideoStream(filename, ext);

            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(video.WriteToStream, new System.Net.Http.Headers.MediaTypeHeaderValue("video/" + ext));

            return response;
        }
    }
}