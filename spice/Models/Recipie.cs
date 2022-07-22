using System;

namespace spice.Models
{
    public class Recipie
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }
}