using WebService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebService.ApplicationCore.Interfaces;
using WebService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EFDbContext>(opt =>
    opt.UseInMemoryDatabase("LogEntityDb"));

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
