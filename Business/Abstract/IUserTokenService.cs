using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserTokenService
    {
        void Add(UserToken userToken);
    }
}
