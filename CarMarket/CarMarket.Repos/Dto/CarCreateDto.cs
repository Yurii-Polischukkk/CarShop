using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Repos.Dto
{
    public class CarCreateDto
    {
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }
        public string? ImgPath { get; set; }

        public string? Color { get; set; }

        public string? Engine { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
    }
}
