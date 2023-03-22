using MediatR;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public Domain.SolicitacaoCompraAggregate.SolicitacaoCompra SolicitacaoCompra { get; internal set; }
    }
}
