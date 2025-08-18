using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Products;

namespace InventarioFarmacia_Shared.DTOs.Categorias
{
    public class CategoriaAllInfoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Icono { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<ProductoInfoToCategoria> Productos { get; set; } = new List<ProductoInfoToCategoria>();

        public int CantidadProductos => Productos.Count();

        public CategoriaAllInfoDTO(Categoria categoria)
        {
            Id = categoria.Id;
            Nombre = categoria.Nombre;
            Icono = categoria.Icono;
            Descripcion = categoria.Descripcion;

            foreach (var producto in categoria.Productos ?? Enumerable.Empty<Producto>())
            {
                Productos.Add(new ProductoInfoToCategoria(producto));
            }
        }

        public CategoriaAllInfoDTO()
        {

        }
    }
}