using AutoMapper;
using MassTransit.SingUp.Application.IntegrationEvents.Events;
using MassTransit.SingUp.Application.Models;
using MassTransit.SingUp.Domain.Aggregates;
using MassTransit.SingUp.Domain.Interfaces;
using MediatR;

namespace MassTransit.SingUp.Application.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IUserCreatedEventHandling userCreatedEventHandling;
        private readonly IMediator mediator;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserCreatedEventHandling userCreatedEventHandling, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userCreatedEventHandling = userCreatedEventHandling;
            this.mediator = mediator;
        }

        public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            User userModel = this.mapper.Map<User>(request.Payload);
            userModel.SetNewId();
            this.unitOfWork.UserRepository.Add(userModel);
            var result = await this.unitOfWork.Commit();

            if (!result)
            {
                unitOfWork.Rollback();
                return false;
            }

            await userCreatedEventHandling.Publish(this.mapper.Map<UserModel>(userModel));
            
            return true;
        }
    }
}
