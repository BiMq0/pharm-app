using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;


namespace InventarioFarmacia_Shared
{
    public class CategoriaAllInfoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ruta_Imagen { get; set; }
        public ICollection<ProductoInfoToCategoria> Productos { get; set; } = new List<ProductoInfoToCategoria>();

        public int CantidadProductos => Productos.Count();

        public CategoriaAllInfoDTO(Categoria categoria)
        {
            Id = categoria.Id;
            Nombre = categoria.Nombre;

            foreach (var producto in categoria.Productos ?? Enumerable.Empty<Producto>())
            {
                Productos.Add(new ProductoInfoToCategoria(producto));
            }
        }
    }
}