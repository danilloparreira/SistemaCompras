using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    internal class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }
        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            _solicitacaoCompraRepository.RegistrarCompra(request.SolicitacaoCompra);

            Commit();
            PublishEvents(request.SolicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}
