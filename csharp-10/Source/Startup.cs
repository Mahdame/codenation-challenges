using AutoMapper;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Source
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public StartupIdentityServer IdentitServerStartup { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            if (!environment.IsEnvironment("Testing"))
                IdentitServerStartup = new StartupIdentityServer(environment);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization(opt =>
                {
                    // add policies here
                    opt.AddPolicy("Admin", policy => policy.RequireClaim("Email", "tegglestone9@blog.com"));
                    opt.AddPolicy("User", policy => policy.RequireRole("User"));
                })
                .AddJsonFormatters();

            services.AddDbContext<CodenationContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAccelerationService, AccelerationService>();
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<ISubmissionService, SubmissionService>();
            services.AddScoped<IResourceOwnerPasswordValidator, PasswordValidatorService>();
            services.AddScoped<IProfileService, UserProfileService>();

            if (IdentitServerStartup != null)
                IdentitServerStartup.ConfigureServices(services);

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "codenation";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (IdentitServerStartup != null)
                IdentitServerStartup.Configure(app, env);

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
