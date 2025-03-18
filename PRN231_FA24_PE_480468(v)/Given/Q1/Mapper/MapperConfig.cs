using AutoMapper;
using Q1.DTOs;
using Q1.Models;

namespace Q1.Mapper
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<Book, BookResponse>().ReverseMap();

			CreateMap<Author, AuthorResponse>().ReverseMap();
		}
	}
}
