using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Catálogo", Version = "v1" });
    c.SchemaFilter<OnlyRequiredPropertiesSchemaFilter>();
});

var mySqlConnection = builder.Configuration.GetConnectionString("MinhaApiConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                                          options.UseMySql(mySqlConnection,
                                          ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<ProdutoService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();