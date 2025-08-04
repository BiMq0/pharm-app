using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared
{
    public class CategoriaInfoCardDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ruta_Imagen { get; set; }
        public int ProductosTotales { get; set; }

        public CategoriaInfoCardDTO(Categoria categoria)
        {
            Id = categoria.Id;
            Nombre = categoria.Nombre;
            Ruta_Imagen = categoria.Ruta_Imagen;
            ProductosTotales = categoria.CantidadProductos;
        }
    }
}