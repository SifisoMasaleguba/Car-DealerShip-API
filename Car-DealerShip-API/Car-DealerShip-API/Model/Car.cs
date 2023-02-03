using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_DealerShip_API.Model
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Engine { get; set; }
        public string Color { get; set; }
        public int NumberOfGears { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Milleage { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }
}
