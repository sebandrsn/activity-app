using ActivityApp.Application.Contracts;
using ActivityApp.Domain.Entities;

namespace Application.UnitTests.Mocks.RepositoryMock
{
    public class RepositoryMock
    {
        public static Guid HikingTrailDetailGuid => Guid.Parse("5b7d23d2-8c84-4a91-9d5f-55efffc9dcb4");

        public static Mock<IHikingTrailRepository> GetHikingTrailRepository()
        {
            var longHikingTrailGuid = Guid.Parse("c4bb537e-d015-4fa2-92a2-7d615fe679df");
            var mediumHikingTrailGuid = Guid.Parse("021a2ed3-53a4-4e3f-8ffe-b484048b5286");
            var shortHikingTrailGuid = Guid.Parse("1de68a3b-f3e3-461a-8d28-c692cb07a37b");

            var longHikingTrailCoordinatesGuid = Guid.Parse("24054846-a8d2-4c12-9793-a7cab6d14493");
            var mediumHikingTrailCoordinatesGuid = Guid.Parse("5d3f8502-56af-4a29-bcfc-7c31959d7a5c");
            var shortHikingTrailCoordinatesGuid = Guid.Parse("d5f1da9f-5a6b-4061-b5b6-46b4f504e282");
            
            var hikingTrails = new List<HikingTrail>()
            {
                new HikingTrail()
                {
                    Id = longHikingTrailGuid,
                    Coordinates = new Coordinates()
                    {
                        Id = longHikingTrailCoordinatesGuid,
                        Latitude = 19.00312,
                        Longitude = 161.49642
                    },
                    Name = "Long hiking trail",
                    Description = "A demanding hiking trail",
                    Length = 14
                },
                new HikingTrail()
                {
                    Id = mediumHikingTrailGuid,
                    Coordinates = new Coordinates()
                    {
                        Id = mediumHikingTrailCoordinatesGuid,
                        Latitude = -76.34117,
                        Longitude = 91.37930
                    },
                    Name = "Medium hiking trail",
                    Description = "A moderate hiking trail",
                    Length = 8
                },
                new HikingTrail()
                {
                    Id = shortHikingTrailGuid,
                    Coordinates = new Coordinates()
                    {
                        Id = shortHikingTrailCoordinatesGuid,
                        Latitude = 69.58111,
                        Longitude = -76.82657
                    },
                    Name = "Short hiking trail",
                    Description = "An easy hiking trail",
                    Length = 3
                }
            };

            var hikingTrailDetailCoordinatesGuid = Guid.Parse("5b7d23d2-8c84-4a91-9d5f-55efffc9dcb4");

            var hikingTrailDetail = new HikingTrail()
            {
                Id = HikingTrailDetailGuid,
                Coordinates = new Coordinates()
                {
                    Id = hikingTrailDetailCoordinatesGuid,
                    Latitude = 20.10676,
                    Longitude = 164.34281
                },
                Name = "Detailed hiking trail",
                Description = "This is a detailed description about a hiking trail",
                Length = 10
            };

            var mockHikingTrailRepository = new Mock<IHikingTrailRepository>();

            mockHikingTrailRepository
                .Setup(repo => repo.ListAllAsync())
                .ReturnsAsync(hikingTrails);

            mockHikingTrailRepository
                .Setup(repo => repo.GetByIdAsync(HikingTrailDetailGuid))
                .ReturnsAsync(hikingTrailDetail);

            return mockHikingTrailRepository;
        }
    }
}
