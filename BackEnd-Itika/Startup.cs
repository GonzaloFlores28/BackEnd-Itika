using BackEnd_Itika.Data;
using BackEnd_Itika.Data.LogearUsario;
using BackEnd_Itika.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd_Itika.Tools;
using BackEnd_Itika.Data.Planilla; 

namespace BackEnd_Itika
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContextPool<Biometrico_ItikaContext>(options => options.UseSqlServer(
             Configuration.GetConnectionString("AppConnection")));

            //
            //services.AddDatabaseDeveloperPageExceptionFilter();
            //


            services.AddScoped<IArea, AreaData>();
            services.AddScoped<IAsignarTurno, AsignarTurnoData>();
            services.AddScoped<IBiometrico, BiometricoData>();
            services.AddScoped<IEmpleado, EmpleadoData>();
            services.AddScoped<IHoraExtra, HoraExtraData>();
            services.AddScoped<IPermiso, PermisoData>();
            //de la tabla plantilla se sacara 2 addscoped
            services.AddScoped<IAdministracion, AdministracionData>();
            //services.AddScoped<IPlanta, PlantaData>();
            //
            services.AddScoped<IRol, RolData>();
            services.AddScoped<ITipo, TipoData>();
            services.AddScoped<ITurno, TurnoData>();
            services.AddScoped<IUsuario, UsuarioData>();
            

            //
            
            ///
            services.AddScoped<ILogearUsuario, LogearUsuarioData>();
            ///

            //    services.AddDbContext<Db_BiometricoItikaContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("AppConnection")));
            // CONFIGURACIÓN DEL SERVICIO DE AUTENTICACIÓN JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"]))
                    };
                });
            //
            //services.AddHostedService<IntervalTaskHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
