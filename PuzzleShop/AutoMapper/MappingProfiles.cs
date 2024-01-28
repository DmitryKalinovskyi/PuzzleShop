using AutoMapper;
using PuzzleShop.Dto;
using PuzzleShop.Models;

namespace PuzzleShop.AutoMapper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Puzzle, PuzzleDto>();       
            CreateMap<Brand, BrandDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<User, UserDto>();
        }
    }
}
