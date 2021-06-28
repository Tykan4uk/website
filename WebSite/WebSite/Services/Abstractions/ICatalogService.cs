using System.Threading.Tasks;
using System.Collections.Generic;
using WebSite.Models;

namespace WebSite.Services.Abstractions
{
    public interface ICatalogService
    {
        Task<List<GameEntity>> GetByPage(int page);
    }
}
