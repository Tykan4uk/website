using System.Collections.Generic;
using System.Threading.Tasks;
using WebSite.Models;
using WebSite.Models.Responses;

namespace WebSite.Services.Abstractions
{
    public interface ICartService
    {
        Task<AddCartResponse> AddToCart(int userId, int gameId);

        Task<List<GameViewModel>> GetCart(int userId);

        Task<RemoveCartResponse> RemoveFromCart(int userId, int gameId);
    }
}
