using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Front.Components.SimpleComponents.Loader
{
    public static class EstadoCargador
    {
        public static bool IsLoading { get; set; } = false;
        public static void Activar()
        {
            IsLoading = true;
        }
        public static void Desactivar()
        {
            IsLoading = false;
        }
    }
}