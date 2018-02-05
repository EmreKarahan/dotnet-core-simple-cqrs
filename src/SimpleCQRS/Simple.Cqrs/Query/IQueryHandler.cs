namespace Simple.Cqrs.Query
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
    {
        TResult Query(TQuery query);
    }
}
