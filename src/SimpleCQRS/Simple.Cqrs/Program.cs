using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Simple.Cqrs.Aggregate;
using Simple.Cqrs.Command;
using Simple.Cqrs.Context;
using Simple.Cqrs.Query;

namespace Simple.Cqrs
{
    class Program
    {
        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection
                .BuildServiceProvider();


            // entry to run app
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // call bootstrapper
            services.Configure();

            // add logging
            services.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());

            services.AddLogging();


            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            services.AddDbContext<TaskContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TaskContext")));

            // add app
            services.AddTransient<App>();
        }

        public class App
        {
            private readonly ICommandDispatcher _commandDispatcher;
            private readonly IQueryDispatcher _queryDispatcher;

            public App(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            {
                _commandDispatcher = commandDispatcher;
                _queryDispatcher = queryDispatcher;
            }
            public void Run()
            {
                var createCommand = new CreateTaskCommand { Title = "CQRS Örneği", UserName = "Emre Karahan", IsCompleted = false, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now };

                _commandDispatcher.Execute(createCommand);

                var getTasksQuery = new GetTasksQuery { Predicate = (t) => t.IsCompleted == false };

                IQueryable<Task> tasks = _queryDispatcher.Query<GetTasksQuery, IQueryable<Task>>(getTasksQuery);

                Console.WriteLine("Bitmemiş tasklar getiriliyor.");

                foreach (var task in tasks.ToList())
                {
                    Console.WriteLine(task);
                }

                var lastTask = tasks.ToList().LastOrDefault();

                var changeCommand = new ChangeTaskStatusCommand { TaskId = 24, IsCompleted = true, UpdatedOn = DateTime.Now.AddMinutes(5) };

                _commandDispatcher.Execute(changeCommand);

                Console.ReadLine();
            }
        }

    }
}
