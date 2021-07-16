using System;

namespace WebSite.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
    }
}
