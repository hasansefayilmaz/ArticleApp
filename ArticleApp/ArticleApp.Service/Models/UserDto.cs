using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApp.Service.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte Status { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
