namespace RESTCat.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public string? Color { get; set; }

        public Cat()
        {

        }
        public override string ToString()
        {
            return $"Cat:  Id={Id}, Name={Name}, Age={Age}, Breed={Breed}, Color={Color}"; 
        }
    }
}
