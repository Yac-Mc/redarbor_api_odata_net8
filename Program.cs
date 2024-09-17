using API_Net8_OData.DBContext;
using API_Net8_OData.Models.HcmTimecheck;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using API_Net8_OData.Controllers;
using API_Net8_OData.Models.HCMSSO;

namespace API_Net8_OData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddControllers().AddOData(
                options => options
                    .Select()
                    .Filter()
                    .OrderBy()
                    .Count()
                    .Expand()
                    .SetMaxTop(500)
                    .AddRouteComponents("odata", GetEdmModel()));

            builder.Services.AddDbContext<HcmTimecheckContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("MySQLTimecheckApi")));
            builder.Services.AddDbContext<HcmSsoContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("MySQLConnection_sso")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<TimeCheck>("TimeChecks");
            builder.EntitySet<WorkingDay>("WorkingDays");
            builder.EntitySet<WorkingDayAssigment>("WorkingDayAssigments");
            builder.EntitySet<ActionUrl>("ActionUrls");

            return builder.GetEdmModel();
        }
    }
}
