namespace VideoPlayer
{
   
        public class Movie
        {
            public string? Title { get; set; }
            public string? BulletText { get; set; }
            public string? Description { get; set; }
            public int RunningTime { get; set; }
            public string? Id { get; set; }
            public string? ArtUrl { get; set; }
            public List<string>? Related { get; set; }
        }
    
}