using Application.Exceptions;
using MediatR;


namespace Application.Common
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : BaseModel, IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (!request.IsValid(out var errors))
            {
                throw new ValidationException(
                    $"Invalid data: {string.Join(" | ", errors.Select(e => e.ErrorMessage))}"
                );
            }

            return await HandleValidated(request, cancellationToken);
        }
        protected abstract Task<TResponse> HandleValidated(TRequest request, CancellationToken cancellationToken);
    }

}
