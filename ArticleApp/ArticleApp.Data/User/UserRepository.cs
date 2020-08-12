using ArticleApp.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApp.Data.User
{
   public class UserRepository : Repository<User, UserDbContext>, IUserRepository
    {
        public UserRepository(UserDbContext userDbContext) : base(userDbContext)
        { 
        }
    }
}
