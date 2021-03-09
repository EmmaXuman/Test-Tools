using LogClient.Abstraction;
using LogClient.Application;
using LogClient.Domain.Repositories;
using LogClient.Infrastuncture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace UserSystemLog
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddLogClient( this IServiceCollection services,
            IConfiguration configuration )
        {


            AddDb(services,
                configuration.GetSection("DbConfig:Mysql:ConnectionString").Value);

            services.AddTransient<IStudentTrackLogTestService, StudentTrackLogTestService>();

            services.AddScoped<IStudentLogRepository, StudentLogRepository>();
            return services;
        }

        private static void AddDb( IServiceCollection services, string dbMySqlConnectionString )
        {
            #region MySql

            services.AddEntityFrameworkMySql()
                .AddDbContext<LogClientDBContext>(( serviceProvider, options ) =>
                {
                    options
                        .UseMySql(dbMySqlConnectionString,
                            mySqlOptions => mySqlOptions
                                .ServerVersion(new Version(8, 0, 18), ServerType.MySql)
                        );
                });
            services.AddScoped(typeof(ILogClientRepository<>), typeof(LogClientRepository<>));

            #endregion

        }

    }
}
