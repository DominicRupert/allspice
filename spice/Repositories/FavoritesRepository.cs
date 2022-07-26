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
        internal List<Favorite> GetByRecipieId(int recipieId)
        {
            string sql = "SELECT * FROM favorites WHERE RecipieId = @recipieId";




            return _db.Query<Favorite>(sql, new { recipieId }).ToList();
        }
        internal Favorite Create(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites
            (accountId, recipieId )
            VALUES
            (@AccountId, @RecipieId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = id;
            return favoriteData;
        }
        internal List<Favorite> GetByUserId(string userId)
        {
            string sql = "SELECT * FROM favorites WHERE userId = @UserId";
            return _db.Query<Favorite>(sql, new { userId }).ToList();
        }


    }
}