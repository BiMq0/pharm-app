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
            var compras = app.MapGroup(ComprasEndpoints.BASE)
                .WithTags("Órdenes de Compra");

            compras.MapGet(ComprasEndpoints.GET_ALL, async (IOrden_CompraService service) =>
            {
                var result = await service.ObtenerOrdenesCompraAsync();
                return Results.Ok(result);
            })
            .WithName("GetAllCompras")
            .WithSummary("Obtener todas las órdenes de compra")
            .WithDescription("Obtiene la lista completa de órdenes de compra con información resumida de cada una");

            compras.MapGet(ComprasEndpoints.GET_BY_ID, async (int id, IOrden_CompraService service) =>
            {
                var result = await service.ObtenerOrdenCompraPorIdAsync(id);
                return result != null ? Results.Ok(result) : Results.NotFound();
            })
            .WithName("GetCompraById")
            .WithSummary("Obtener orden de compra por ID")
            .WithDescription("Obtiene una orden de compra específica con todos sus lotes y productos involucrados");

            compras.MapPost(ComprasEndpoints.CREATE, async (ComprasNuevaDTO nuevaCompra, IOrden_CompraService service) =>
            {
                var result = await service.CrearOrdenCompraAsync(nuevaCompra);
                return result ? Results.Ok(result) : Results.BadRequest("No se pudo crear la orden de compra.");
            })
            .WithName("CreateCompra")
            .WithSummary("Crear nueva orden de compra")
            .WithDescription("Crea una nueva orden de compra con los lotes especificados y actualiza el inventario");

            compras.MapPut(ComprasEndpoints.CONFIRM, async (int id, IOrden_CompraService service) =>
            {
                var result = await service.ProcesarOrdenCompraRecibidaAsync(id);
                return result ? Results.Ok(result) : Results.BadRequest("No se pudo confirmar la orden de compra.");
            });

            compras.MapPut(ComprasEndpoints.CANCEL, async (int id, IOrden_CompraService service) =>
            {
                var result = await service.ProcesarOrdenCompraCanceladaAsync(id);
                return result ? Results.Ok(result) : Results.BadRequest("No se pudo cancelar la orden de compra.");
            });
        }
    }
}