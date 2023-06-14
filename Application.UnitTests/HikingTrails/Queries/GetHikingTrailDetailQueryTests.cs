using ActivityApp.Application.Common.Exceptions;
using ActivityApp.Application.Common.Mappings;
using ActivityApp.Application.Contracts;
using ActivityApp.Application.Feature.HikingTrails.Queries.GetHikingTrailDetail;
using ActivityApp.Domain.Entities;
using Application.UnitTests.Mocks;
using Application.UnitTests.Mocks.RepositoryMock;
using AutoFixture;
using AutoFixture.Xunit2;
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
        public async Task Get_HikingTrailWithWrongId_ThrowsNotFoundException()
        {
            //Arrange
            var handler = new GetHikingTrailDetailQueryHandler(_mockHikingTrailRepository.Object, _mapper);
            var getHikingTrailDetailQuery = new GetHikingTrailDetailQuery() { Id = Guid.Empty };

            //Act
            var exception = await Should.ThrowAsync<NotFoundException>(async () =>
            {
                await handler.Handle(getHikingTrailDetailQuery, CancellationToken.None);
            });

            //Assert
            exception.ShouldBeOfType<NotFoundException>();
            exception.Message.ShouldBe($"Hiking trail ({Guid.Empty}) was not found");
        }

        [Theory]
        [AutoDomainData]
        public async Task Get_HikingTrail_ReturnsHikingTrail(
            [Frozen] Mock<IHikingTrailRepository> hikingTrailRepositoryMock,
            GetHikingTrailDetailQuery dq,
            HikingTrail hikingTrail)
        {
            //Arrange
            hikingTrailRepositoryMock
                .Setup(repo => repo.GetByIdAsync(dq.Id))
                .ReturnsAsync(hikingTrail);
            var handler = new GetHikingTrailDetailQueryHandler(hikingTrailRepositoryMock.Object, _mapper);

            //Act
            var returnedHikingTrail = await handler.Handle(dq, CancellationToken.None);

            //Assert
            returnedHikingTrail.ShouldBeOfType<HikingTrailDetailVm>();
        }
    }
}
