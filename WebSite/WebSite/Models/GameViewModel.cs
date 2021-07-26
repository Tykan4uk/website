using WebSite.Common.Enums;

namespace WebSite.Models
{
    public class GameViewModel
    {
        public GameModel Game { get; set; }
        public int Page { get; set; }
        public SortedTypeEnum SortedType { get; set; }
    }
}
