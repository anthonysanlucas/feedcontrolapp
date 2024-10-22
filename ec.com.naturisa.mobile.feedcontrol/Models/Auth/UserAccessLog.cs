namespace ec.com.naturisa.mobile.feedcontrol.Models.Auth
{
    public class UserAccessLog
    {
        public int IdUserAccessLog { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public string Ip { get; set; }
        public string Origin { get; set; }
        public DateTime LoginDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CreatedBy { get; set; }
    }
}
