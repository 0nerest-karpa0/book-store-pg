namespace BookStorePG.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public int AuthorId { get; set; }
    }
}
