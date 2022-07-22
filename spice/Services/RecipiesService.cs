using System;
using System.Collections.Generic;
using spice.Models;
using spice.Repositories;

namespace spice.Services
{
    public class RecipiesService
    {
        private readonly RecipiesRepository _repo;
        public RecipiesService(RecipiesRepository repo)
        {
            _repo = repo;
        }
        internal List<Recipie> GetAllRecipies(string userId)
        {
            return _repo.GetAllRecipies(userId);
        }
   
        internal Recipie CreateRecipie(Recipie recipieData)
        {
            return _repo.Create(recipieData);
        }
        internal Recipie GetById(int recipieId, string userId)
        {
            Recipie found = _repo.GetById(recipieId);
            // if (found == null)
            // {
            //     throw new Exception("Recipie not found");
            // }
            // if (found.CreatorId != userId)
            // {
            //     throw new Exception("You are not authorized to access this recipie");
            // }
            return found;
        }
        internal Recipie Edit(Recipie recipieData)
        {
            Recipie original = GetById(recipieData.Id, recipieData.CreatorId);
            original.Name = recipieData.Name ?? original.Name;
            original.Category = recipieData.Category ?? original.Category;

            original.Description = recipieData.Description ?? original.Description;
            original.Image = recipieData.Image ?? original.Image;

            _repo.Edit(original);
            return original;
        }
        internal void Delete(int recipieId, string userId)
        {
            Recipie found = GetById(recipieId, userId);
            if (userId != found.CreatorId)
            {
                throw new Exception("You are not authorized to delete this recipie");
            }
          _repo.Delete(recipieId, userId);


        }
    }
}
