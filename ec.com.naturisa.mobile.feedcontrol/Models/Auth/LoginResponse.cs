using ec.com.naturisa.mobile.feedcontrol.Models.User;

namespace ec.com.naturisa.mobile.feedcontrol.Models.Auth
{
    public class LoginResponse
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("tokenDate")]
        public DateTime? TokenDate { get; set; }

        [JsonPropertyName("authenticate")]
        public bool Authenticate { get; set; }

        [JsonPropertyName("twoFactorRequired")]
        public bool TwoFactorRequired { get; set; }

        [JsonPropertyName("forceChangePasswordRequired")]
        public bool ForceChangePasswordRequired { get; set; }

        [JsonPropertyName("checksum")]
        public string Checksum { get; set; } = null!;

        [JsonPropertyName("usuario")]
        public UserResponse? Usuario { get; set; }
    }
}
