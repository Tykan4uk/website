using System;

namespace WebSite.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
