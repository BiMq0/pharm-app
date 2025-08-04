using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Constants;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared
{
    public class ProductoIndividualToProductoAllInfoDTO
    {
        public int Id { get; set; }
        public int Id_Inventario { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public string? Nro_Lote { get; set; }
        public Estados_ProductosIndividuales Estado { get; set; }

        public ProductoIndividualToProductoAllInfoDTO(Producto_Individual producto_Individual)
        {
            Id = producto_Individual.Id;
            Id_Inventario = producto_Individual.Id_Inventario;
            Fecha_Vencimiento = producto_Individual.Fecha_Vencimiento;
            Nro_Lote = producto_Individual.Nro_Lote;
            Estado = producto_Individual.Estado;
        }
    }
}