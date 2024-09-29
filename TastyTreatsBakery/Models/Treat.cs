﻿using System.ComponentModel.DataAnnotations;

namespace TastyTreatsBakery.Models
{
	public class Treat
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}
