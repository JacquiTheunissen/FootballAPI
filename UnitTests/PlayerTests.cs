using Autofac;
using FootballAPI.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.IO;

namespace FootballAPI.UnitTests
{
    [TestClass]
    public class PlayerTests
    {
        private IContainer _container;

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NullLogger<PlayersRepository>>().As<ILogger<PlayersRepository>>();
            builder.RegisterType<PlayersRepository>().As<IPlayersRepository>();

            _container = builder.Build();
        }

        [TearDown]
        public void TearDown()
        {
            _container?.Dispose();
        }
    }
}
