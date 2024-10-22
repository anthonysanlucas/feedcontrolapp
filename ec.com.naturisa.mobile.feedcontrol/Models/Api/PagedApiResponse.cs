namespace ec.com.naturisa.mobile.feedcontrol.Models.Api
{
    public class PagedApiResponse<T>
    {
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("data")]
        public List<T> Data { get; set; }
    }
}
