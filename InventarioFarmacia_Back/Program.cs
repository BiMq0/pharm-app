using InventarioFarmacia_Back;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Adicion de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pharm API", Description = "Documentacion de API para farmacia UwU", Version = "v1" }); });
builder.Services.AddDbContext<PharmDBContext>(options => options.UseSqlite("DataSource=PharmDBContext.db"));
builder.Services.AddScopedRepositories();
builder.Services.AddScopedServices();
builder.Services.AddScopedMappers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "PharmAPI V1");
   });
}

using (var scope = app.Services.CreateScope())
{
   var mapper = scope.ServiceProvider.GetRequiredService<ProductMapper>();
   mapper.Map(app);
}

app.Run();
