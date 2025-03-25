using System.Threading.Tasks;
using framedart_project_frontend.Models.Order;
using framedart_project_frontend.Models.GlobalModels;

namespace framedart_project_frontend.Service.Interfaces {
    public interface IOrderService {
        public Task<ApiResponse<string>> SubmitOrder (OrderRequestModel orderToSubmit);
    }
}
