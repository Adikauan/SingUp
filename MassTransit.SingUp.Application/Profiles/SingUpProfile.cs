using AutoMapper;
using MassTransit.SingUp.Application.Models;
using MassTransit.SingUp.Domain.Aggregates;

namespace MassTransit.SingUp.Application.Profiles
{
    public class SingUpProfile : Profile
    {
        public SingUpProfile()
        {
            base.CreateMap<User, UserModel>()
                .ReverseMap();
        }
    }
}
