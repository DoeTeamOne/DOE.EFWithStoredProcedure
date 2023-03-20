using DOE.EFWithStoredProcedure.Context;
using DOE.EFWithStoredProcedure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
DOEConfigureServices(builder.Services);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void DOEConfigureServices(IServiceCollection services)
{
    services.AddDbContext<MovieContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Democonnection")));
    services.AddScoped<IMoviesServices, MoviesServices>();
}
