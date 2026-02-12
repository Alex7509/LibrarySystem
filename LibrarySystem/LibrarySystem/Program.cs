using FluentValidation;
using LibrarySystem.Business.Interfaces;
using LibrarySystem.Business.Services;
using LibrarySystem.Common.Mappings;
using LibrarySystem.Common.Validators;
using LibrarySystem.Data.Interfaces;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Data.Settings;
using Serilog;


var builder = WebApplication.CreateBuilder(args);


// Serilog configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// MongoDB settings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// Dependency Injection
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IBorrowService, BorrowService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HealthCheck
builder.Services.AddHealthChecks();

builder.Services.AddValidatorsFromAssemblyContaining<AddBookValidator>();

MappingConfig.RegisterMappings();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
