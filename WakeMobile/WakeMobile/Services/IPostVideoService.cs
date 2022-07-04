using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using WakeMobile.Models;

namespace WakeMobile.Services
{
    public interface IPostVideoService
    {
        List<PostVideo> GetAllVideos(string stringSearch);
        List<PostVideo> GetAllVideosPerChannel(int id);
        PostVideo GetPostVideo(int id);
        PostVideo CreatedPostVideo(PostVideo postVideo, IFormFile fileImage, IFormFile fileVideo);
        PostVideo EditVideo(int id, PostVideo postVideo, IFormFile fileImage, IFormFile fileVideo);
        bool DeleteVideo(int id);
    }
}
