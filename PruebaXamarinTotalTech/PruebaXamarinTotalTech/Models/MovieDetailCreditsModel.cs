using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaXamarinTotalTech.Models
{
    public class MovieDetailCreditsModel
    {
        [JsonProperty("id")]
        public int id { get; set; } = 0;
        [JsonProperty("cast")]
        public List<CastModel> cast { get; set; }
        [JsonProperty("crew")]
        public List<CrewModel> crew { get; set; }

    }


}
