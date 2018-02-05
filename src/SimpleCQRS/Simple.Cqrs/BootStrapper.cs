using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Simple.Cqrs.Aggregate;
using Simple.Cqrs.Command;
using Simple.Cqrs.Context;
using Simple.Cqrs.Query;
using Simple.Cqrs.Repository;

namespace Simple.Cqrs
{
    public static class BootStrapper
    {
        public static void Configure(this IServiceCollection service)
        {      
            service.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            service.AddSingleton<ICommandHandler<CreateTaskCommand>, CreateTaskCommandHandler>();
            service.AddSingleton<ICommandHandler<ChangeTaskStatusCommand>, ChangeTaskStatusCommandHandler>();

            service.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            service.AddSingleton<IQueryHandler<GetTasksQuery, IQueryable<Task>>, GetTasksQueryHandler>();

            service.AddSingleton<BaseDbContext, TaskContext>();
            service.AddSingleton<IReadRepository<Task>, BaseRepository<Task>>();
            service.AddSingleton<IWriteRepository<Task>, BaseRepository<Task>>();
        }
    }
}
