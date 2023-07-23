namespace anketdeneme.Models
{
    public class Sorular
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Departman { get; set; } = string.Empty;
        public string MesajKutusu { get; set; } = string.Empty;
        public int MemnuniyetID { get; set; }
        public Memnuniyet? Memnuniyet { get; set; }

    }
}