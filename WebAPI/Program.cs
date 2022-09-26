using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyInjection.AutoFac;
using DataAccess.Abstract;
using DataAccess.Concrete;

//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());//Dependency injection için gerekli adým.Autofac kullanýmý için hazýrlýk.
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutoFacBusinessModule());//Baðýmlýlýktan kurtulmak için IoC yapýlan dosyanýn yolunu veriyoruz.
});

builder.Services.AddControllers();

//For Product
//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();
////For Category
//builder.Services.AddSingleton<ICategoryService, CategoryManager>();
//builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
////For Shop
//builder.Services.AddSingleton<IShopService, ShopManager>();
//builder.Services.AddSingleton<IShopDal, EfShopDal>();



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
