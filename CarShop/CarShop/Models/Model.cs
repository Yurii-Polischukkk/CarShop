﻿namespace CarShop.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }
}
