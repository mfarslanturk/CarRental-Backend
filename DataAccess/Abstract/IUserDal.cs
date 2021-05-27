using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepositoryBase<User>
    {
        List<OperationClaim> GetClaims(User user);

    }
}
