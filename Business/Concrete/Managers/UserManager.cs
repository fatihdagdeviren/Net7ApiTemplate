using System.Collections.Generic;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            var addedUser = _userDal.Add(user).Result;
            var result = _userDal.SetUserOperationClaimDefault(addedUser).Result;
        }

        public User GetByMail(string email)
        {
            //TODO: buralar async
            return  _userDal.Get(u => u.Email == email).Result;
        }
    }
}