﻿using RestWithAspNet.Data.VO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
    }
}
