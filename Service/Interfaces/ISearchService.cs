namespace framedart_project_frontend.Service.Interfaces {
    using framedart_project_frontend.Models.GlobalModels;

    public interface ISearchService {
        public Task<ApiResponse<List<SearchResult>>> SearchCustomer (string text);
        public Task<ApiResponse<List<SearchResult>>> SearchMaterial (string text, string type);
    }
}
