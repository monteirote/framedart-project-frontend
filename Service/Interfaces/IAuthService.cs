namespace framedart_project_frontend.Service.Interfaces {
    public interface IAuthService {
        public Task<bool> Authenticate(string username, string password);        
    }
}
