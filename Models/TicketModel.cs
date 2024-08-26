using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title of the ticket is required!")]
        public string Title { get; set; } = string.Empty;
        public string? Description{ get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ResolvedDate { get; set; }

        [Required(ErrorMessage = "Add the requestor name of this ticket")]
        [Display(Name = "Requestor Name")]
        public string RequestorName { get; set; } = string.Empty;
        public string ResolverName { get; set; } = string.Empty;
    }
}