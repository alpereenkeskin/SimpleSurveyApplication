namespace anketdeneme.Models
{
	public class AppRole
	{
		public int Id { get; set; }
		public string Role { get; set; } = string.Empty;
		public List<Users>? Users { get; set; }

	}
}

