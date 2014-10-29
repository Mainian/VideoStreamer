using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Net;

namespace VideoStreamer.Models
{
    public class VideoStream
    {
        private readonly string _filename;
        private readonly string _filepath;
        private readonly string _ext;

        public VideoStream(string filepath, string ext)
        {
            _filepath = @filepath;
            _ext = @ext;
            _filename = @filepath + "." + ext;
        }

        public string FilePath
        {
            get
            {
                return _filepath;
            }
        }

        public string Ext
        {
            get
            {
                return _ext;
            }
        }

        public async void WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
        {
            try
            {
                var buffer = new byte[65536];

                using (var video = File.Open(_filename, FileMode.Open, FileAccess.Read))
                {
                    var length = (int)video.Length;
                    var bytesRead = 1;

                    while (length > 0 && bytesRead > 0)
                    {
                        bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                        await outputStream.WriteAsync(buffer, 0, bytesRead);
                        length -= bytesRead;
                    }
                }
            }
            catch (HttpException ex)
            {
                return;
            }
            finally
            {
                outputStream.Close();
            }
        }
    }
}