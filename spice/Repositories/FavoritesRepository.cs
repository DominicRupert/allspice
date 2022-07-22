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
        internal Favorite Create(Favorite favoriteData, string userId)
        {
            string sql = @"
            INSERT INTO favorites
            (recipieId, userId  )
            VALUES
            (@RecipieId, @UserId );
            SELECT LAST_INSERT_ID();";
            favoriteData.Id  = _db.ExecuteScalar<int>(sql, favoriteData);
            return favoriteData;
        }
        internal List<Favorite> GetByUserId(string userId)
        {
            string sql = "SELECT * FROM favorites WHERE userId = @UserId";
            return _db.Query<Favorite>(sql, new { userId }).ToList();
        }
        internal Favorite GetById(int id, string userId)
        {
            string sql = "SELECT * FROM favorites WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<Favorite>(sql, new { id, userId });
        }
    }
}