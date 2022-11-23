using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;

namespace WebMVC.Models
{
    public class RegistroViewModel
    {
        public string Password { get; internal set; }
        public string Email { get; internal set; }
        public RolDTO Rol { get; internal set; }
        public int Id { get; internal set; }
    }
}
