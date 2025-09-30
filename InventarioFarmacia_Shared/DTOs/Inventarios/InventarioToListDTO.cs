using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Shared.DTOs.Inventarios
{
    public class InventarioToListDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public InventarioToListDTO(Inventario inventario)
        {
            Id = inventario.Id;
            Nombre = inventario.Nombre!;
        }
        public InventarioToListDTO() { }
    }
}