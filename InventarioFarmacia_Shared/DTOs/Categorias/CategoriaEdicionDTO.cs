using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Categorias
{
    public class CategoriaEdicionDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Icono { get; set; }

        public CategoriaEdicionDTO(Categoria categoria)
        {
            Id = categoria.Id;
            Nombre = categoria.Nombre;
            Descripcion = categoria.Descripcion;
            Icono = categoria.Icono;
        }
    }
}