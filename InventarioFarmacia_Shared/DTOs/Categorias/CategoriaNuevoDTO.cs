using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.DTOs.Categorias
{
    public class CategoriaNuevoDTO
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La descripcion de la categoria es obligatoria.")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "El icono de la categoria es obligatorio.")]
        public string Icono { get; set; } = null!;

        public CategoriaNuevoDTO()
        {

        }
    }
}