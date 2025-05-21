using APIProjectBackend.Data;
using APIProjectBackend.EntititesDto;
using APIProjectBackend.EntityFrameworkRepository;
using APIProjectBackend.EntityFrameworkRepository.Contracts;
using APIProjectBackend.Service;
using APIProjectBackend.Service.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped(typeof(IBaseEntityFrameworkRepository<>), typeof(BaseEntityFrameworkRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));


builder.Services.AddScoped<IEntityFrameworkProjectRepository, EntityFrameworkProjectRepository>();
builder.Services.AddScoped<IEntityFrameworkTaskRepository, EntityFrameworkTaskRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("BasicRead", policy => policy.RequireAuthenticatedUser().RequireClaim("Permission", "Read")); 
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<APIProjectBackend.Middleware.ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
