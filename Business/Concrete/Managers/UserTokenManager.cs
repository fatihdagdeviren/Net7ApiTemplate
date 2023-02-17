using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete.Managers
{
    public class UserTokenManager: IUserTokenService
    {
        private readonly IUserTokenDal _tokenDal;

        public UserTokenManager(IUserTokenDal tokenDal)
        {
            _tokenDal = tokenDal;
        }

        public void Add(UserToken userToken)
        {
            _tokenDal.Add(userToken);
        }
    }
}
