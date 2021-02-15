using Domain.Common;
using Infra;
using Domain.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Teams;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Domain.Authentication;
using Domain.Players;
using Domain.TeamPlayers;
using FluentValidation.AspNetCore;
using WebAPI.Controllers.Users;
using Infra.Repositories;

namespace WebAPI
{
    public class Startup
    {
        private const string Secret = "mY.Sec&rt@Ke2021";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("any",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    }
                );
            });

            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserValidator>());
            
            var key = Encoding.ASCII.GetBytes(Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // services.AddSingleton(typeof (IRepository<>), typeof (RepositoryInMemory<>));
            services.AddScoped(typeof (IRepository<>), typeof (Repository<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
            services.AddScoped<ITeamPlayersRepository, TeamPlayersRepository>();
            services.AddScoped<ITeamsService, TeamsService>();
            services.AddScoped<IPlayersRepository, PlayersRepository>();
            services.AddScoped<IPlayersService, PlayersService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICrypt, Crypt>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<BrasileiraoContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("any");
            using (var db = new BrasileiraoContext())
            {
                // Este comando irá criar o banco de dados (quando ele ainda não existir)
                // Também executará todas as migrations e seeders
                db.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
