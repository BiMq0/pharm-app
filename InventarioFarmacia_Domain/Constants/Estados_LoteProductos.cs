using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Domain.Constants
{
    public enum Estados_LoteProductos
    {
        DISPONIBLE,
        POR_VENCER,
        VENCIDO,
        NO_DISPONIBLE
    }

    public static class Colores_LoteProductos
    {
        public const string DISPONIBLE = "#28a745";
        public const string POR_VENCER = "#ffc107";
        public const string VENCIDO = "#dc3545";
        public const string NO_DISPONIBLE = "#6c757d";
    }
}