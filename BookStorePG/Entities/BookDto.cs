namespace BookStorePG.Entities
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        Author Author { get; set; }

        public BookDto(Book book, Author author) 
        {
            Id = book.Id;
            Name = book.Name;
            CreatedAt = book.CreatedAt;
            Author = author;
        }
    }
}
