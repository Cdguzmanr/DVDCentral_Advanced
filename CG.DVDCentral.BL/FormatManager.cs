﻿using CG.DVDCentral.BL;

namespace CG.DVDCentral.BL
{
    public class FormatManager : GenericManager<tblFormat>
    {
        public FormatManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }
        public FormatManager(ILogger logger, DbContextOptions<DVDCentralEntities> options) : base(logger, options) { }
        public List<Format> Load()
        {

            try
            {
                List<Format> rows = new List<Format>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Format
                        {
                            Id = d.Id,
                            Description = d.Description,
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int Insert(Format format, bool rollback = false)
        {
            try
            {
                tblFormat row = new tblFormat { Description = format.Description };
                format.Id = row.Id;
                return base.Insert(row, e => e.Description == format.Description, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> InsertAsync(Format format, bool rollback = false)
        {
            try
            {
                tblFormat row = new tblFormat { Description = format.Description };
                format.Id = row.Id;
                return await InsertAsync(row, e => e.Description == format.Description, rollback);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Format>> LoadAsync()
        {

            try
            {
                List<Format> rows = new List<Format>();
                (await base.LoadAsync())
                    .OrderBy(d => d.SortField)
                    .ToList()
                    .ForEach(d => rows.Add(
                        new Format
                        {
                            Id = d.Id,
                            Description = d.Description,
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Format LoadById(Guid id)
        {
            try
            {
                tblFormat row = base.LoadById(id);

                if (row != null)
                {
                    Format format = new Format
                    {
                        Id = row.Id,
                        Description = row.Description,
                    };

                    return format;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Format format, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblFormat
                {
                    Id = format.Id,
                    Description = format.Description
                }, rollback);
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
                return base.Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}