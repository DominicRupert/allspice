using System;
using System.Collections.Generic;
using spice.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace spice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;
        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Favorite GetByRecipieId(int recipieId)
        {
            string sql = @"SELECT 
            r.*,
            f.id AS favoriteId,
            FROM favorites f
            JOIN recipies r ON f.recipieId = r.id
            WHERE f.id = @id AND f.userId = @userId";
           
           
            return _db.QueryFirstOrDefault<Favorite>(sql, new { recipieId });
        }
        internal Favorite Create(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites
            (recipieId, creatorId  )
            VALUES
            (@RecipieId, @CreatorId );
            SELECT LAST_INSERT_ID();";
            favoriteData.Id  = _db.ExecuteScalar<int>(sql, favoriteData);
            return favoriteData;
        }
        internal List<Favorite> GetByUserId(string userId)
        {
            string sql = "SELECT * FROM favorites WHERE userId = @UserId";
            return _db.Query<Favorite>(sql, new { userId }).ToList();
        }
     
    }
}