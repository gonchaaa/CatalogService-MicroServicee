using AutoMapper;
using CatalogService.DataAccess.DTOs.CatageroyDTO;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.DTOs.CatageroyDTO;
using CatalogService.Entities.DTOs.ProductDTO;
using MassTransit.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryCreateDTO,Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>();
            //CreateMap<Category, CategoryDto>();
            //CreateMap<Category, CategoryHomeDto>();
            //CreateMap<Category, CategoryNavbarDto>();


            //CreateMap<Product, ProductDetailDto>();
            CreateMap<ProductCreateDTO, Product>();
            //CreateMap<ProductCreateDto, Product>();

            //CreateMap<Product, ProductRecentDto>();
            //CreateMap<Product, ProductFilterDto>();
            //CreateMap<Product, ProductFeaturedDto>();
            //CreateMap<Product, ProductDto>();

            //CreateMap<SpecificationCreateDto, Specification>();
            //CreateMap<Specification, SpecificationListDto>();

        }
    }
}
