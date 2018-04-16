using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooselyCouple.Model.Models
{
    public class RegisterViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Username { get; set; }
        public string[] selectedRole { get; set; }
        public string[] roles { get; set; }
        public string Id { get; set; }
    }
}