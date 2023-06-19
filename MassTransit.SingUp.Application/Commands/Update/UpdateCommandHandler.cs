using AutoMapper;
using MediatR;
using MassTransit.SingUp.Domain.Aggregates;
using MassTransit.SingUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Application.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            User userAlreadyExist = await unitOfWork.UserRepository.GetByIdAsync(x => x.Id == request.Payload.Id);

            if (userAlreadyExist == null)
                return false;

            unitOfWork.UserRepository.Update(userAlreadyExist, this.mapper.Map<User>(request.Payload));
            bool result = await unitOfWork.Commit();

            if (!result)
            {
                unitOfWork.Rollback();
                return false;
            }
            return true;   
        }
    }
}
