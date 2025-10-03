using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.Endpoints;
using InventarioFarmacia_Shared.DTOs.Inventarios;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Back.Mappers
{
    public class InventoryMapper
    {
        public void Map(WebApplication app)
        {
            var inventarios = app.MapGroup(InventoryEndpoints.BASE)
                .WithTags("Inventarios");

            inventarios.MapGet(InventoryEndpoints.GET_ALL, async (IInventarioService inventarioService) =>
            {
                var inventarios = await inventarioService.ObtenerInventariosAsync();
                return Results.Ok(inventarios);
            })
            .WithName("GetAllInventarios")
            .WithSummary("Obtener todos los inventarios")
            .WithDescription("Obtiene la lista completa de inventarios/almacenes disponibles en el sistema");

            inventarios.MapGet(InventoryEndpoints.GET_BY_ID, async (int id, IInventarioService inventarioService) =>
            {
                var inventario = await inventarioService.ObtenerInventarioPorIdAsync(id);
                return inventario is not null ? Results.Ok(inventario) : Results.NotFound();
            })
            .WithName("GetInventarioById")
            .WithSummary("Obtener inventario por ID")
            .WithDescription("Obtiene un inventario específico con todos sus productos y ubicaciones");

            inventarios.MapPost(InventoryEndpoints.CREATE, async (InventarioNuevoDTO nuevoInventario, IInventarioService inventarioService) =>
            {
                var inventarioCreado = await inventarioService.CrearInventarioAsync(nuevoInventario);
                return Results.Ok(inventarioCreado);
            })
            .WithName("CreateInventario")
            .WithSummary("Crear nuevo inventario")
            .WithDescription("Crea un nuevo inventario/almacén en el sistema para organizar productos");
        }
    }
}