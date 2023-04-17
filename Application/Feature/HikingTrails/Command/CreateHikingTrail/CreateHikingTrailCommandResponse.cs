using ActivityApp.Application.Common.Responses;

namespace ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail
{
    public class CreateHikingTrailCommandResponse : Response
    {
        public HikingTrailDto HikingTrail { get; set; }
    }
}
