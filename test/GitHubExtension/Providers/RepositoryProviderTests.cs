using GitHubExtension.Providers;
using Xunit;

namespace GitHubExtension.Tests.Providers
{
    public class RepositoryProviderTests
    {
        private readonly RepositoryProvider _repositoryProvider;

        public RepositoryProviderTests()
        {
            _repositoryProvider = new RepositoryProvider();
        }

        [Fact]
        public void RetrieveDevContainerConfigurations_ReturnsExpectedConfigurations()
        {
            // Arrange
            var expectedConfigurations = new[] { "DevContainer1", "DevContainer2" };

            // Act
            var configurations = _repositoryProvider.RetrieveDevContainerConfigurations("testRepo");

            // Assert
            Assert.Equal(expectedConfigurations, configurations);
        }

        [Fact]
        public void RetrieveAvailableMachineTypesAndRegions_ReturnsExpectedMachineTypesAndRegions()
        {
            // Arrange
            var expectedMachineTypes = new[] { "MachineType1", "MachineType2" };
            var expectedRegions = new[] { "Region1", "Region2" };

            // Act
            var machineTypes = _repositoryProvider.RetrieveAvailableMachineTypes("testRepo");
            var regions = _repositoryProvider.RetrieveAvailableRegions("testRepo");

            // Assert
            Assert.Equal(expectedMachineTypes, machineTypes);
            Assert.Equal(expectedRegions, regions);
        }
    }
}
