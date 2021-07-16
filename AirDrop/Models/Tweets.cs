using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirDrop.Models
{
    public class Tweets
    {
        [Key]
        public int? Id { get; set; }
        public string Tweetlink { get; set; }
    }
}
