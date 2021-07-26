using System.Threading.Tasks;
using WebSite.Models.Requests;
using WebSite.Models.Responses;

namespace WebSite.Services.Abstractions
{
    public interface ICartService
    {
        Task<AddCartResponse> AddToCart(AddCartRequest addCartRequest);

        Task<GetCartResponse> GetCart(GetCartRequest getCartRequest);

        Task<RemoveCartResponse> RemoveFromCart(RemoveCartRequest removeCartRequest);
    }
}
