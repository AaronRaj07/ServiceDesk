namespace ServiceDesk.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description{ get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResolvedDate { get; set; }
        //public string? RequestorName { get; set; }
        //public string ResolverName { get; set; }
    }
}