using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Access { get; set; }
        public bool IsStudent { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
