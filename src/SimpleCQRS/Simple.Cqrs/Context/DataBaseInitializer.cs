using Microsoft.EntityFrameworkCore;

namespace Simple.Cqrs.Context
{
    public class DataBaseInitializer<T> where T : DbContext, new()
    {
        private static bool _isDbInitialized = false;
        private static readonly object ObjLock = new object();

        public static void InitializedDatabase(bool force = false)
        {
            lock (ObjLock)
            {
                if (!_isDbInitialized)
                {
                    //Database.SetInitializer<T>(new InitializerIfNotExists<T>());
                    //T instance = new T();
                    //instance.Database.Initialize(force);
                    //instance.Database.Log = m => System.Diagnostics.Debug.Write(m, "DataContext");
                    _isDbInitialized = true;
                }
            }
        }
    }
}
