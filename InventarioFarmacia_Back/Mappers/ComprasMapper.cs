using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.DTOs.Compras;
using InventarioFarmacia_Shared.Endpoints;
namespace InventarioFarmacia_Back.Mappers
{
    public class ComprasMapper
    {
        public void Map(WebApplication app)
        {
            var compras = app.MapGroup(ComprasEndpoints.BASE);

            compras.MapGet(ComprasEndpoints.GET_ALL, async (IOrden_CompraService service) =>
            {
                var result = await service.ObtenerOrdenesCompraAsync();
                return Results.Ok(result);
            });

            compras.MapPost(ComprasEndpoints.CREATE, async (ComprasNuevaDTO nuevaCompra, IOrden_CompraService service) =>
            {
                var result = await service.CrearOrdenCompraAsync(nuevaCompra);
                return result ? Results.Ok(result) : Results.BadRequest("No se pudo crear la orden de compra.");
            });
        }
    }
}