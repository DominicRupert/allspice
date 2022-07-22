using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using spice.Models;


namespace spice.Repositories
{
    public class RecipiesRepository
    {
        private readonly IDbConnection _db;
        public RecipiesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Recipie> GetAllRecipies(string userId)
        {
            string sql = @"
          SELECT 
          r.*,
          a.*
            FROM recipies r
            JOIN accounts a ON r.CreatorId = a.Id
            WHERE r.CreatorId = @userId";
            return _db.Query<Recipie, Profile, Recipie>(sql, (recipie, prof) =>
            {
                recipie.Creator = prof;
                return recipie;
            }, new { userId }).ToList();

        }
        internal Recipie GetById(int recipieId)
        {
            string sql = @"
            SELECT 
            r.*,
            a.*
            FROM recipies r
            JOIN accounts a ON r.CreatorId = a.Id
            WHERE r.Id = @id ";
            return _db.Query<Recipie, Profile, Recipie>(sql, (recipie, prof) =>
            {
                recipie.Creator = prof;
                return recipie;
            }, new { recipieId }).FirstOrDefault();
        }
        internal Recipie Create(Recipie recipieData)
        {
            string sql = @"
            INSERT INTO recipies
            (name, description, image, creatorId)
            VALUES
            (@Name, @Description, @Image, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, recipieData);
            recipieData.Id = id;
            return recipieData;
        }
        internal Recipie Edit(Recipie recipieData)
        {
            string sql = @"
            UPDATE recipies
            SET name = @Name,
            description = @Description,
            image = @Image,
            steps = @Steps
            WHERE id @Id";
            _db.Execute(sql, recipieData);
            return recipieData;


        }


        internal void Delete(int id, string userId)
        {
            string sql = @"
            DELETE FROM recipies
            WHERE id = @Id LIMIT 1";
            _db.Execute(sql, new { id, userId });

        }


    }
}