using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApp;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentContext>(opt =>
 opt.UseInMemoryDatabase("StudentList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API V1");
    });
    ;
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Student API",
        Description = "demo Student API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://adres_strony")
        },
    });
});
var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
