
using Medical.Api.Extensions.Middleware;
using Medical.Application.UseCase.Extensions;
using Medical.Persistence.Extensions;
using Medical.Identity.Extensions;
using Medical.Infrastructure.Extensions;
using Medical.Domain.JwtConfiguration;
using Medical.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwagger();


builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddInfraestructureServices();
builder.Services.AddInjectionApplication();
builder.Services.AddInjectionPersistence(builder.Configuration);

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("DoctorOnly", policy => policy.RequireClaim("Doctor"));
});
builder.Services.AddInjectionIdentity(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.AddMiddleware();

app.MapControllers();

app.Run();
