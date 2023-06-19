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

namespace MassTransit.SingUp.Application.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, UserModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            => this.mapper.Map<UserModel>(await this.unitOfWork.UserRepository.GetByIdAsync(x => x.Id == request.Id));
    }
}
