using Assignment_ClassLibrary.Models.Validators;
using Assignment_WebApi.Contexts;
using Assignment_WebApi.Repositories;
using Assignment_WebApi.Services;
using Assignment_WebApi.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<ContentTypeService>();
builder.Services.AddScoped<ArticleRepository>();
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<ArticleRowRepositoy>();
builder.Services.AddScoped<ContentTypeRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<ArticleValidator>();



var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
