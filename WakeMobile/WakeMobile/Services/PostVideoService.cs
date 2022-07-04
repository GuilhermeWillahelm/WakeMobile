using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WakeMobile.Models;

namespace WakeMobile.Services
{
    public class PostVideoService : IPostVideoService
    {
        public PostVideo CreatedPostVideo(PostVideo postVideo, IFormFile fileImage, IFormFile fileVideo)
        {
            throw new NotImplementedException();
        }

        public bool DeleteVideo(int id)
        {
            throw new NotImplementedException();
        }

        public PostVideo EditVideo(int id, PostVideo postVideo, IFormFile fileImage, IFormFile fileVideo)
        {
            throw new NotImplementedException();
        }

        public List<PostVideo> GetAllVideos(string stringSearch)
        {
            throw new NotImplementedException();
        }

        public List<PostVideo> GetAllVideosPerChannel(int id)
        {
            throw new NotImplementedException();
        }

        public PostVideo GetPostVideo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
