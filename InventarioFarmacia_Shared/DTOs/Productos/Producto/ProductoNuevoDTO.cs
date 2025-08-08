using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared
{
    public class ProductoNuevoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "El nombre debe tener más de 6 caracteres y menos de 100.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre clinico es obligatorio.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "El nombre clinico debe tener más de 6 caracteres y menos de 100.")]
        public string Nombre_Clinico { get; set; }

        [Required(ErrorMessage = "La ruta de la imagen es obligatoria.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "La ruta de la imagen debe tener más de 10 caracteres y menos de 200.")]
        public string Ruta_Imagen { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.01, 99999.99, ErrorMessage = "El precio unitario debe ser mayor que cero.")]
        public decimal Precio_Unitario { get; set; }

        [Range(0.01, 99999.99, ErrorMessage = "El precio por caja debe ser mayor que cero.")]
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

        public ProductoNuevoDTO()
        {
        }
    }
}