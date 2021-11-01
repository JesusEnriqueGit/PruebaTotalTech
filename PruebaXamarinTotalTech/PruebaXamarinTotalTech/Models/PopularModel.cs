using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaXamarinTotalTech.Models
{
    public class PopularModel
    {
        [JsonProperty("page")]
        public int page { get; set; } = 0;
        [JsonProperty("results")]
        public List<ResultsModel> results { get; set; }
        [JsonProperty("total_results")]
        public int total_results { get; set; } = 0;
        [JsonProperty("total_pages")]
        public int total_pages { get; set; } = 0;
    }
}
