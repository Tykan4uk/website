using WebSite.Common.Enums;

namespace WebSite.Models
{
    public class RelatedProductViewModel
    {
        public RelatedProductModel RelatedProduct { get; set; }
        public int Page { get; set; }
        public SortedTypeEnum SortedType { get; set; }
    }
}
