

using CG.DVDCentral.PL.Test;

namespace CG.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie : utBase<tblMovie>
    {
          [TestMethod]
        public void LoadSPTest()
        {
            var results = dc.Set<spGetMoviesResult>().FromSqlRaw("exec spGetMovies").ToList(); 
            var expected = 7;
            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void LoadByGenreTest()
        {
            int expected = 2;
            var parameter1 = new SqlParameter
            {
                ParameterName = "GenreName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = "Sc"
            };

            var results = dc.Set<spGetMoviesResult>().FromSqlRaw("exec spGetMoviesByGenre @GenreName", parameter1).ToList();

            string title = results[1].Title;

            /*foreach (var item in results)
            {
                title = item.Title;
            }*/
            
            Assert.AreEqual(expected, results.Count);
            Assert.AreEqual("Jaws", title);
        }   

        [TestMethod]
        public void LoadTest()
        {
            int expected = 7;
            var movies = base.LoadTest();
            Assert.AreEqual(expected, movies.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMovie newRow = new tblMovie();

            newRow.Id = Guid.NewGuid();
            newRow.Title = "XXXXX";
            newRow.Description = "XXXXX";
            newRow.Cost = 9.99;
            newRow.RatingId = base.LoadTest().FirstOrDefault().RatingId;
            newRow.FormatId = base.LoadTest().FirstOrDefault().FormatId;
            newRow.DirectorId = base.LoadTest().FirstOrDefault().DirectorId;
            newRow.Quantity = 0;
            newRow.ImagePath = "none";
            int rowsAffected = InsertTest(newRow);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovie row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.Description = "YYYYY";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblMovie row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
