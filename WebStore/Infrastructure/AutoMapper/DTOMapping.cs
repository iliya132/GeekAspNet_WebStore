using AutoMapper;
using WebStore.Domain.Entities.DTO;
using WebStore.Domain.ViewModels;

namespace WebStore.Infrastructure.AutoMapper
{
    public class DTOMapping : Profile
    {
        public DTOMapping()
        {
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
        }
    }
}
