using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirDrop.Models
{
    public class MultipleTables
    {
        public IEnumerable<CurrentAirdropsData> CryptoInfo { get; set; }
        public List<Tweets> Tweets { get; set; }
    }
}
