using System.Threading.Tasks;
using WebSite.Models.Responses;

namespace WebSite.Services.Abstractions
{
    public interface IRateLimitService
    {
        Task<CheckRateLimitResponse> CheckRateLimit(string name);
    }
}
