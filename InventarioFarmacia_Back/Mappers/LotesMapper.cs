using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.DTOs.Lotes;
using InventarioFarmacia_Shared.Endpoints;
namespace InventarioFarmacia_Back.Mappers
{
    public class LotesMapper
    {
        public void Map(WebApplication app)
        {
            var lotes = app.MapGroup(LotesEndpoints.BASE);

            lotes.MapGet(LotesEndpoints.GET_ALL, async (ILoteService loteService) =>
            {
                var lotes = await loteService.ObtenerLotesAsync();
                return Results.Ok(lotes);
            });

            lotes.MapGet(LotesEndpoints.GET_FOR_PRODUCT, async (ILoteService loteService, int idProducto) =>
            {
                var lotes = await loteService.ObtenerLotesPorIdProductoParaCompraAsync(idProducto);
                return Results.Ok(lotes);
            });

            lotes.MapGet(LotesEndpoints.GET_FOR_PRODUCT_TO_SHOP, async (ILoteService loteService, int idProducto) =>
            {
                var lotes = await loteService.ObtenerLotesPorIdProductoParaCompraAsync(idProducto);
                return Results.Ok(lotes);
            });

            lotes.MapGet(LotesEndpoints.GET_BY_ID, async (ILoteService loteService, int id) =>
            {
                var lote = await loteService.ObtenerLotePorIdAsync(id);
                return lote is not null ? Results.Ok(lote) : Results.NotFound();
            });


            lotes.MapPost(LotesEndpoints.CREATE, async (LoteNuevoDTO nuevoLote, ILoteService loteService) =>
            {
                var loteCreado = await loteService.CrearLoteAsync(nuevoLote);
                return Results.Ok(loteCreado);
            });


            lotes.MapPut(LotesEndpoints.UPDATE, async (int id, /*LoteActualizadoDTO */ string loteActualizado, ILoteService loteService) =>
            {
                await Task.Delay(1);
                throw new NotImplementedException();
            });


            lotes.MapDelete(LotesEndpoints.DELETE, async (int id) =>
            {
                // Placeholder for actual service call
                await Task.Delay(1);
                return Results.Ok($"Lote{id} eliminado");
            });
        }
    }
}