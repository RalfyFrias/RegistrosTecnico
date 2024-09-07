﻿using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tipostecnicos
    {
        [Key]

        public int TipoId { get; set; }
        [Required(ErrorMessage = "El campo no esta lleno")]
        public string? Descripcion { get; set; }
        public Tecnicos? Tecnicos { get; set; }

    }
}
