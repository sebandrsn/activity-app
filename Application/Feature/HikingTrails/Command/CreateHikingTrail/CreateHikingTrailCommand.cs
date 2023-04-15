using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;
using FluentValidation;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail
{
    public class CreateHikingTrailCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public Coordinates Coordinates { get; set; } = null!;
        public double? Length { get; set; } = null;
        public string Description { get; set; } = null!;
    }

    public class CreateHikingTrailCommandHandler : IRequestHandler<CreateHikingTrailCommand, Guid>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;
        private readonly IValidator<CreateHikingTrailCommand> _validator;

        public CreateHikingTrailCommandHandler(IHikingTrailRepository hikingTrailRepository, 
            IValidator<CreateHikingTrailCommand> validator)
        {
            _hikingTrailRepository = hikingTrailRepository;
            _validator = validator;
        }
        public async Task<Guid> Handle(CreateHikingTrailCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            var hikingTrail = new HikingTrail()
            {
                Name = request.Name,
                Coordinates = request.Coordinates,
                Length = request.Length,
                Description = request.Description
            };

            var entity = await _hikingTrailRepository.AddAsync(hikingTrail);

            //implement unit of work pattern

            return entity.Id;
        }
    }
}