using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Data.Repositories;
using AutoMapper;
using Api.Dtos.Level;
using Api.Models;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

// builder.Services.AddDbContext<AppDbContext>(
//   options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion),
//   ServiceLifetime.Transient
//   );

builder.Services.AddDbContext<AppDbContext>(
    opts =>
    {
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    }, ServiceLifetime.Transient
);

builder.Services.AddScoped<ILevelRepo, LevelRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("api/v1/levels", async (ILevelRepo levelRepo, IMapper mapper) =>
{
  var levels = await levelRepo.GetAllLevels();
  return Results.Ok(mapper.Map<IEnumerable<LevelReadDto>>(levels));
});

app.MapGet("api/v1/levels/{id}", async (int id, ILevelRepo levelRepo, IMapper mapper) =>
{
  var level = await levelRepo.GetLevelById(id);
  if (level == null)
  {
    return Results.NotFound();
  }
  return Results.Ok(mapper.Map<LevelReadDto>(level));
});

app.MapPost("api/v1/levels", async (LevelCreateDto levelCreateDto, ILevelRepo levelRepo, IMapper mapper) =>
{
  var levelModel = mapper.Map<Level>(levelCreateDto);
  await levelRepo.CreateLevel(levelModel);
  var levelReadDto = mapper.Map<LevelReadDto>(levelModel);
  return Results.CreatedAtRoute("GetLevelById", new { Id = levelReadDto.Id }, levelReadDto);
});

app.Run();