namespace SweetDictionary.Models.Comments
{
    public class CommentResponseDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}