using System;
using WakeMobile.Models;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace WakeMobile.Services
{
    public interface IChannelService
    {
        List<Channel> GetChannels();
        Channel GetChannelById(int id);
        Channel CreateChannel(Channel channel, IFormFile fileBanner, IFormFile fileIcon);
        Channel UpdateChannel(int id, Channel channel, IFormFile fileBanner);
        bool DeleteChannel(int id);
    }
}
