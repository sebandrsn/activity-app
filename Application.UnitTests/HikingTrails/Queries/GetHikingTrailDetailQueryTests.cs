using ActivityApp.Application.Common.Mappings;
using ActivityApp.Application.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using Application.UnitTests.Mocks.RepositoryMock;
using AutoMapper;
using Shouldly;

namespace Application.UnitTests.HikingTrails.Queries
{
    public class GetHikingTrailDetailQueryTests
    {
        private readonly Mock<IHikingTrailRepository> _mockHikingTrailRepository;
        private readonly IMapper _mapper;

        public GetHikingTrailDetailQueryTests()
        {
            _mockHikingTrailRepository = RepositoryMock.GetHikingTrailRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }


        [Fact]
        public async Task Get_HikingTrail_ReturnsHikingTrail()
        {
            //Arrange
            var handler = new GetHikingTrailDetailQueryHandler(_mockHikingTrailRepository.Object, _mapper);

            //Act
            var hikingTrail = await handler.Handle(new GetHikingTrailDetailQuery() { Id = RepositoryMock.HikingTrailDetailGuid }, CancellationToken.None);

            //Assert
            hikingTrail.ShouldBeOfType<HikingTrailDetailVm>();
        }
    }
}
