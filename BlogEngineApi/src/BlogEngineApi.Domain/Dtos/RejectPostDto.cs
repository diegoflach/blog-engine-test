namespace BlogEngineApi.Domain.Dtos
{
    public class RejectPostDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorUsername { get; set; }

        public string RejectReason { get; set; }

    }
}