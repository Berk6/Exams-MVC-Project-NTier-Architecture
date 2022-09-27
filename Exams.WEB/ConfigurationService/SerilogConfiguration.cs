using Exams.WEB.ConfigurationService;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;

namespace Exam.ServiceConfigurations
{
    public static class SerilogConfiguration
    {
        public static WebApplicationBuilder SerilogCon(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All;
                logging.RequestHeaders.Add("sec-ch-ua");
                logging.ResponseHeaders.Add("MyResponseHeader");
                logging.MediaTypeOptions.AddText("application/javascript");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });
            SqlColumn sqlColumn = new SqlColumn();
            sqlColumn.ColumnName = "UserName";
            sqlColumn.DataType = System.Data.SqlDbType.NVarChar;
            sqlColumn.PropertyName = "UserName";
            sqlColumn.DataLength = 50;
            sqlColumn.AllowNull = true;
            ColumnOptions columnOpt = new ColumnOptions();
            columnOpt.Store.Remove(StandardColumn.Properties);
            columnOpt.Store.Add(StandardColumn.LogEvent);
            columnOpt.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };

            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.MSSqlServer(
                connectionString: builder.Configuration.GetConnectionString("SqlCon"),
                 sinkOptions: new MSSqlServerSinkOptions
                 {
                     AutoCreateSqlTable = true,
                     TableName = "logs",

                 },
                 appConfiguration: null,
                 columnOptions: columnOpt
                                 )
                .Enrich.FromLogContext()
                .Enrich.With<CustomUserNameColumn>()
                .MinimumLevel.Information()
                .CreateLogger();
            builder.Host.UseSerilog((context, loggerConfig) =>
            {
                loggerConfig.Filter.ByIncludingOnly(logevent => logevent.Level == Serilog.Events.LogEventLevel.Information);
            });
            return builder;
        }
    }
}
