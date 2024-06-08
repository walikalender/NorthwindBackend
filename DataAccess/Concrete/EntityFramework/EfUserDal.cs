using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contrexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new NorthwindContext();
            var result = from userOperationClaim in context.UserOperationClaims
                         join operationClaim in context.OperationClaims
                         on userOperationClaim.OperationClaimId equals operationClaim.Id
                         where userOperationClaim.UserId==user.Id
                         select new OperationClaim
                         {
                             Id = operationClaim.Id,
                             Name=operationClaim.Name
                         };
            return result.ToList();

        }
    }
}
