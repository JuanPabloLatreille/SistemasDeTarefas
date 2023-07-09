using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Mappings;
using SistemasDeTarefas.Repositories;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>(
                    options => options.UseSqlServer(
                            builder.Configuration.GetConnectionString("DataBase")
                        )
                ); ;

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

            builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}