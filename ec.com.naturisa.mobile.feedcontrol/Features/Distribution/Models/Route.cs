namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models
{
    public class Route
    {
        [JsonPropertyName("is_grouped")]
        public bool IsGrouped { get; set; }

        [JsonPropertyName("destinations")]
        public List<Destination> Destinations { get; set; }
    }
}
