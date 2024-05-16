using SurveyProject.BusinessLayer.Abstract;
using SurveyProject.BusinessLayer.Concrete;
using SurveyProject.DataAccessLayer.Abstract;
using SurveyProject.DataAccessLayer.Context;
using SurveyProject.DataAccessLayer.EntityFramework;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ISurveyService, SurveyManager>();
builder.Services.AddScoped<ISurveyDal, EfSurveyDal>();

builder.Services.AddScoped<IOptionService, OptionManager>();
builder.Services.AddScoped<IOptionDal, EfOptionDal>();

builder.Services.AddScoped<IVoteService, VoteManager>();
builder.Services.AddScoped<IVoteDal, EfVoteDal>();

builder.Services.AddDbContext<SurveyContext>();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
