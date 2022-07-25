using spice.Models;
using spice.Repositories;

namespace spice.Services
{
    public class AccountService
    {
        private readonly AccountsRepository _repo;
        private readonly RecipiesService _rs;
        public AccountService(AccountsRepository repo, RecipiesService rs)
        {
            _repo = repo;
            _rs = rs;
        }
       

        internal string GetProfileEmailById(string id)
        {
            return _repo.GetById(id).Email;
        }
        internal Account GetProfileByEmail(string email)
        {
            return _repo.GetByEmail(email);
        }
        internal Account GetOrCreateProfile(Account userInfo)
        {
            Account profile = _repo.GetById(userInfo.Id);
            if (profile == null)
            {
                return _repo.Create(userInfo);
            }
            return profile;
        }
      

        internal Account Edit(Account editData, string userEmail)
        {
            Account original = GetProfileByEmail(userEmail);
            original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
            original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
            return _repo.Edit(original);
        }
        // internal Account GetRecipies(int recipieId, string creatorId )
        // {
        //     _rs.GetById(recipieId, creatorId);
        //     return _repo.GetRecipies(recipieId);
        // }
        
    }
}