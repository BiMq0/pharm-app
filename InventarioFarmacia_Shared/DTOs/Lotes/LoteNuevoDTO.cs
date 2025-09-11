using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteNuevoDTO
    {
        [Required(ErrorMessage = "El Id del producto es obligatorio")]
        public int Id_Producto { get; set; }
        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        public DateOnly Fecha_Vencimiento { get; set; }
        [Required(ErrorMessage = "El Nro de Lote es obligatorio")]
        public string Nro_Lote { get; set; } = null!;
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de productos debe ser al menos 1")]
        public int Cantidad_Productos { get; set; }
        public LoteNuevoDTO() { }
    }
}