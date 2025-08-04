using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Shared.Endpoints;

namespace InventarioFarmacia_Back
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

            productos.MapGet(ProductsEndpoints.GetById, async (int id, IProductoService _productoService) =>
            {
                var product = await _productoService.ObtenerProductoPorIdAsync(id);
                return product is not null ? Results.Ok(product) : Results.NotFound();
            });
        }
    }
}