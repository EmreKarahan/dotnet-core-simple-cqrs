using System;
using Microsoft.Extensions.DependencyInjection;
namespace Simple.Cqrs.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        } 

        public TResult Query<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
              if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = _serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
            {
                throw new QueryHandlerNotFoundException(typeof(TQuery));
            }

            return handler.Query(query);
        }
    }
}
