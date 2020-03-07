using AutoMapper;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.ViewModels;

namespace WebStore.Infrastructure.AutoMapper
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<RegisterViewModel, User>();

        }
    }
}
