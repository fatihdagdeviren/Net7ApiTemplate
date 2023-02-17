using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Enums;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MyDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new MyDbContext())
            {
                var result = from uoc in context.UserOperationClaims
                             join oc in context.OperationClaims
                                 on uoc.Id equals oc.Id
                             where uoc.UserId == user.Id
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };

                return result.ToList();
            }               
        }

        public async Task<bool> SetUserOperationClaimDefault(User user)
        {
            using (var context = new MyDbContext())
            {
                UserOperationClaim opClaim = new UserOperationClaim { OperationClaimId = (int)EUser.User, UserId = user.Id };
                await context.UserOperationClaims.AddAsync(opClaim);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}