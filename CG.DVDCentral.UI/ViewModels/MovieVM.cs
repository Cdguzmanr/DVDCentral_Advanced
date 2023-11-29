using CG.DVDCentral.BL;

namespace CG.DVDCentral.UI.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Director> Directors { get; set; } = new List<Director>(); 
        public List<Rating> Ratings { get; set; } = new List<Rating>(); 
        public List<Format> Formats { get; set; } = new List<Format>();
        
        public IFormFile File { get; set; }

        public IEnumerable<int> GenreIds { get; set; }  // Multiple Genres 


        public MovieVM()
        {
            Genres = GenreManager.Load();
        }

        public MovieVM(int id)
        {
            Movie = MovieManager.LoadById(id);
            Genres = GenreManager.Load();
            Ratings = RatingManager.Load();
            Formats = FormatManager.Load(); 
            Directors = DirectorManager.Load();
            GenreIds = Movie.Genres.Select(a => a.Id);
        }
        

    }
}
