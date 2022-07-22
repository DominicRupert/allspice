using System;
using System.Collections.Generic;
using spice.Models;
using spice.Repositories;


namespace spice.Services
{
    public class IngredientsService
    {
        private readonly RecipiesService _rs;

    private readonly IngredientsRepository _repo;

    public IngredientsService(RecipiesService rs, IngredientsRepository repo)
    {
        _rs = rs;
        _repo = repo;
    }
    internal Ingredient Create(Ingredient ingredientData, string userId)
    {
        _rs.GetById(ingredientData.RecipieId, userId);
        return _repo.Create(ingredientData);
    }
    internal List<Ingredient> GetByRecipieId(int recipieId, string userId)
    {
      _rs.GetById(recipieId, userId);
        return _repo.GetByRecipieId(recipieId);
    }
    }
}
