using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SistemaBiblioteca.Components;
using SistemaBiblioteca.Data;
using SistemaBiblioteca.Services;


namespace SistemaBiblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();


            // Bibliotefa MudBlazer
            builder.Services.AddMudServices();
            builder.Services.AddTransient<SeedDb>();

            builder.Services.AddScoped<LoginService>();
            //builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

         

            // Conexao com o Sqlite3 - Correta
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionSqlite") ??
                                  throw new InvalidOperationException("Connection string 'DefaultConnectionSqlite' not found.")));

       
            var app = builder.Build();

            SeedData(app);
            static void SeedData(WebApplication app)
            {
                IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();
                using IServiceScope scope = scopedFactory!.CreateScope();
                SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
                service!.SeedAsync().Wait();
            }





            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }



            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
