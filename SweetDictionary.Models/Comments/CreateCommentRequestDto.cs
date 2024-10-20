namespace SweetDictionary.Models.Comments
{
    public class CreateCommentRequestDto
    {
        public Guid PostId { get; set; }
        public long UserId { get; set; }
        public string Content { get; set; }
    }
}