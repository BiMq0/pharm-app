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
using InventarioFarmacia_Shared.DTOs.Categorias;

namespace InventarioFarmacia_Shared.DTOs.Products
{
    public class ProductoNuevoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "El nombre debe tener más de 6 caracteres y menos de 100.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre clinico es obligatorio.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "El nombre clinico debe tener más de 6 caracteres y menos de 100.")]
        public string Nombre_Clinico { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ruta de la imagen es obligatoria.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La ruta de la imagen debe tener más de 5 caracteres y menos de 200.")]
        public string Ruta_Imagen { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.01, 99999.99, ErrorMessage = "El precio unitario debe ser mayor que cero.")]
        public decimal Precio_Unitario { get; set; }

        [Range(0.01, 99999.99, ErrorMessage = "El precio por caja debe ser mayor que cero.")]
        public decimal Precio_Caja { get; set; }

        [Required(ErrorMessage = "La cantidad por caja es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad por caja debe ser al menos 1.")]
        public int Existencias_Por_Caja { get; set; }

        public bool Tiene_Subunidades { get; set; }
        public int? Unidades_Por_Existencia { get; set; }
        public int Total_Existencias_Por_Caja => Tiene_Subunidades ? Existencias_Por_Caja * (Unidades_Por_Existencia ?? 1) : Existencias_Por_Caja;
        public CategoriaToNewProductoDTO Categoria { get; set; }

        public ProductoNuevoDTO(string nombre, string nombre_Clinico, string ruta_Imagen, decimal precio_Unitario, decimal precio_Caja, int existencias_Por_Caja, bool tiene_Subunidades, int? unidades_Por_Existencia, Categoria categoria)
        {
            Nombre = nombre;
            Nombre_Clinico = nombre_Clinico;
            Ruta_Imagen = ruta_Imagen;
            Precio_Unitario = precio_Unitario;
            Precio_Caja = precio_Caja;
            Existencias_Por_Caja = existencias_Por_Caja;
            Tiene_Subunidades = tiene_Subunidades;
            Unidades_Por_Existencia = unidades_Por_Existencia;
            Categoria = new CategoriaToNewProductoDTO(categoria);
        }

        public ProductoNuevoDTO()
        {
            Categoria = new CategoriaToNewProductoDTO();
        }
    }
}