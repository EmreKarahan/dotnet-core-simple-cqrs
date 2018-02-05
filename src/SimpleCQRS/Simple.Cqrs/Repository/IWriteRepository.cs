namespace Simple.Cqrs.Repository
{
    public interface IWriteRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void DetectUpdate(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Save();
    }
}
