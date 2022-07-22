using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using spice.Models;

namespace spice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;
        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Ingredient Create(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (name, description, recipieId)
            VALUES
            (@Name, @Description, @RecipieId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.Id = id;
            return ingredientData;
        }
        internal List<Ingredient> GetByRecipieId(int recipieId)
        {
            string sql = "SELECT * FROM ingredients WHERE recipieId = @RecipieId";
            return _db.Query<Ingredient>(sql, new { recipieId }).ToList();
        }

    }
}