namespace LatvijasPasts.Web.Models
{
    public class CvItemViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? LastName { get; internal set; }
        public string? Othername { get; internal set; }
        public string? PhoneNumber { get; internal set; }
    }
}
