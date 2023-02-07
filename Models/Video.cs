namespace projetPII.Models
{
    public class Video
    {
        public int IdVideo { get; set; }
        //public File File {get; set;}
        public string Titre { get; set; } = null!;
        public string? Description { get; set; }

    }
}