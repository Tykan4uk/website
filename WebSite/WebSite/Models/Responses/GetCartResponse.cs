using System.Collections.Generic;

namespace WebSite.Models.Responses
{
    public class GetCartResponse
    {
        public HashSet<int> GameIdList { get; set; } = null!;
    }
}
