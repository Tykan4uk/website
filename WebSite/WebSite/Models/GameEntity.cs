using System;

namespace WebSite.Models
{
    public class GameEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public DateTime Release { get; set; }
    }
}
