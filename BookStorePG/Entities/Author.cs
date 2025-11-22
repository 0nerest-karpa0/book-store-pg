namespace BookStorePG.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string? DateOfDeath { get; set; }

    }
}
