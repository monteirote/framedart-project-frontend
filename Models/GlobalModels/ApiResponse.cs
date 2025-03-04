namespace framedart_project_frontend.Models.GlobalModels {
    public class ApiResponse<T> {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool PermissionDenied { get; set; }
        public T? Data { get; set; }
    }
}
