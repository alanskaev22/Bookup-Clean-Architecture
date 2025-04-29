using MediatR;

namespace ProductsCatalog.Products.Features.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result>
{
    public Task<Result> Handle(CreateProductCommand command, CancellationToken cancellationToken) => throw new NotImplementedException();
}
