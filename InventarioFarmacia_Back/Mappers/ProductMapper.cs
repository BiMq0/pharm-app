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
            var productos = app.MapGroup(ProductsEndpoints.Base)
                .WithTags("Productos");

            productos.MapGet(ProductsEndpoints.GetAll, async (IProductoService _productoService, string filter = "") =>
            {
                var products = await _productoService.ObtenerProductosAsync(filter);
                return Results.Ok(products);
            })
            .WithName("GetAllProducts")
            .WithSummary("Obtener todos los productos")
            .WithDescription("Obtiene la lista completa de productos farmacéuticos con filtro opcional por nombre o código");

            productos.MapGet(ProductsEndpoints.GetById, async (IProductoService _productoService, int id) =>
            {
                var product = await _productoService.ObtenerProductoPorIdAsync(id);
                return product is not null ? Results.Ok(product) : Results.NotFound();
            })
            .WithName("GetProductById")
            .WithSummary("Obtener producto por ID")
            .WithDescription("Obtiene un producto específico con toda su información, categoría y lotes asociados");

            productos.MapGet(ProductsEndpoints.GetForOrder, async (IProductoService _productoService) =>
            {
                var products = await _productoService.ObtenerProductosParaCompraAsync();
                return Results.Ok(products);
            })
            .WithName("GetProductsForOrder")
            .WithSummary("Obtener productos para orden")
            .WithDescription("Obtiene productos disponibles optimizados para crear órdenes de compra");

            productos.MapPost(ProductsEndpoints.Create, async (ProductoNuevoDTO productoDto, IProductoService _productoService) =>
            {
                var created = await _productoService.CrearProductoAsync(productoDto);
                return created ? Results.Created() : Results.BadRequest();
            })
            .WithName("CreateProduct")
            .WithSummary("Crear nuevo producto")
            .WithDescription("Crea un nuevo producto farmacéutico con toda su información y categoría");

            productos.MapPut(ProductsEndpoints.Update, async (ProductoEdicionDTO productoDto, IProductoService _productoService) =>
            {
                var updated = await _productoService.ActualizarProductoAsync(productoDto);
                return updated ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateProduct")
            .WithSummary("Actualizar producto")
            .WithDescription("Actualiza la información de un producto existente incluyendo precio y categoría");

            productos.MapDelete(ProductsEndpoints.Delete, async (int id, IProductoService _productoService) =>
            {
                var deleted = await _productoService.EliminarProductoAsync(id);
                return deleted
                    ? Results.NoContent()
                    : Results.NotFound();
            })
            .WithName("DeleteProduct")
            .WithSummary("Eliminar producto")
            .WithDescription("Elimina un producto del sistema (solo si no tiene lotes o ventas asociadas)");
        }
    }
}