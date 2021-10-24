﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using MartinCostello;
using ECommerce;


namespace Ecommerce.IntegrationTests
{
    

    public class AppTestFixture : WebApplicationFactory<Program>
    {
        // Must be set in each test
        public ITestOutputHelper Output { get; set; }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var builder = base.CreateWebHostBuilder();
            //builder.ConfigureLogging(logging =>
            //{
            //    logging.(); // Remove other loggers
            //    logging.AddXUnit(Output); // Use the ITestOutputHelper instance
            //});

            return builder;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // Don't run IHostedServices when running as a test
            builder.ConfigureTestServices((services) =>
            {
                services.RemoveAll(typeof(IHostedService));
            });
        }
    }
}
