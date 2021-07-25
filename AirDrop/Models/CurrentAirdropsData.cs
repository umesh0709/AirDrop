using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AirDrop.Models
{
    public class CurrentAirdropsData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public string Info { get; set; }
        public byte[] DropImage { get; set; }

        public string ParticipateLink { get; set; }


    }
}
