using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Core
{
    public class Key
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Назва товару")]
        public string? Name { get; set; }
        [Display(Name = "Опис")]
        public string? Description { get; set; }
        [Display(Name = "Ціна")]
        public double? Price { get; set; }
        [Display(Name = "Фото")]
        public string? ImgPath { get; set; }
        public string? Color { get; set; }
        public string? Engine { get; set; }

        [Display(Name = "Бренд")]
        public Brand? Brand { get; set; }
        [Display(Name = "Модель")]
        public Model? Model { get; set; }
       

    }
}
