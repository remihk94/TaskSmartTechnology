using AutoMapper;
using SmartTechnology.Models;

namespace SmartTechnology.Dto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // mapping between Product and AddEditProductDto
            CreateMap<AddEditProductDto, Product>();
            CreateMap<Product, AddEditProductDto>().ForMember(dest => dest.ProductVariantAddEditDtos, opt => opt.MapFrom(src => src.ProductVariants));
            CreateMap<AddEditProductDto, Product>().ForMember(dest => dest.ProductVariants, opt => opt.MapFrom(src => src.ProductVariantAddEditDtos));

            // mapping between Product and ProductDto
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>().ForMember(dest => dest.ProductVariantDtos, opt => opt.MapFrom(src => src.ProductVariants));
            CreateMap<ProductDto, Product>().ForMember(dest => dest.ProductVariants, opt => opt.MapFrom(src => src.ProductVariantDtos)); ;

            // mapping between ProductVariant and ProductVariantDto
            CreateMap<ProductVariant, ProductVariantDto>().ForMember(dest => dest.ColorDto, opt => opt.MapFrom(src => src.Color)).ForMember(dest => dest.SizeDto, opt => opt.MapFrom(src => src.Size));
            CreateMap<ProductVariantDto, ProductVariant>().ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.ColorDto)).ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.SizeDto));

            // mapping between ProductVariant and ProductVariantAddEditDto
            CreateMap<ProductVariant, ProductVariantAddEditDto>();
            CreateMap<ProductVariantAddEditDto, ProductVariant>().ReverseMap();

            // mapping between Color and ColorDto
            CreateMap<Color, ColorDto>();
            CreateMap<Color, ColorDto>().ReverseMap();

            // mapping between Size and SizeDto
            CreateMap<Size, SizeDto>();
            CreateMap<Size, SizeDto>().ReverseMap();

        }
    }
}
