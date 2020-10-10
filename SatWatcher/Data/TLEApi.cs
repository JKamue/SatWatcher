using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SatWatcher.Satellites;

namespace SatWatcher.Data
{
    class TLEApi
    {
        public static Satellite GetSatellite(long id)
        {
            string url = "https://data.ivanstanojevic.me/api/tle?search=" + id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();

            var tleResponse = JObject.Parse(response);
            responseReader.Close();


            var results = tleResponse["member"]?.Children().ToList().First();
            return new Satellite(
                GetValue<long>(results, "satelliteId"),
                GetValue<string>(results, "name"),
                GetValue<string>(results, "line1"),
                GetValue<string>(results, "line2")
            );
        }

        public static TleLines GetCurrentTleData(Satellite sat)
        {
            var satellite = GetSatellite(sat.ID);
            return new TleLines(
                satellite.ID,
                satellite.TleLine1,
                satellite.TleLine2
            );
        }

        public static T GetValue<T>(JToken jToken, string key, T defaultValue = default(T))
        {
            dynamic ret = jToken[key];
            if (ret == null) return defaultValue;
            if (ret is JObject) return JsonConvert.DeserializeObject<T>(ret.ToString());
            return (T)ret;
        }
    }

    struct TleLines
    {
        public readonly float Id;
        public readonly string Line1;
        public readonly string Line2;

        public TleLines(float id, string tleLine1, string tleLine2)
        {
            Id = id;
            Line1 = tleLine1;
            Line2 = tleLine2;
        }
    }
}
