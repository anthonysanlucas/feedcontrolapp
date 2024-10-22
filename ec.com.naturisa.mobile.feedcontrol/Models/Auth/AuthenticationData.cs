namespace ec.com.naturisa.mobile.feedcontrol.Models.Auth
{
    public class AuthenticationData
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("tokenDate")]
        public DateTime TokenDate { get; set; }

        [JsonPropertyName("authenticate")]
        public bool Authenticate { get; set; }

        [JsonPropertyName("twoFactorRequired")]
        public bool TwoFactorRequired { get; set; }

        [JsonPropertyName("forceChangePasswordRequired")]
        public bool ForceChangePasswordRequired { get; set; }

        [JsonPropertyName("checksum")]
        public string Checksum { get; set; }

        [JsonPropertyName("usuario")]
        public User User { get; set; }
    }
}
