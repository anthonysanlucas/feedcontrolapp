namespace ec.com.naturisa.mobile.feedcontrol.Models
{
    public class SubsidiaryUserResponse
    {
        [JsonPropertyName("idSubsidiaryUser")]
        public int IdSubsidiaryUser { get; set; }

        [JsonPropertyName("subsidiaryId")]
        public int SubsidiaryId { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("nameSubsidiary")]
        public string? NameSubsidiary { get; set; }
    }
}
