﻿using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es obligatorio")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es obligatorio")]

        public string? Tiempo { get; set; }
    
    }
}
