using System.Collections.Generic;
using Newtonsoft.Json;

namespace LtInfo.Common.MvcResults
{
    public class DhtmlxGridJsonRow
    {
        public DhtmlxGridJsonRow(int rowID, List<string> data)
        {
            ID = rowID;
            Data = data;
        }

        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "data")]
        public List<string> Data { get; set; }
    }
}