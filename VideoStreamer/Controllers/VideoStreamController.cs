using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;


namespace VideoStreamer.Controllers
{
    public class VideoStreamController : ApiController
    {
        public HttpResponseMessage Get(string filepath, string ext)
        {
            var video = new VideoStreamer.Models.VideoStream(filepath, ext);

            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(video.WriteToStream, new System.Net.Http.Headers.MediaTypeHeaderValue("video/" + ext));

            return response;
        }
    }
}
