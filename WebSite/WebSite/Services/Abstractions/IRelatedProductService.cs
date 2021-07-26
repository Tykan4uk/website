using System.Threading.Tasks;
using WebSite.Models.Requests;
using WebSite.Models.Responses;

namespace WebSite.Services.Abstractions
{
    public interface IRelatedProductService
    {
        Task<GetByPageRelatedProductResponse> GetByPage(GetByPageProductRequest getByPageRequest);
        Task<GetByIdRelatedProductResponse> GetById(GetByIdProductRequest getByIdRequest);
    }
}
