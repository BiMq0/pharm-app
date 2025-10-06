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
            var lotes = app.MapGroup(LotesEndpoints.BASE)
                .WithTags("Lotes");

            lotes.MapGet(LotesEndpoints.GET_ALL, async (ILoteService loteService) =>
            {
                var lotes = await loteService.ObtenerLotesAsync();
                return Results.Ok(lotes);
            })
            .WithName("GetAllLotes")
            .WithSummary("Obtener todos los lotes")
            .WithDescription("Obtiene la lista completa de lotes registrados en el sistema con información de vencimiento");

            lotes.MapGet(LotesEndpoints.GET_FOR_PRODUCT, async (int productId, ILoteService loteService) =>
            {
                var lotes = await loteService.ObtenerLotesPorIdProductoParaCompraAsync(productId);
                return Results.Ok(lotes);
            })
            .WithName("GetLotesForProduct")
            .WithSummary("Obtener lotes por producto")
            .WithDescription("Obtiene todos los lotes disponibles para un producto específico, ideal para compras");

            lotes.MapGet(LotesEndpoints.GET_FOR_PRODUCT_TO_SHOP, async (int productId, ILoteService loteService) =>
            {
                var lotes = await loteService.ObtenerLotesPorIdProductoParaCompraAsync(productId);
                return Results.Ok(lotes);
            })
            .WithName("GetLotesForProductToShop")
            .WithSummary("Obtener lotes para compra")
            .WithDescription("Obtiene lotes de un producto específico optimizados para proceso de compra");

            lotes.MapGet(LotesEndpoints.GET_BY_ID, async (ILoteService loteService, int id) =>
            {
                var lote = await loteService.ObtenerLotePorIdAsync(id);
                return lote is not null ? Results.Ok(lote) : Results.NotFound();
            })
            .WithName("GetLoteById")
            .WithSummary("Obtener lote por ID")
            .WithDescription("Obtiene un lote específico con toda su información y productos individuales");

            lotes.MapPost(LotesEndpoints.CREATE, async (LoteNuevoDTO nuevoLote, ILoteService loteService) =>
            {
                var loteCreado = await loteService.CrearLoteAsync(nuevoLote);
                return Results.Ok(loteCreado);
            })
            .WithName("CreateLote")
            .WithSummary("Crear nuevo lote")
            .WithDescription("Crea un nuevo lote de productos con fecha de vencimiento y número de lote");

            lotes.MapPut(LotesEndpoints.UPDATE, async (int id, /*LoteActualizadoDTO */ string loteActualizado, ILoteService loteService) =>
            {
                await Task.Delay(1);
                throw new NotImplementedException();
            })
            .WithName("UpdateLote")
            .WithSummary("Actualizar lote")
            .WithDescription("Actualiza la información de un lote existente");

            lotes.MapPut(LotesEndpoints.UPDATE_INVENTORY, async (int id, List<LoteToTransferProductsDTO> lotesToTransfer, ILoteService loteService) =>
            {
                var resultado = await loteService.RealizarTransferenciaDeInventario(lotesToTransfer, id);
                return resultado ? Results.Ok("Lotes transferidos exitosamente") : Results.BadRequest("Error al transferir los lotes");
            });

            lotes.MapDelete(LotesEndpoints.DELETE, async (int id) =>
            {
                await Task.Delay(1);
                return Results.Ok($"Lote{id} eliminado");
            })
            .WithName("DeleteLote")
            .WithSummary("Eliminar lote")
            .WithDescription("Elimina un lote del sistema");
        }
    }
}