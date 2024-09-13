﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]

    public int TecnicoId { get; set; }

    [Required(ErrorMessage = "El Campo Descripción es obligatorio ")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El Campo Descripción es obligatorio")]
    public float? Sueldohora { get; set; }

    [ForeignKey("TipoId")]
    public int TipoId { get; set; }

    public int IncentivoId { get; set; }

    public Tipostecnicos? Tipotecnicos { get; set; }

    public string Descripcion { get; set; }
}
