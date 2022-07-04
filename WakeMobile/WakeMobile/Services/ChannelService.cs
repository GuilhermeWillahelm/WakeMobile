using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WakeMobile.Models;

namespace WakeMobile.Services
{
    public class ChannelService : IChannelService
    {
        HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7099/api/") };
        public readonly IUserService _userService;
        public ChannelService(IUserService userService) 
        {
            _userService = userService;
        }

        public Channel CreateChannel(Channel channel, IFormFile fileBanner, IFormFile fileIcon)
        {
            var data = JsonConvert.SerializeObject(channel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Channels", content).Result;

            if(!response.IsSuccessStatusCode)
            {
                return null;
            }

            return channel;
        }

        public bool DeleteChannel(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "Channels/" + id).Result;

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public Channel GetChannelById(int id)
        {
            Channel channel = new Channel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Channels/GetChannelByUser" + id).Result;

            if(response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                channel = JsonConvert.DeserializeObject<Channel>(data);
            }

            return channel;
        }

        public List<Channel> GetChannels()
        {
            List<Channel> channels = new List<Channel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Channels").Result;

            if(response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                channels = JsonConvert.DeserializeObject<List<Channel>>(data);
            }

            return channels;
        }

        public Channel UpdateChannel(int id, Channel channel, IFormFile fileBanner)
        {
            channel.UserId = id;
            var data = JsonConvert.SerializeObject(channel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "Channels", content).Result;

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return channel;
        }
    }
}
