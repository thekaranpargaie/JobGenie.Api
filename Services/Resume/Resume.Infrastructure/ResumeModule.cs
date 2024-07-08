using Base.Contracts;
using MediatR;

namespace Resume.Infrastructure
{
    public interface IResumeModule : IModule
    {

    }
    public class ResumeModule : IResumeModule
    {
        private readonly IMediator _mediator;
        public ResumeModule(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await _mediator.Send(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await _mediator.Send(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            return await _mediator.Send(query);
        }
    }
}
