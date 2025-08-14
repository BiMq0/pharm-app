using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.DTOs.Categorias
{
    public class CategoriaNuevoDTO
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Icono { get; set; }

        public CategoriaNuevoDTO()
        {

        }
    }
}