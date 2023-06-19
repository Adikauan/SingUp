using MediatR;
using Microsoft.AspNetCore.Mvc;
using MassTransit.SingUp.Application.Commands.Create;
using MassTransit.SingUp.Application.Commands.Delete;
using MassTransit.SingUp.Application.Commands.Update;
using MassTransit.SingUp.Application.Models;
using MassTransit.SingUp.Application.Queries.GetById;
using MassTransit.SingUp.Application.Queries.GettAll;


namespace MassTransit.SingUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingUpController : ControllerBase
    {
        private readonly IMediator mediator;

        public SingUpController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAll() => await this.mediator.Send(new GetAllQuery());

        [HttpGet("{id}")]
        public async Task<UserModel> GetById(Guid id) => await this.mediator.Send(new GetByIdQuery(id));

        [HttpPost]
        public async Task<bool> Post(CreateCommand command) => await this.mediator.Send(command);

        [HttpPut]
        public async Task<bool> Update(UpdateCommand command) => await this.mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id) => await this.mediator.Send(new DeleteCommand(id));
    }
}
