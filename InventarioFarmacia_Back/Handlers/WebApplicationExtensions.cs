using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Back.Mappers;

namespace InventarioFarmacia_Back.Handlers
{
    public static class WebApplicationExtensions
    {
        public static void MapEndpoints(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var productMapper = scope.ServiceProvider.GetRequiredService<ProductMapper>();
                var categoriesMapper = scope.ServiceProvider.GetRequiredService<CategoriesMapper>();
                var loteMapper = scope.ServiceProvider.GetRequiredService<LotesMapper>();
                var inventarioMapper = scope.ServiceProvider.GetRequiredService<InventoryMapper>();

                productMapper.Map(app);
                categoriesMapper.Map(app);
                loteMapper.Map(app);
                inventarioMapper.Map(app);
            }
        }
    }
}