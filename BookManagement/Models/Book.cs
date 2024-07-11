public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Year { get; set; }
    public Author Author { get; set; }
    public Category Category { get; set; }
}