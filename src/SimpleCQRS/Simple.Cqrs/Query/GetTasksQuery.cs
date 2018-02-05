using System;
using System.Linq.Expressions;
using Simple.Cqrs.Aggregate;

namespace Simple.Cqrs.Query
{
    public class GetTasksQuery : IQuery
    {
        public Expression<Func<Task, bool>> Predicate { get; set; }

    }
}
