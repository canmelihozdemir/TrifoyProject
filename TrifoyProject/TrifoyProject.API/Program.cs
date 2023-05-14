using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TrifoyProject.API.Middlewares;
using TrifoyProject.API.Modules;
using TrifoyProject.Core.Repositories;
using TrifoyProject.Core.Services;
using TrifoyProject.Core.UnitOfWorks;
using TrifoyProject.Entity;
using TrifoyProject.Repository;
using TrifoyProject.Repository.Repositories;
using TrifoyProject.Repository.UnitOfWorks;
using TrifoyProject.Service.Mapping;
using TrifoyProject.Service.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});


builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    //username default unique dir
    options.User.RequireUniqueEmail = false;
    options.User.AllowedUserNameCharacters = string.Empty;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

}).AddEntityFrameworkStores<AppIdentityDbContext>();








builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(conteinerBuilder=>conteinerBuilder.RegisterModule(new RepositoryServiceModule()));



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

app.UseCustomException();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
