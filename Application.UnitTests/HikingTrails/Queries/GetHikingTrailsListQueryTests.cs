using ActivityApp.Application.Common.Mappings;
using ActivityApp.Application.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailsList;
using Application.UnitTests.Mocks.RepositoryMock;
using AutoMapper;
using Shouldly;

namespace Application.UnitTests.HikingTrails.Queries
{
    public class GetHikingTrailsListQueryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IHikingTrailRepository> _mockHikingTrailRepository;

        public GetHikingTrailsListQueryTests()
        {
            _mockHikingTrailRepository = RepositoryMock.GetHikingTrailRepository();
            
            var configurationProvider = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Get_HikingTrails_ReturnsHikingTrails()
        {
            //Arrange
            var handler = new GetHikingTrailsListQueryHandler(_mockHikingTrailRepository.Object, _mapper);

            //Act
            var result = await handler.Handle(new GetHikingTrailsListQuery(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<List<HikingTrailListVm>>();
            result.Count.ShouldBe(3);
        }
    }
}
