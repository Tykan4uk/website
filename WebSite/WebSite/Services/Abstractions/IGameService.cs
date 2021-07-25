using System.Threading.Tasks;
using System.Collections.Generic;
using WebSite.Models;

namespace WebSite.Services.Abstractions
{
    public interface IGameService
    {
        Task<List<GameModel>> GetByPage(int page);
    }
}
