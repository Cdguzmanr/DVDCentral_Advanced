using Microsoft.EntityFrameworkCore.Storage;

using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL;

namespace CG.DVDCentral.BL
{
    public class FormatManager
    {
        public static int Insert(Format format, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblFormat entity = new tblFormat();
                    entity.Id = dc.tblFormats.Any() ? dc.tblFormats.Max(s => s.Id) + 1 : 1;
                    entity.Description = format.Description;

                    // IMPORTANT - BACK FILL THE ID 
                    format.Id = entity.Id;

                    dc.tblFormats.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public static int Update(Format format, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblFormat entity = dc.tblFormats.FirstOrDefault(s => s.Id == format.Id);
                    if (entity != null)
                    {
                        entity.Description = format.Description;

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

        public static Format LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblFormat entity = dc.tblFormats.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Format
                        {
                            Id = entity.Id,
                            Description = entity.Description,
                        };
                    }
                    else { throw new Exception(); }
                }
            }
            catch (Exception) { throw; }
        }

        public static List<Format> Load()
        {
            try
            {
                List<Format> list = new List<Format>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblFormats
                     select new
                     {
                         s.Id,
                         s.Description
                     })
                    .ToList()
                    .ForEach(format => list.Add(new Format
                    {
                        Id = format.Id,
                        Description = format.Description
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
                    tblFormat entity = dc.tblFormats.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblFormats.Remove(entity);

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
