using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete
{
    public class EfUserTokenDal : EfEntityRepositoryBase<UserToken, MyDbContext>, IUserTokenDal
    {
    }
}
