using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TastyTreatsBakery.Models
{
	public class Treat
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
	}
}
