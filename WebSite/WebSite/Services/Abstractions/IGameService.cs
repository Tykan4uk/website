using System.Threading.Tasks;
using WebSite.Models.Responses;
using WebSite.Models.Requests;

namespace WebSite.Services.Abstractions
{
    public interface IGameService
    {
        Task<GetByPageGameResponse> GetByPage(GetByPageProductRequest getByPageRequest);
        Task<GetByIdGameResponse> GetById(GetByIdProductRequest getByIdRequest);
    }
}
