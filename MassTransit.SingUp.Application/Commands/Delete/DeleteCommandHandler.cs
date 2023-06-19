using MediatR;
using MassTransit.SingUp.Domain.Aggregates;
using MassTransit.SingUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Application.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            User isSampleValid = await unitOfWork.UserRepository.GetByIdAsync(x => x.Id == request.Id);

            if(isSampleValid == null)
                return false;

            unitOfWork.UserRepository.Remove(isSampleValid);
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
