namespace YourSalary.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }    

        public Brand Brand { get; set; }

        public List<Car> Cars { get; set; } 
    }
}
