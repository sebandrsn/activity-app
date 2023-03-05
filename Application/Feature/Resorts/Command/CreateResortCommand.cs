using ActivityApp.Application.Interfaces;
using ActivityApp.Domain;
using MediatR;

namespace ActivityApp.Application.Feature.Resorts.Command
{
    public class CreateResortCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }

    public class CreateResortCommandHandler : IRequestHandler<CreateResortCommand, Guid>
    {
        private readonly IResortRepository _resortRepository;
        public CreateResortCommandHandler(IResortRepository resortRepository)
        {
            _resortRepository = resortRepository;
        }
        public async Task<Guid> Handle(CreateResortCommand request, CancellationToken cancellationToken)
        {
            var resort = new Resort()
            {
                Name = request.Name,
                Address = request.Address
            };

            var entity = await _resortRepository.AddAsync(resort);

            //implement unit of work pattern

            return entity.Id;
        }
    }
}
