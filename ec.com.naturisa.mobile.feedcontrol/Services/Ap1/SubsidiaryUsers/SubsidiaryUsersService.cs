namespace ec.com.naturisa.mobile.feedcontrol.Services.Ap1.SubsidiaryUsers;

public class SubsidiaryUsersService: BaseHttpService, ISubsidiaryUsersService
{
    private static class SubsidiaryUsersEndpoints
    {
        public const string SubsidiaryUsers = $"{ApiConstants.AP1_API_URL}/subsidiary_users";
    }


    public SubsidiaryUsersService() : base(ApiConstants.AP1_API_URL)
    {
        
    }

    public async Task<ApiResponse<PagedApiResponse<SubsidiaryUserResponse>>> GetSubsidiaryUsers(SubsidiaryUsersQuery subsidiaryUsersQuery)
    {
        string query = StringExtensions.BuildQueryString(subsidiaryUsersQuery);
        var response = await SendRequestAsync(
            HttpMethod.Get,
            SubsidiaryUsersEndpoints.SubsidiaryUsers + query
        );

        return await ProcessResponse<PagedApiResponse<SubsidiaryUserResponse>>(response);
    }
}
