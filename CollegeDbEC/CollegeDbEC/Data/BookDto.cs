namespace CollegeDbEC.Data
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string BookDescription { get; set; }

        public int NoOfPagaes { get; set; }

        public bool IsActive { get; set; }


        public int LanguageId { get; set; }

        public int Author_id {  get; set; }

    }
}
