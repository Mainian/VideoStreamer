using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace VideoStreamer.CustomResult
{
    public class VideoResult : ActionResult
    {
        private string _filepath;
        private string _name;

        public VideoResult(string filepath, string name)
        {
            _filepath = filepath;
            _name = name;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            //use filepath instead of HostingEnviornment

            //Change me
            //var videoFilePath = HostingEnvironment.MapPath("~/VideoFile/Win8.mp4");

            //header information
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment;filename="+_name);
            var file = new FileInfo(_filepath);
            if (file.Exists)
            {
                var stream = file.OpenRead();
                var bytesinfile = new byte[stream.Length];
                stream.Read(bytesinfile, 0, (int)file.Length);
                context.HttpContext.Response.BinaryWrite(bytesinfile);
            }
        }
    }
}