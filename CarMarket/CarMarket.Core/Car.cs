using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Core
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Engine { get; set; }
        public double Price  { get; set; }
        public string? ImgPath { get; set; }
        
        public string? Description { get; set; }
        public Brand? Brand { get; set; }
        public Model? Model { get; set; }
    }
}
