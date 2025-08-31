using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.Endpoints;
using InventarioFarmacia_Shared.DTOs.Products;

namespace InventarioFarmacia_Back.Mappers
{
    public class ProductMapper
    {
        public void Map(WebApplication app)
        {
            var productos = app.MapGroup(ProductsEndpoints.Base);

            productos.MapGet(ProductsEndpoints.GetAll, async (IProductoService _productoService, string filter = "") =>
            {
                var products = await _productoService.ObtenerProductosAsync(filter);
                return Results.Ok(products);
            });

            productos.MapGet(ProductsEndpoints.GetById, async (IProductoService _productoService, int id) =>
            {
                var product = await _productoService.ObtenerProductoPorIdAsync(id);
                return product is not null ? Results.Ok(product) : Results.NotFound();
            });

            productos.MapPost(ProductsEndpoints.Create, async (ProductoNuevoDTO productoDto, IProductoService _productoService) =>
            {
                var created = await _productoService.CrearProductoAsync(productoDto);
                return created
                    ? Results.Created($"/api/products/{productoDto.Nombre}", productoDto)
                    : Results.BadRequest();
            });

            productos.MapPut(ProductsEndpoints.Update, async (ProductoEdicionDTO productoDto, IProductoService _productoService) =>
            {
                var updated = await _productoService.ActualizarProductoAsync(productoDto);
                return updated
                    ? Results.NoContent()
                    : Results.NotFound();
            });
            productos.MapDelete(ProductsEndpoints.Delete, async (int id, IProductoService _productoService) =>
            {
                var deleted = await _productoService.EliminarProductoAsync(id);
                return deleted
                    ? Results.NoContent()
                    : Results.NotFound();
            });
        }
    }
}