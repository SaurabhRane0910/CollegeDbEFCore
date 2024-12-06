using AutoMapper;
using CollegeDbEC.Data;

namespace CollegeDbEC.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() { 
        
        
        
            CreateMap<Book, BookDto>().ReverseMap();
        }


    }
}
