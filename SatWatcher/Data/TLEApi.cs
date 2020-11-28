using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SatWatcher.Satellites;

namespace SatWatcher.Data
{
    class TLEApi
    {
        public static Result<Satellite> GetSatellite(long id)
        {
            string url = "https://data.ivanstanojevic.me/api/tle?search=" + id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            string response;

            try
            {
                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var responseReader = new StreamReader(webStream);
                response = responseReader.ReadToEnd();
                responseReader.Close();
            }
            catch (WebException e)
            {
                return Result.Failure<Satellite>(e.Message);
            }

            var tleResponse = JObject.Parse(response);
            var results = tleResponse["member"]?.Children().ToList();

            if (results?.Count != 1)
            {
                return Result.Failure<Satellite>($"{results.Count} satellites with this number were found");
            }

            var result = results.First();
            return new Satellite(
                GetValue<long>(result, "satelliteId"),
                GetValue<string>(result, "name"),
                GetValue<string>(result, "line1"),
                GetValue<string>(result, "line2")
            );
        }

        public static Result<TleLines> GetCurrentTleData(Satellite sat)
        {
            var satellite = GetSatellite(sat.ID);

            if (satellite.IsFailure)
                return Result.Failure<TleLines>(satellite.Error);

            return new TleLines(
                satellite.Value.ID,
                satellite.Value.TleLine1,
                satellite.Value.TleLine2
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
