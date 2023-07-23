namespace anketdeneme.Models
{
    public class Memnuniyet
    {
        public int Id { get; set; }
        public string MemnuniyetDerecesi { get; set; } = string.Empty;
        public List<Sorular>? Sorulars { get; set; }

    }

}