namespace ec.com.naturisa.mobile.feedcontrol.Models.User
{
    public class UserResponse
    {
        public int IdUser { get; set; }
        public string Identification { get; set; } = null!;
        public string FirstNames { get; set; } = null!;
        public string LastNames { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public bool EnabledTwoFA { get; set; }
        public bool NotifyLogin { get; set; }
        public bool? IsSystemUser { get; set; }
        public string? ImageDisplayId { get; set; }
        public string Status { get; set; } = null!;
        // public List<UserAccessLogResponse> UserAccessLogs { get; set; } = null!;
    }
}
