using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AirDrop.Models
{
    [DataContract]
    public class DataPoints
    {

        public DataPoints(string label, float y)
        {
            this.Label = label;
            this.Y = y;
        }

        [DataMember(Name = "label")]
        public string Label = "";

        [DataMember(Name = "y")]
        public Nullable<float> Y = null;
    }
}
