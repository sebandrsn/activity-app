using MediatR;
using ActivityApp.Api.Models;
using ActivityApp.Application.Feature.Resorts.Command;
using ActivityApp.Domain;

namespace ActivityApp.Services
{
    public class CreateResortService : ICreateResortService
    {
        private readonly IMediator _mediator;

        public CreateResortService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResortModel> CreateResort(ResortModel resortModel)
        {
            var command = new CreateResortCommand()
            {
                Name = resortModel.Name,
                Address = new Address()
                {
                    Street = resortModel.Address.Street,
                    PostalCode = resortModel.Address.PostalCode,
                    City = resortModel.Address.City,
                    Latitude = resortModel.Address.Latitude,
                    Longitude = resortModel.Address.Longitude
                }
            };

            var resortId = await _mediator.Send(command);
            resortModel.Id = resortId;

            return resortModel;
        }
    }
}
