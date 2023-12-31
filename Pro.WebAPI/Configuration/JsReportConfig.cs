﻿using jsreport.AspNetCore;
using jsreport.Local;
using jsreport.Types;
using System.Runtime.InteropServices;

namespace Pro.API.Configuration;

public static class JsReportConfig
{
    public static WebApplicationBuilder AddJsReport(this WebApplicationBuilder builder)
    {
        var localReporting = new LocalReporting()
            .UseBinary(RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ?
                        jsreport.Binary.Linux.JsReportBinary.GetBinary() :
                        jsreport.Binary.JsReportBinary.GetBinary())
            .KillRunningJsReportProcesses()
            .Configure(cfg =>
            {
                cfg.ReportTimeout = 60000;
                cfg.Chrome = new ChromeConfiguration
                {
                    Timeout = 60000,
                    Strategy = ChromeStrategy.ChromePool,
                    NumberOfWorkers = 3
                };
                cfg.HttpPort = 3000;
                return cfg;
            })
            .AsUtility()
            .Create();

        builder.Services.AddJsReport(localReporting);

        return builder;
    }
}
