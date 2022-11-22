﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio
{
    public class Rol
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
    }
}
