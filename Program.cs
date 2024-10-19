using Microsoft.EntityFrameworkCore;
using sticky_tunes_backend.Data;
using sticky_tunes_backend.Mappings;
using sticky_tunes_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* WHAT I ADDED */

// Database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StickyTunesDbContext>(options => { options.UseMySQL(connectionString); });
// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// HttpClient for external API calls
builder.Services.AddHttpClient();
// SpotifyService as scoped
builder.Services.AddScoped<SpotifyService>();
// CORS stuff
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

/* */

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

/* */
// Use the policy
app.UseCors("AllowAll");
/* */

app.UseAuthorization();

app.MapControllers();

app.Run();
