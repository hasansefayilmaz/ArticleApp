using ArticleApp.Data.Base;
using System;

namespace ArticleApp.Data.User
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int CreatedBy { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; } 
    }
}
