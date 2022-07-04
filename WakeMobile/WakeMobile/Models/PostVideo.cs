using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WakeMobile.Models
{
    public class PostVideo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime Posted { get; set; }
        public string VideoURL { get; set; } = string.Empty;
        public string ThumbUrl { get; set; } = string.Empty;
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
