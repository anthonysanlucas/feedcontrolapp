namespace ec.com.naturisa.mobile.feedcontrol.Services.Ap1.SubsidiaryUsers
{
    public interface ISubsidiaryUsersService
    {
        Task<ApiResponse<PagedApiResponse<SubsidiaryUserResponse>>> GetSubsidiaryUsers(SubsidiaryUsersQuery subsidiaryUsersQuery);
    }
}
