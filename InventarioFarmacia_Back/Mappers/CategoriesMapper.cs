using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.Endpoints;
using InventarioFarmacia_Shared.DTOs.Categorias;

namespace InventarioFarmacia_Back.Mappers
{
    public class CategoriesMapper
    {
        public void Map(WebApplication app)
        {
            var mapGroup = app.MapGroup(CategoriesEndpoints.BASE)
                .WithTags("Categorías");

            mapGroup.MapGet(CategoriesEndpoints.GET_ALL, async (ICategoriaService categoriaService, string filtro = "") =>
            {
                var categorias = await categoriaService.ObtenerCategoriasAsync(filtro);
                return Results.Ok(categorias);
            })
            .WithName("GetAllCategorias")
            .WithSummary("Obtener todas las categorías")
            .WithDescription("Obtiene la lista completa de categorías de productos farmacéuticos con filtro opcional");

            mapGroup.MapGet(CategoriesEndpoints.GET_BY_ID, async (ICategoriaService categoriaService, int id) =>
            {
                var categoria = await categoriaService.ObtenerCategoriaPorIdAsync(id);
                return categoria != null ? Results.Ok(categoria) : Results.NotFound();
            })
            .WithName("GetCategoriaById")
            .WithSummary("Obtener categoría por ID")
            .WithDescription("Obtiene una categoría específica con todos sus productos asociados");

            mapGroup.MapGet(CategoriesEndpoints.GET_FOR_NEW_PRODUCT, async (ICategoriaService categoriaService) =>
            {
                var categorias = await categoriaService.ObtenerCategoriasParaNuevoProducto();
                return Results.Ok(categorias);
            })
            .WithName("GetCategoriasForNewProduct")
            .WithSummary("Obtener categorías para nuevo producto")
            .WithDescription("Obtiene las categorías disponibles para asignar a un nuevo producto");

            mapGroup.MapPost(CategoriesEndpoints.CREATE, async (ICategoriaService categoriaService, CategoriaNuevoDTO categoriaDto) =>
            {
                var result = await categoriaService.CrearCategoriaAsync(categoriaDto);
                return result ? Results.NoContent() : Results.BadRequest();
            })
            .WithName("CreateCategoria")
            .WithSummary("Crear nueva categoría")
            .WithDescription("Crea una nueva categoría de productos en el sistema");

            mapGroup.MapPut(CategoriesEndpoints.UPDATE, async (ICategoriaService categoriaService, CategoriaEdicionDTO categoriaDto) =>
            {
                var result = await categoriaService.ActualizarCategoriaAsync(categoriaDto);
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateCategoria")
            .WithSummary("Actualizar categoría")
            .WithDescription("Actualiza la información de una categoría existente");

            mapGroup.MapDelete(CategoriesEndpoints.DELETE, async (ICategoriaService categoriaService, int id) =>
            {
                var result = await categoriaService.EliminarCategoriaAsync(id);
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteCategoria")
            .WithSummary("Eliminar categoría")
            .WithDescription("Elimina una categoría del sistema (solo si no tiene productos asociados)");
        }
    }
}