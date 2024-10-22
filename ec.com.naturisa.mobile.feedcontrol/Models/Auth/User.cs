namespace ec.com.naturisa.mobile.feedcontrol.Models.Auth
{
    public class User
    {
        public int IdUser { get; set; }
        public string Identification { get; set; }
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool EnabledTwoFA { get; set; }
        public bool NotifyLogin { get; set; }
        public bool IsSystemUser { get; set; }
        public string Status { get; set; }
        public List<UserAccessLog> UserAccessLogs { get; set; }
    }
}
