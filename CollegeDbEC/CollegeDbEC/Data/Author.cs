using System.ComponentModel.DataAnnotations;

namespace CollegeDbEC.Data
{
    public class Author
    {
        [Key]
        public int Author_id { get; set; }

        public string AuthorName { get; set; }

        public string Email { get; set; }
    }
}
