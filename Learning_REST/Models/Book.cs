namespace Learning_REST.Models
{
    public class Book
    {
        public int Id { get; set; }
        // i guess ints can just default to zero but for things like strings they need to at least have a value on constructor exit
        public string Title { get; set; } = "Unknown";

        public string? Subtitle { get; set; }

        public string Author { get; set; } = "Unknown";

        public int YearPublished { get; set; }

        public int NumPages { get; set; }

        public List<string> Genres { get; set; } = new List<string>{ "Unknown" };

    }
}
