namespace ec.com.naturisa.mobile.feedcontrol.Models.Auth
{
    public class LoginByUserRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; } = null!;

        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;

        [JsonPropertyName("codeApplication")]
        public Guid CodeApplication { get; set; }

        [JsonPropertyName("codeTwoFactorAuthenticator")]
        public string? CodeTwoFactorAuthenticator { get; set; }

        [JsonPropertyName("includeUserInfo")]
        public bool? IncludeUserInfo { get; set; }
    }
}
