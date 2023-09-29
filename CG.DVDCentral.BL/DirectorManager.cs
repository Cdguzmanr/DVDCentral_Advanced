using Microsoft.EntityFrameworkCore.Storage;

using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL;

namespace CG.DVDCentral.BL
{
    public class DirectorManager
    {
        public static int Insert(Director director, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblDirector entity = new tblDirector();
                    entity.Id = dc.tblDirectors.Any() ? dc.tblDirectors.Max(s => s.Id) + 1 : 1;
                    entity.FirstName = director.FirstName;
                    entity.LastName = director.LastName;

                    // IMPORTANT - BACK FILL THE ID 
                    director.Id = entity.Id;

                    dc.tblDirectors.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public static int Update(Director director, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblDirector entity = dc.tblDirectors.FirstOrDefault(s => s.Id == director.Id);
                    if (entity != null)
                    {
                        entity.FirstName = director.FirstName;
                        entity.LastName = director.LastName;

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception) { throw; }
        }

        public static Director LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblDirector entity = dc.tblDirectors.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Director
                        {
                            Id = entity.Id,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                        };
                    }
                    else { throw new Exception(); }
                }
            }
            catch (Exception) { throw; }
        }

        public static List<Director> Load()
        {
            try
            {
                List<Director> list = new List<Director>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblDirectors
                     select new
                     {
                         s.Id,
                         s.FirstName, 
                         s.LastName,
                     })
                    .ToList()
                    .ForEach(director => list.Add(new Director
                    {
                        Id = director.Id,
                        FirstName = director.FirstName, 
                        LastName = director.LastName
                    }));
                }
                return list;
            }
            catch (Exception) { throw; }
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblDirector entity = dc.tblDirectors.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblDirectors.Remove(entity);

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                } 
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
