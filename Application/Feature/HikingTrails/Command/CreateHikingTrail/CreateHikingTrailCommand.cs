using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail
{
    public class CreateHikingTrailCommand : IRequest<CreateHikingTrailCommandResponse>
    {
        public string Name { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public Coordinates Coordinates { get; set; } = null!;
        public double? Length { get; set; } = null;
        public string Description { get; set; } = null!;
    }

    public class CreateHikingTrailCommandHandler : IRequestHandler<CreateHikingTrailCommand, CreateHikingTrailCommandResponse>
    {
        private readonly IHikingTrailRepository _hikingTrailRepository;
        private readonly IValidator<CreateHikingTrailCommand> _validator;
        private readonly IMapper _mapper;

        public CreateHikingTrailCommandHandler(IHikingTrailRepository hikingTrailRepository, 
            IValidator<CreateHikingTrailCommand> validator,
            IMapper mapper)
        {
            _hikingTrailRepository = hikingTrailRepository;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<CreateHikingTrailCommandResponse> Handle(CreateHikingTrailCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            var response = new CreateHikingTrailCommandResponse();
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = new List<string>();

                foreach (var validationError in validationResult.Errors)
                {
                    response.ValidationErrors.Add(validationError.ErrorMessage);
                }

                response.Success = false;
            }
            if (validationResult.IsValid)
            {
                var hikingTrail = _mapper.Map<HikingTrail>(request);
                hikingTrail = await _hikingTrailRepository.AddAsync(hikingTrail);
                response.HikingTrail = _mapper.Map<HikingTrailDto>(hikingTrail);

                response.Success = true;
            }

            //implement unit of work pattern

            return response;
        }
    }
}