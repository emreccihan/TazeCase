using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TazeCase.Form.Business.Mapper;
using TazeCase.Form.Business.Service.Form;
using TazeCase.Form.Business.Service.FormField;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Data.Context;
using TazeCase.Form.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IFormService, FormService>();
builder.Services.AddTransient<IFormFieldService, FormFieldService>();
builder.Services.AddTransient<IFormFieldRepository, FormFieldRepository>();
builder.Services.AddTransient<IFormRepository, FormRepository>();


#if DEBUG
builder.Services.AddDbContext<FormDataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));

#else
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endif

var automapper = new MapperConfiguration(item => item.AddProfile(new GeneralMapping()));
IMapper mapper = automapper.CreateMapper();
builder.Services.AddSingleton(mapper);

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
