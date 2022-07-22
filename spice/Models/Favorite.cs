namespace spice.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
        public string UserId { get; set; }

    }
    public class AccountFavorite: Favorite
    {
        public int FavoriteId { get; set; }
    }
}