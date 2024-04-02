using CG.DVDCentral.PL2.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CG.DVDCentral.BL
{
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<DVDCentralEntities> options;
        protected readonly ILogger logger;

        public GenericManager(DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
        }

        public GenericManager(ILogger logger,
                              DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
        }

        public GenericManager() { }

        public static string[,] ConvertData<U>(List<U> entities, string[] columns) where U : class
        {
            string[,] data = new string[entities.Count + 1, columns.Length];

            int counter = 0;
            for (int i = 0; i < columns.Length; i++)
            {
                data[counter, i] = columns[i];
            }
            counter++;


            foreach (var entity in entities)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    data[counter, i] = entity.GetType().GetProperty(columns[i]).GetValue(entity, null).ToString();
                }
                counter++;
            }
            return data;
        }

        public List<T> Load()
        {
            try
            {
                if (logger != null) logger.LogWarning($"Get {typeof(T).Name}s");
                return new DVDCentralEntities(options)
                    .Set<T>()
                    .ToList<T>()
                    .OrderBy(x => x.SortField)
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> Load(string storedproc)
        {
            try
            {
                return new DVDCentralEntities(options)
                    .Set<T>()
                    .FromSqlRaw($"exec {storedproc}")
                    .ToList<T>()
                    .OrderBy(x => x.SortField)
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> Load(string storedproc, string value)
        {
            try
            {
                return new DVDCentralEntities(options)
                    .Set<T>()
                    .FromSqlRaw($"exec {storedproc} {value}")
                    .ToList<T>()
                    .OrderBy(x => x.SortField)
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public T LoadById(Guid id)
        {
            try
            {
                var row = new DVDCentralEntities(options).Set<T>().Where(t => t.Id == id).FirstOrDefault();
                return row;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Guid Insert(T entity,
                       Expression<Func<T, bool>> predicate = null,
                       bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    if ((predicate == null) || ((predicate != null) && (!dc.Set<T>().Any(predicate))))
                    {
                        IDbContextTransaction dbTransaction = null;
                        if (rollback) dbTransaction = dc.Database.BeginTransaction();
                        entity.Id = Guid.NewGuid();
                        dc.Set<T>().Add(entity);
                        results = dc.SaveChanges();
                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row already exists.");
                    }
                }
                return entity.Id;
            }
            catch
            {
                throw;
            }
        }

        public Guid Insert(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    entity.Id = Guid.NewGuid();

                    dc.Set<T>().Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();

                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    dc.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    T row = dc.Set<T>().FirstOrDefault(t => t.Id == id);

                    if (row != null)
                    {
                        dc.Set<T>().Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
