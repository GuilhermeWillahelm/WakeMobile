using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WakeMobile.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public string SubtittleChannel { get; set; }
        public string ChannelDescription { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedChannel { get; set; }
        public string BannerURL { get; set; }
        public string IconURL { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<PostVideo> Videos { get; set; } = new List<PostVideo>();
    }
}