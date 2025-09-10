using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.Endpoints;

namespace InventarioFarmacia_Back.Mappers
{
    public static class InventoryMapper
    {
        public static void Map(WebApplication app)
        {
            var inventarios = app.MapGroup(InventoryEndpoints.BASE);

            inventarios.MapGet(InventoryEndpoints.GET_ALL, async (IInventarioService inventarioService) =>
            {
                var inventarios = await inventarioService.ObtenerInventariosAsync();
                return Results.Ok(inventarios);
            });

            inventarios.MapGet(InventoryEndpoints.GET_BY_ID, async (int id, IInventarioService inventarioService) =>
            {
                var inventario = await inventarioService.ObtenerInventarioPorIdAsync(id);
                return inventario is not null ? Results.Ok(inventario) : Results.NotFound();
            });

            inventarios.MapPost(InventoryEndpoints.CREATE, async (InventarioNuevoDTO nuevoInventario, IInventarioService inventarioService) =>
            {
                var inventarioCreado = await inventarioService.CrearInventarioAsync(nuevoInventario);
                return Results.Ok(inventarioCreado);
            });
        }
    }
}