using FootballAPI.Context;
using FootballAPI.Profiles;
using FootballAPI.Repositories;
using FootballAPI.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FootballAPI
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
            services.AddDbContext<FootballDbContext>(opt => opt.UseInMemoryDatabase("FootballDb"));
            services.AddSwaggerGen();
            services.AddDbContext<FootballDbContext>();
            services.AddControllers();
            services.AddAutoMapper(typeof(PlayerProfile));
            services.AddAutoMapper(typeof(TeamProfile));
            services.AddAutoMapper(typeof(StadiumProfile));

            services.AddTransient<IPlayersRepository, PlayersRepository>();
            services.AddTransient<ITeamsRepository, TeamsRepository>();
            services.AddTransient<IStadiumsRepository, StadiumsRepository>();

            services.AddTransient<IPlayerValidation, PlayerValidation>();
            services.AddTransient<ITeamValidation, TeamValidation>();
            services.AddTransient<IStadiumValidation, StadiumValidation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());

            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Football Manager API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
