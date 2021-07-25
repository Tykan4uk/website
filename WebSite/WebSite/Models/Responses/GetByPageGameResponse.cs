using System.Collections.Generic;

namespace WebSite.Models.Responses
{
    public class GetByPageGameResponse
    {
        public IEnumerable<GameModel> Games { get; set; }
        public int TotalRecords { get; set; }
    }
}
