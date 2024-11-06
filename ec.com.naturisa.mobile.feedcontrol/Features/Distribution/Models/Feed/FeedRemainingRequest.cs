namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models.Feed
{
    public class FeedRemainingRequest
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        [Range(0, long.MaxValue, ErrorMessage = "El ID debe ser un número mayor o igual que 0.")]
        public long IdFeed { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "La cantidad de sacos restantes en tolvas debe ser un número mayor o igual que 0.")]
        public int? SacksRemainingHoppers { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "La cantidad de tolvas dañadas debe ser un número mayor o igual que 0.")]
        public int? FailedHoppers { get; set; }

        public string? Observation { get; set; }


    }
}
