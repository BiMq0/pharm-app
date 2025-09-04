using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Domain.Constants;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteNuevoDTO
    {
        public DateOnly Fecha_Vencimiento { get; set; }
        public string Nro_Lote { get; set; } = null!;
        public LoteNuevoDTO() { }
    }
}