using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using spice.Models;
//make a repository for steps in a recipie

namespace spice.Repositories
{
    public class StepsRepository
    {
        private readonly IDbConnection _db;
        public StepsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Step Create(Step stepData)
        {
            string sql = @"
            INSERT INTO steps
            (stepnum, description, recipieId  )
            VALUES
            (@StepNum, @Description,@RecipieId );
            SELECT LAST_INSERT_ID();";
            stepData.Id  = _db.ExecuteScalar<int>(sql, stepData);
            
            return stepData;
        }
        internal List<Step> GetByRecipieId(int recipieId)
        {
            string sql = "SELECT * FROM steps WHERE recipieId = @RecipieId";
            return _db.Query<Step>(sql, new { recipieId }).ToList();
        }

    }
}