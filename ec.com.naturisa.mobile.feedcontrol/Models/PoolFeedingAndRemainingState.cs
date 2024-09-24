using System.Text.Json.Serialization;

namespace ec.com.naturisa.mobile.feedcontrol.Models
{
    public class PoolFeedingAndRemainingState
    {
        [JsonPropertyName("poolId")]
        public required string PoolName { get; set; }

        public bool IsFeeding { get; set; }

        public bool IsRemaining { get; set; }
    }
}
