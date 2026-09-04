using AutoMapper;
using WareSync.API.DTOs;
using WareSync.API.Models;

namespace WareSync.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Product
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Category,
                opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Supplier,
                opt => opt.MapFrom(src => src.Supplier.Name));

        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        // Category
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();

        // Supplier
        CreateMap<Supplier, SupplierDto>();
        CreateMap<CreateSupplierDto, Supplier>();
        CreateMap<UpdateSupplierDto, Supplier>();
    }
}