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
            var mapGroup = app.MapGroup(CategoriesEndpoints.BASE);

            mapGroup.MapGet(CategoriesEndpoints.GET_ALL, async (ICategoriaService categoriaService, string filtro = "") =>
            {
                var categorias = await categoriaService.ObtenerCategoriasAsync(filtro);
                return Results.Ok(categorias);
            });

            mapGroup.MapGet(CategoriesEndpoints.GET_BY_ID, async (ICategoriaService categoriaService, int id) =>
            {
                var categoria = await categoriaService.ObtenerCategoriaPorIdAsync(id);
                return categoria != null ? Results.Ok(categoria) : Results.NotFound();
            });

            mapGroup.MapGet(CategoriesEndpoints.GET_FOR_NEW_PRODUCT, async (ICategoriaService categoriaService) =>
            {
                var categorias = await categoriaService.ObtenerCategoriasParaNuevoProducto();
                return Results.Ok(categorias);
            });

            mapGroup.MapPost(CategoriesEndpoints.CREATE, async (ICategoriaService categoriaService, CategoriaNuevoDTO categoriaDto) =>
            {
                var result = await categoriaService.CrearCategoriaAsync(categoriaDto);
                return result ? Results.NoContent() : Results.BadRequest();
            });

            mapGroup.MapPut(CategoriesEndpoints.UPDATE, async (ICategoriaService categoriaService, CategoriaEdicionDTO categoriaDto) =>
            {
                var result = await categoriaService.ActualizarCategoriaAsync(categoriaDto);
                return result ? Results.NoContent() : Results.NotFound();
            });

            mapGroup.MapDelete(CategoriesEndpoints.DELETE, async (ICategoriaService categoriaService, int id) =>
            {
                var result = await categoriaService.EliminarCategoriaAsync(id);
                return result ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}