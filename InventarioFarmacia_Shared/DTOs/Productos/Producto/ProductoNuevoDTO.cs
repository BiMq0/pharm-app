using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared
{
    public class ProductoNuevoDTO
    {
        public string? Nombre { get; set; }
        public string? Nombre_Clinico { get; set; }
        public string? Ruta_Imagen { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Precio_Caja { get; set; }
        //public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();

        [JsonConstructor]
        public ProductoNuevoDTO(string nombre, string nombre_Clinico, string ruta_Imagen, decimal precio_Unitario, decimal precio_Caja)
        {
            Nombre = nombre;
            Nombre_Clinico = nombre_Clinico;
            Ruta_Imagen = ruta_Imagen;
            Precio_Unitario = precio_Unitario;
            Precio_Caja = precio_Caja;
        }
    }
}