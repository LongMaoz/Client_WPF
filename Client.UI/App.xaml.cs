using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Client.Service.Services;
using Client.Service.Interface;
using Client.Data;
using Microsoft.EntityFrameworkCore;
using Autofac.Core;
using Client.Model.Model.SqlLite;
using Client.UI.AutofacModule;
using Client.UI.Extensions;

namespace Client.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(service =>
                {
                    service.AddDbContext<DbContextInfoSqlLite>(x => x.UseSqlite("Data Source = .\\SqlLite.db"));
                })
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new ServiceModule());
                    builder.RegisterModule(new WindowModule());
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var cw = AppHost.Services.GetAutofacRoot();
            var mainWindow = cw.Resolve<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
