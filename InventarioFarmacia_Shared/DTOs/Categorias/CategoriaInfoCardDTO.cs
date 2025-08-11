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
        public string? Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? Icono { get; set; }
        public int CantidadProductos { get; set; }
        public CategoriaInfoCardDTO(Categoria categoria)
        {
            Id = categoria.Id;
            Nombre = categoria.Nombre;
            Descripcion = categoria.Descripcion;
            Icono = categoria.Icono;
            CantidadProductos = categoria.CantidadProductos;
        }

        public CategoriaInfoCardDTO()
        {
        }
    }
}