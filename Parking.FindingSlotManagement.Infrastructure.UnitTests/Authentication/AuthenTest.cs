using Castle.Core.Configuration;
using Moq;
using Parking.FindingSlotManagement.Application.Contracts.Persistence;
using Parking.FindingSlotManagement.Application.Models.Authenticate;
using Shouldly;

namespace Parking.FindingSlotManagement.Infrastructure.UnitTests.Authentication
{

    public class AuthenTest
    {
        private readonly Mock<IConfiguration> _configurationMock = new();
        private readonly Mock<Persistences.ParkZDbContext> _dbContextMock = new();
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenTest(Application.Contracts.Persistence.IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        
    }
}