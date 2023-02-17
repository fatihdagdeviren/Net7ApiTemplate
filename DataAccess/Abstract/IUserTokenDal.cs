using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserTokenDal : IEntityRepository<UserToken>
    {
    }
}