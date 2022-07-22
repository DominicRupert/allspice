using System;
using System.Collections.Generic;
using spice.Models;
using spice.Repositories;


namespace spice.Services

{
    public class FavoritesService
    {
        private readonly RecipiesService _rs;
        private readonly FavoritesRepository _repo;
        public FavoritesService(RecipiesService rs, FavoritesRepository repo)
        {
            _rs = rs;
            _repo = repo;
        }
        internal Favorite Create(Favorite favoriteData, string userId)
        {
           _rs.GetById(favoriteData.RecipieId, userId);
            return _repo.Create(favoriteData);
        }
        internal List<Favorite> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }
        internal Favorite GetByRecipieId(int id, string userId)
        {
            return _repo.GetById(id, userId);
        }
    }
}
