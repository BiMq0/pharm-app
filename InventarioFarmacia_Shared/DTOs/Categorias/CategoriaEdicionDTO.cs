using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Categorias
{
    public class CategoriaEdicionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La descripcion de la categoria es obligatoria.")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "El icono de la categoria es obligatorio.")]
        public string Icono { get; set; } = null!;

        public CategoriaEdicionDTO(CategoriaAllInfoDTO categoria)
        {
            Id = categoria.Id;
            Nombre = categoria.Nombre ?? string.Empty;
            Descripcion = categoria.Descripcion ?? string.Empty;
            Icono = categoria.Icono ?? string.Empty;
        }

        public CategoriaEdicionDTO()
        {

        }
    }
}