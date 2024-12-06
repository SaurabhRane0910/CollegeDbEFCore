using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeDbEC.Data
{
    public class Book
    {

        public int Id { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public int NoOfPagaes {  get; set; }

        public bool IsActive {  get; set; }


        public int LanguageId { get; set; }

        public int Author_id {  get; set; } 

        [ForeignKey("LanguageId")]
        public Language? Language { get; set; }

        [ForeignKey("Author_id")]
       public Author? Author { get; set; }
    }
}
