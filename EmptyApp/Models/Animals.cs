namespace EmptyApp.Models
{
    public class Animals
    {
        public int Id { get; set; }
        public string AnimalName { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; } = new List<string?>();
    }
}
