using Arhitektura.IRepositories;
using Arhitektura.Repositories;
using Arhitektura.Roles;

namespace Arhitektura
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession();

            // Registracija repozitorijuma kao servisa
            services.AddScoped<IDestinacijaRepository, DestinacijaRepository>();
            services.AddScoped<ITuristickaAgencijaRepository, TuristickaAgencijaRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IAranzmanRepository, AranzmanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.Use(async (context, next) =>
            {
                if (string.IsNullOrEmpty(context.Session.GetString("Role")))
                {
                    context.Session.SetString("Role", "guest");
                }

                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
