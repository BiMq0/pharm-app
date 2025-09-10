using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.Endpoints;
namespace InventarioFarmacia_Back.Mappers
{
    public class LotesMapper
    {
        public void Map(WebApplication app)
        {
            var lotes = app.MapGroup(LotesEndpoints.BASE);

            lotes.MapGet(LotesEndpoints.GET_ALL, async () =>
            {
                // Placeholder for actual service call
                return Results.Ok(new List<string> { "Lote1", "Lote2" });
            });

            lotes.MapGet(LotesEndpoints.GET_FOR_PRODUCT, async (int idProducto) =>
            {
                // Placeholder for actual service call
                return Results.Ok();
            });

            lotes.MapGet(LotesEndpoints.GET_BY_ID, async (int id) =>
            {
                // Placeholder for actual service call
                return Results.Ok($"Lote{id}");
            });


            lotes.MapPost(LotesEndpoints.CREATE, async (string nuevoLote) =>
            {
                // Placeholder for actual service call
                return Results.Created($"/lotes/{nuevoLote}", nuevoLote);
            });


            lotes.MapPut(LotesEndpoints.UPDATE, async (int id, string loteActualizado) =>
            {
                // Placeholder for actual service call
                return Results.Ok($"Lote{id} actualizado a {loteActualizado}");
            });


            lotes.MapDelete(LotesEndpoints.DELETE, async (int id) =>
            {
                // Placeholder for actual service call
                return Results.Ok($"Lote{id} eliminado");
            });
        }
    }
}