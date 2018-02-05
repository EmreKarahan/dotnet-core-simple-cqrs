using System;
using System.Linq;
using Simple.Cqrs.Aggregate;
using Simple.Cqrs.Repository;

namespace Simple.Cqrs.Query
{
    public class GetTasksQueryHandler : IQueryHandler<GetTasksQuery, IQueryable<Task>>
    {
        private readonly IReadRepository<Task> _readRepository;

        public GetTasksQueryHandler(IReadRepository<Task> readRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
        }

        public IQueryable<Task> Query(GetTasksQuery query)
        {
            return _readRepository.GetAll(query.Predicate);
        }
    }
}
