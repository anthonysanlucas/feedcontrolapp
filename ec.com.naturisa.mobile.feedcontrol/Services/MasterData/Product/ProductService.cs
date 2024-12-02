namespace ec.com.naturisa.mobile.feedcontrol.Services.MasterData.Product
{
    public partial class ProductService : BaseHttpService, IProductService
    {
        private static class ProductEndpoints
        {
            public const string Products = $"{ApiConstants.API_FEED_CONTROL}/products";
        }

        public ProductService() : base(ApiConstants.API_FEED_CONTROL)
        {
        }

        public async Task<ApiResponse<PagedApiResponse<ProductResponse>>> GetProducts(ProductQuery query)
        {
            string queryParams = StringExtensions.BuildQueryString(query);
            var response = await SendRequestAsync(
                HttpMethod.Get,
                ProductEndpoints.Products + queryParams
            );

            return await ProcessResponse<PagedApiResponse<ProductResponse>>(response);
        }
    }
}