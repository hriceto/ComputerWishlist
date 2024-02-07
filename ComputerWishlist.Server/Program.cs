using CumputerWishlist.Data;
using CumputerWishlist.Data.DataController;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComputerWishlist.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CumputerWishlistDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IComputerSpecDataController, ComputerSpecDataController>();
builder.Services.AddScoped<IUserDataController, UserDataController>();
builder.Services.AddScoped<IComponentTypeDataController, ComponentTypeDataController>();
IMapper mapper = new MapperConfiguration(mc => {mc.AddProfile(new MappingProfile());}).CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapFallbackToFile("/index.html");

app.Run();
