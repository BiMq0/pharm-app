using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Categorias;

namespace InventarioFarmacia_Shared.DTOs.Products
{
    public class ProductoDetalladoDTO
    {
        public int Id { get; set; }
        public int Id_Categoria { get; set; }
        public string? Nombre { get; set; }
        public string? Nombre_Clinico { get; set; }
        public string? Ruta_Imagen { get; set; }
        public int Existencias_Por_Caja { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Precio_Caja { get; set; }
        public bool Tiene_Subunidades { get; set; }
        public int? Unidades_Por_Existencia { get; set; }
        public int Total_Existencias_Por_Caja { get; set; }
        public ICollection<Producto_Individual> ProductosIndividuales { get; set; } = new List<Producto_Individual>();
        public CategoriaToProductoDetallado Categoria { get; set; } = new();


        public ProductoDetalladoDTO(Producto producto)
        {
            Id = producto.Id;
            Nombre = producto.Nombre;
            Nombre_Clinico = producto.Nombre_Clinico;
            Ruta_Imagen = producto.Ruta_Imagen;
            Precio_Unitario = producto.Precio_Unitario;
            Precio_Caja = producto.Precio_Caja;
            Existencias_Por_Caja = producto.Existencias_Por_Caja;
            Tiene_Subunidades = producto.Tiene_Subunidades;
            Unidades_Por_Existencia = producto.Unidades_Por_Existencia;
            Total_Existencias_Por_Caja = producto.Total_Existencias_Por_Caja;
            ProductosIndividuales = producto.ProductosIndividuales;
            Categoria = new CategoriaToProductoDetallado(producto.Categoria);
        }
        public ProductoDetalladoDTO()
        {

        }
    }
}