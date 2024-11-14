namespace ec.com.naturisa.mobile.feedcontrol.Models.Ap1.SubsidiaryUsers;

public class SubsidiaryUsersQuery
{
    public int UserId { get; set; }
    public bool IncludeSubsidiary { get; set; } = true;
    public string Status { get; set; } = "ACTIVO";

}
