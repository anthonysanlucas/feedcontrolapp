namespace ec.com.naturisa.mobile.feedcontrol.Services.MasterData.Product
{
    public interface IProductService
    {
        Task<ApiResponse<PagedApiResponse<ProductResponse>>> GetProducts(ProductQuery query);
    }
}
