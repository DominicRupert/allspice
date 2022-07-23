namespace spice.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
public string CreatorId { get; set; }
public Profile Creator { get; set; }
    }
    public class AccountFavorite: Favorite
    {

        public int FavoriteId { get; set; }
    }
}