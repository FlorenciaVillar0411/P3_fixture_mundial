using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class UsuarioDTO
    {

        public string Password { get; set; }
        public string Email { get; set; }
        public UsuarioDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
