using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;
using Moq;

namespace Application.UnitTests.Mocks.RepositoryMock
{
    public class RepositoryMock
    {
        public static Mock<IHikingTrailRepository> GetHikingTrailRepository()
        {
            var longHikingTrailGuid = Guid.Parse("c4bb537e-d015-4fa2-92a2-7d615fe679df");
            var mediumHikingTrailGuid = Guid.Parse("021a2ed3-53a4-4e3f-8ffe-b484048b5286");
            var shortHikingTrailGuid = Guid.Parse("1de68a3b-f3e3-461a-8d28-c692cb07a37b");
            
            var hikingTrails = new List<HikingTrail>()
            {
                new HikingTrail()
                {
                    Id = longHikingTrailGuid,
                    Coordinates = new Coordinates()
                    {
                        Latitude = 19.00312,
                        Longitude = 161.49642
                    },

                },
                new HikingTrail()
                {
                    Id = mediumHikingTrailGuid,
                    Coordinates = new Coordinates()
                    {
                        Latitude = -76.34117,
                        Longitude = 91.37930
                    }
                },
                new HikingTrail()
                {
                    Id = shortHikingTrailGuid,
                    Coordinates = new Coordinates()
                    {
                        Latitude = 69.58111,
                        Longitude = -76.82657
                    }
                }
            };

            var mockHikingTrailRepository = new Mock<IHikingTrailRepository>();
            mockHikingTrailRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(hikingTrails);

            return mockHikingTrailRepository;
        }
    }
}
