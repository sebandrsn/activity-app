using MediatR;
using ActivityApp.Domain.Entities;
using ActivityApp.Application.Contracts;

namespace ActivityApp.Application.Feature.Coordinate.Command
{
    public class CreateCoordinateCommand : IRequest<Guid>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class CreateCoordinateCommandHandler : IRequestHandler<CreateCoordinateCommand, Guid>
    {
        private readonly ICoordinatesRepository _coordinatesRepository;

        public CreateCoordinateCommandHandler(ICoordinatesRepository coordinatesRepository)
        {
            _coordinatesRepository = coordinatesRepository;
        }

        public async Task<Guid> Handle(CreateCoordinateCommand request, CancellationToken cancellationToken)
        {
            var coordinates = new Coordinates()
            {
                Id = Guid.NewGuid(),
                Latitude = request.Latitude,
                Longitude = request.Longitude,
            };

            var entity = await _coordinatesRepository.AddAsync(coordinates);
            return entity.Id;   
        }
    }
}
