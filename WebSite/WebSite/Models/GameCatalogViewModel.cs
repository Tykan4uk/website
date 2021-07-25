using System.Collections.Generic;
using WebSite.Common.Enums;

namespace WebSite.Models
{
    public class GameCatalogViewModel
    {
        public IEnumerable<GameModel> Games { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public SortedTypeEnum SortedType { get; set; }
    }
}
