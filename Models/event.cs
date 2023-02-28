namespace projetPII.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;
        public string Lieu { get; set; } = null!;
    }
}