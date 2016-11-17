using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Learn_Amazon_SQS
{
    public class LocationModel
    {

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ToJson()
        {
            var json = JsonConvert.SerializeObject(this);
            return json;
        }
    }
}
