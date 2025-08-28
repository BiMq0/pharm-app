using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Categorias
{
    public class CategoriaToProductoDetallado
    {
        public string Nombre { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public CategoriaToProductoDetallado(Categoria categoria)
        {
            Nombre = categoria.Nombre ?? string.Empty;
            Icono = categoria.Icono ?? string.Empty;
        }
        public CategoriaToProductoDetallado()
        {

        }
    }
}