using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common
{
    public class PaginationFilterModel : BaseModel
    {
        public PaginationFilterModel() { }
        public PaginationFilterModel(Dictionary<string, string> data)
        {
            int.TryParse(data["start"], out int skip);
            int.TryParse(data["length"], out int take);
            SearchValue = data["search"];
            Skip = skip;
            Take = take;
            try
            {
                //{[order, [{"column":1,"dir":"asc"}]]}
                var order = data["order"].Deserialize<JSOrder[]>()[0];
                OrderBy = order.Column;//column
                OrderAscending = string.Equals(order.Dir, "asc"); //ascending
            }
            catch (Exception)
            {
            }
        }

        [Range(0, int.MaxValue)]//[Range(1, 100000)]
        public int Skip { get; set; }

        [Range(1, int.MaxValue)]//[Range(1, 10000)]
        public int Take { get; set; }

        public bool OrderAscending { set; get; }
        public int OrderBy { set; get; }

        [MaxLength(128)]
        public string SearchValue { set; get; }

        [JsonIgnore]
        public string SearchValueLower => string.IsNullOrEmpty(SearchValue) || string.IsNullOrWhiteSpace(SearchValue) ? null : SearchValue.Trim().ToLower();

        //[JsonIgnore]
        //public int Skip => (PageNumber - 1) * PageSize;
        //[JsonIgnore]
        //public int Take => PageSize;
    }

    public class JSOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }
}