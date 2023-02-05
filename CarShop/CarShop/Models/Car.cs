namespace CarShop.Models
{
    public class Car
    {
        public int Id { get;set; }
        public Brand Brand { get;set; }
        public Model Model { get; set; }
        public string Color { get;set; }
        public double Engine { get;set; }
        public double Price { get;set; }
        public string Description { get;set; }
    }
}
