using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoAcuiculture.API.Models;
using ContosoAcuiculture.API.Services;
using Microsoft.Azure.Cosmos;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace ContosoAcuiculture.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static string databaseName { get; set; }
        public static string containerName { get; set; }
        public static string account { get; set; }
        public static string key { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            string databaseName = this.Configuration["CosmosDb:DatabaseName"];
            string containerName = this.Configuration["CosmosDb:ContainerName"];
            string account = this.Configuration["CosmosDb:Account"];
            string key = this.Configuration["CosmosDb:Key"];

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSingleton<ICosmosDBService>(InitializeCosmosClientInstanceAsync(databaseName, containerName, account, key).GetAwaiter().GetResult());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContosoAcuiculture.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static async Task<CosmosDBService> InitializeCosmosClientInstanceAsync(string databaseName, string containerName, string account, string key)
        {
            CosmosClient client = new CosmosClient(account, key);

            CosmosDBService cosmosDBService = new CosmosDBService(client, databaseName, containerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);

            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/ShrimpId");

            return cosmosDBService;
        }
    }
}
