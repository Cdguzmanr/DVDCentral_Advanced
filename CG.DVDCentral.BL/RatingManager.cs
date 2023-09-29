using Microsoft.EntityFrameworkCore.Storage;

using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL;

namespace CG.DVDCentral.BL
{
    public class RatingManager
    {
        public static int Insert(Rating rating, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblRating entity = new tblRating();
                    entity.Id = dc.tblRatings.Any() ? dc.tblRatings.Max(s => s.Id) + 1 : 1;
                    entity.Description = rating.Description;

                    // IMPORTANT - BACK FILL THE ID 
                    rating.Id = entity.Id;

                    dc.tblRatings.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public static int Update(Rating rating, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblRating entity = dc.tblRatings.FirstOrDefault(s => s.Id == rating.Id);
                    if (entity != null)
                    {
                        entity.Description = rating.Description;

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

        public static Rating LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblRating entity = dc.tblRatings.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Rating
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

        public static List<Rating> Load()
        {
            try
            {
                List<Rating> list = new List<Rating>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblRatings
                     select new
                     {
                         s.Id,
                         s.Description
                     })
                    .ToList()
                    .ForEach(rating => list.Add(new Rating
                    {
                        Id = rating.Id,
                        Description = rating.Description
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
                    tblRating entity = dc.tblRatings.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblRatings.Remove(entity);

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
