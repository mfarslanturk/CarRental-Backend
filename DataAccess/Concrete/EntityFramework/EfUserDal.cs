using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, EfCarRentalContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EfCarRentalContext())
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                                 on oc.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = oc.Id,
                                 Name = oc.Name
                             };
                 
                return result.ToList();

            }
        }
    }
}
