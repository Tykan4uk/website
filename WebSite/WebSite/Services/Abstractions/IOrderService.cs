using System.Threading.Tasks;
using WebSite.Models.Requests;
using WebSite.Models.Responses;

namespace WebSite.Services.Abstractions
{
    public interface IOrderService
    {
        Task<AddOrderResponse> AddOrder(AddOrderRequest addOrderRequest);
        Task<GetByPageOrderResponse> GetByPageOrder(GetByPageOrderRequest getByPageOrderRequest);
        Task<GetByIdOrderResponse> GetByIdOrder(GetByIdOrderRequest getByIdOrderRequest);
    }
}
