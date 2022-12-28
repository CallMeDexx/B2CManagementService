using B2CDB;

namespace B2CManagementService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IWhiteListDB, DomainDB>();
            builder.Services.AddSingleton<IBlackListDB, DomainDB>();
            //builder.Services.AddSingleton<DatabaseConfig>();
            builder.Services.AddSingleton<IUserDB, UserDB>();
            builder.Services.AddSingleton<IB2CDB, DB>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
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