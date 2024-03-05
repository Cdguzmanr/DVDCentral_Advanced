using CG.DVDCentral.PL2.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.DVDCentral.BL
{
    public class MovieSPManager : GenericManager<spGetMoviesResult>
    {
        public MovieSPManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }

        public List<spGetMoviesResult> Load()
        {
            try
            {
                List<spGetMoviesResult> rows = new List<spGetMoviesResult>();
                //using (DVDCentralEntities dc = new DVDCentralEntities(options))
                //{
                //    var results = dc.Set<spGetMoviesResult>().FromSqlRaw("exec spGetMovies").ToList();
                //    foreach (var row in results)
                //    {
                //        rows.Add(new spGetMoviesResult
                //        {
                //            Id = row.Id,
                //            RatingId = row.RatingId,
                //            Cost = row.Cost,
                //            Description = row.Description,
                //            DirectorId = row.DirectorId,
                //            FormatId = row.FormatId,
                //            Quantity = row.Quantity,
                //            Title = row.Title,
                //            FirstName = row.FirstName,
                //            LastName = row.LastName,
                //        });
                //    }


                //}

                base.Load("spGetMovies")
                    .ForEach(row => rows.Add(
                        new spGetMoviesResult
                        {
                            Id = row.Id,
                            RatingId = row.RatingId,
                            Cost = row.Cost,
                            Description = row.Description,
                            DirectorId = row.DirectorId,
                            FormatId = row.FormatId,
                            Quantity = row.Quantity,
                            Title = row.Title,
                            FirstName = row.FirstName,
                            LastName = row.LastName,
                        }));
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
