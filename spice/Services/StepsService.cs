using System.Collections.Generic;
using spice.Models;
using spice.Repositories;


namespace spice.Services
{

    public class StepsService
    {
        private readonly RecipiesService _rs;
        private readonly StepsRepository _repo;

        public StepsService(RecipiesService rs, StepsRepository repo)
        {
            _rs = rs;
            _repo = repo;
        }
        internal Step Create(Step stepData, string userId)
        {
            _rs.GetById(stepData.RecipieId, userId);
            return _repo.Create(stepData);
        }
        internal List<Step> GetByRecipieId(int recipieId, string userId)
        {
            _rs.GetById(recipieId, userId);
            return _repo.GetByRecipieId(recipieId);
        }
    }
}