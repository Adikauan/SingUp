using AutoMapper;
using MediatR;
using MassTransit.SingUp.Application.Models;
using MassTransit.SingUp.Domain.Aggregates;
using MassTransit.SingUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Application.Queries.GettAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<UserModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            => this.mapper.Map<IEnumerable<UserModel>>(await unitOfWork.UserRepository.GetAllAsync());

    }
}
