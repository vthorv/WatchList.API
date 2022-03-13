namespace WatchList.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public bool Watched { get; set; }

    }

    public class CreateMovieDto
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public bool Watched { get; set; }

    }

}
