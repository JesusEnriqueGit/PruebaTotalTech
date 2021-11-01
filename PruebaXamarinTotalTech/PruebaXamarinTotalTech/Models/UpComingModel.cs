using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaXamarinTotalTech.Models
{
    public class UpComingModel
    {
        [JsonProperty("page")]
        public int page { get; set; } = 0;
        [JsonProperty("results")]
        public List<ResultsModel> results { get; set; }
        [JsonProperty("dates")]
        public dates dates { get; set; }
        [JsonProperty("total_results")]
        public int total_results { get; set; } = 0;
        [JsonProperty("total_pages")]
        public int total_pages { get; set; } = 0;
    }

    public class dates
    {
        [JsonProperty("maximum")]
        public string maximum { get; set; } = string.Empty;
        [JsonProperty("minimum")]
        public string minimum { get; set; } = string.Empty;
    }
}
