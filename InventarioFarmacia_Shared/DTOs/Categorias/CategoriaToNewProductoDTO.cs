using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Categorias
{
    public class CategoriaToNewProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;

        public CategoriaToNewProductoDTO(Categoria categoria)
        {
            Id = categoria.Id;
            Nombre = categoria.Nombre!;
            Icono = categoria.Icono!;
        }

        public CategoriaToNewProductoDTO(CategoriaToProductoDetallado categoria)
        {
            Nombre = categoria.Nombre!;
            Icono = categoria.Icono!;
        }

        public CategoriaToNewProductoDTO() { }
    }
}