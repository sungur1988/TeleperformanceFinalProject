using Application.Dtos;
using Application.Features.Categories.Requests.Commands;
using Application.Features.ShoppingLists.Requests.Commands;
using AutoMapper;
using Domain;

namespace Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<ShoppingListItem, ShoppingListItemDto>().ReverseMap();

            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<ShoppingList, CreateShoppingListCommand>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
        }
    }
}
