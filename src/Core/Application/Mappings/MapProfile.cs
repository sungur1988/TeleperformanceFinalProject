﻿using Application.Dtos;
using Application.Features.ShoppingListItems.Requests;
using Application.Features.StockUnits.Requests.Commands;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<StockUnit, CreateStockUnitCommand>().ReverseMap();
            CreateMap<StockUnit, UpdateStockUnitCommand>().ReverseMap();
            CreateMap<StockUnit, StockUnitDto>().ReverseMap();

            CreateMap<ShoppingListItem, CreateShoppingListItemCommand>().ReverseMap();
            CreateMap<ShoppingListItem,ShoppingListItemDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
        }
    }
}
